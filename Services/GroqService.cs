using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace GreenGuard.Services
{
    /// <summary>
    /// Groq API ile iletişim kuran servis
    /// </summary>
    public class GroqService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;
        private const string API_URL = "https://api.groq.com/openai/v1/chat/completions";
        
        // BİGİ karakter sistem promptu
        private const string SYSTEM_PROMPT = @"Sen 'BİGİ' adında tatlı ve neşeli bir bitki asistanısın. 🌱
        
Özelliklerin:
- Her zaman sıcak ve samimi konuşursun
- Kullanıcının adını kullanarak kişisel hitap edersin
- Önce günlük selamlaşma yaparsın (hava, gün, motivasyon)
- Sonra soruyu detaylı ama anlaşılır şekilde cevaplarsın
- Emoji kullanmayı seversin 🌿🌻💧
- Cevapların kısa ve öz olsun (max 200 kelime)
- Bitki bakımı konusunda uzman ama arkadaş canlısısın

Örnek konuşma tarzı:
'Merhaba [İsim]! 🌞 Bugün nasılsın? Umarım güzel bir gündür! 

Orkide budama hakkında sormussun, harika bir soru! 🌸 
[Cevap...]

Başka sorun olursa buradayım! 🌱'

Sadece bitki bakımı, bahçecilik ve doğa konularında yardım et. Alakasız sorulara nazikçe bitki konularına yönlendir.";

        public GroqService(string apiKey)
        {
            _apiKey = apiKey;
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Authorization = 
                new AuthenticationHeaderValue("Bearer", _apiKey);
            _httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        /// <summary>
        /// Bahçıvana soru sor
        /// </summary>
        public async Task<string> AskGardenerAsync(string userName, string question)
        {
            try
            {
                var systemMessage = SYSTEM_PROMPT.Replace("[İsim]", userName);
                
                var requestBody = new
                {
                    model = "llama-3.3-70b-versatile",
                    messages = new[]
                    {
                        new { role = "system", content = systemMessage },
                        new { role = "user", content = $"Benim adım {userName}. Sorum: {question}" }
                    },
                    max_tokens = 500,
                    temperature = 0.7
                };

                var json = JsonSerializer.Serialize(requestBody);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync(API_URL, content);
                var responseBody = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    return $"😅 Bir sorun oluştu, tekrar dener misin? (Hata: {response.StatusCode})";
                }

                // JSON parse
                using var doc = JsonDocument.Parse(responseBody);
                var messageContent = doc.RootElement
                    .GetProperty("choices")[0]
                    .GetProperty("message")
                    .GetProperty("content")
                    .GetString();

                return messageContent ?? "🤔 Cevap alınamadı, tekrar dener misin?";
            }
            catch (HttpRequestException)
            {
                return "🌐 İnternet bağlantısı yok gibi görünüyor. Lütfen bağlantını kontrol et!";
            }
            catch (Exception ex)
            {
                return $"😅 Bir hata oluştu: {ex.Message}";
            }
        }

        /// <summary>
        /// Günlük motivasyon mesajı al
        /// </summary>
        public async Task<string> GetDailyTipAsync(string userName)
        {
            var tips = new[]
            {
                "Bugün bitkilerini kontrol etmeyi unutma!",
                "Günaydın! Bitkiler bugün nasıl?",
                "Hava güzelse bitkilerini balkona çıkarabilirsin!",
                "Sararan yaprakları temizlemeyi unutma!",
                "Bitkilerle konuşmak onları mutlu eder! 🌿"
            };
            
            var random = new Random();
            var dayTip = tips[DateTime.Now.DayOfYear % tips.Length];
            
            return $"🌱 Merhaba {userName}! {dayTip}";
        }
    }
}
