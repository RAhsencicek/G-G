using GreenGuard.Models;

namespace GreenGuard.Services
{
    /// <summary>
    /// Bitki sağlık skoru hesaplama ve öneri sistemi
    /// Kural Tabanlı Uzman Sistem (Rule-Based Expert System)
    /// </summary>
    public class HealthAnalyzerService
    {
        /// <summary>
        /// Bitki sağlık skorunu hesaplar (0-100 arası)
        /// </summary>
        public int CalculateHealthScore(Plant plant)
        {
            if (plant.PlantType == null)
                return 50; // Varsayılan skor
            
            int score = 100;
            
            // 1. Sulama kontrolü
            if (plant.LastWateredDate.HasValue)
            {
                int daysSinceWatering = (DateTime.Now - plant.LastWateredDate.Value).Days;
                int optimalDays = plant.PlantType.OptimalWateringDays;
                
                if (daysSinceWatering > optimalDays * 2)
                {
                    score -= 40; // Çok gecikmiş
                }
                else if (daysSinceWatering > optimalDays * 1.5)
                {
                    score -= 30; // Gecikmiş
                }
                else if (daysSinceWatering > optimalDays)
                {
                    score -= 15; // Biraz gecikmiş
                }
            }
            else
            {
                // Hiç sulanmamış
                int daysSinceAdded = (DateTime.Now - plant.CreatedAt).Days;
                if (daysSinceAdded > plant.PlantType.OptimalWateringDays)
                {
                    score -= 35;
                }
            }
            
            // 2. Gübreleme kontrolü
            if (plant.LastFertilizedDate.HasValue)
            {
                int daysSinceFertilizing = (DateTime.Now - plant.LastFertilizedDate.Value).Days;
                int optimalDays = plant.PlantType.OptimalFertilizingDays;
                
                if (daysSinceFertilizing > optimalDays * 2)
                {
                    score -= 20;
                }
                else if (daysSinceFertilizing > optimalDays)
                {
                    score -= 10;
                }
            }
            else
            {
                // Hiç gübrelenmemiş - ekleneli 30 günden fazla olduysa puan düşür
                int daysSinceAdded = (DateTime.Now - plant.CreatedAt).Days;
                if (daysSinceAdded > 30)
                {
                    score -= 15;
                }
            }
            
            // 3. Mevsim kontrolü (basit)
            int currentMonth = DateTime.Now.Month;
            bool isWinter = currentMonth >= 11 || currentMonth <= 2;
            
            if (isWinter && plant.PlantType.MinTemperature > 15)
            {
                score -= 10; // Tropik bitkiler kışın risk altında
            }
            
            // Skoru 0-100 arasında tut
            return Math.Max(0, Math.Min(100, score));
        }
        
        /// <summary>
        /// Sağlık durumu kategorisini döndürür
        /// </summary>
        public string GetHealthStatus(int healthScore)
        {
            if (healthScore >= 80)
                return "Mükemmel";
            else if (healthScore >= 60)
                return "İyi";
            else if (healthScore >= 40)
                return "Dikkat";
            else
                return "Kritik";
        }
        
        /// <summary>
        /// Sağlık durumuna göre renk kodu döndürür
        /// </summary>
        public System.Drawing.Color GetHealthColor(int healthScore)
        {
            if (healthScore >= 80)
                return System.Drawing.Color.FromArgb(76, 175, 80);   // Yeşil
            else if (healthScore >= 60)
                return System.Drawing.Color.FromArgb(139, 195, 74); // Açık Yeşil
            else if (healthScore >= 40)
                return System.Drawing.Color.FromArgb(255, 193, 7);  // Sarı
            else
                return System.Drawing.Color.FromArgb(244, 67, 54);  // Kırmızı
        }
        
        /// <summary>
        /// Bitkiye özel bakım önerileri oluşturur
        /// </summary>
        public List<string> GetRecommendations(Plant plant)
        {
            var recommendations = new List<string>();
            
            if (plant.PlantType == null)
            {
                recommendations.Add("Bitki türü bilgisi eksik. Lütfen bitki türünü güncelleyin.");
                return recommendations;
            }
            
            // Sulama önerisi
            if (plant.LastWateredDate.HasValue)
            {
                int daysSinceWatering = (DateTime.Now - plant.LastWateredDate.Value).Days;
                int optimalDays = plant.PlantType.OptimalWateringDays;
                
                if (daysSinceWatering >= optimalDays)
                {
                    int overdueDays = daysSinceWatering - optimalDays;
                    if (overdueDays > 0)
                    {
                        recommendations.Add($"🚿 SULAMA GEREKİYOR! {daysSinceWatering} gündür sulanmadı. ({overdueDays} gün gecikme)");
                    }
                    else
                    {
                        recommendations.Add($"💧 Sulama zamanı yaklaştı. Son sulama: {daysSinceWatering} gün önce.");
                    }
                }
                else
                {
                    int daysUntilWatering = optimalDays - daysSinceWatering;
                    recommendations.Add($"✅ Sulama durumu iyi. Sonraki sulama: {daysUntilWatering} gün sonra.");
                }
            }
            else
            {
                recommendations.Add("🚿 Henüz sulama kaydı yok. İlk sulamayı yapın!");
            }
            
            // Gübreleme önerisi
            if (plant.LastFertilizedDate.HasValue)
            {
                int daysSinceFertilizing = (DateTime.Now - plant.LastFertilizedDate.Value).Days;
                int optimalDays = plant.PlantType.OptimalFertilizingDays;
                
                if (daysSinceFertilizing >= optimalDays)
                {
                    recommendations.Add($"🌱 Gübreleme zamanı! Son gübreleme: {daysSinceFertilizing} gün önce.");
                }
            }
            else
            {
                int daysSinceAdded = (DateTime.Now - plant.CreatedAt).Days;
                if (daysSinceAdded > 30)
                {
                    recommendations.Add("🌱 Henüz gübreleme yapılmamış. Gübre eklemeyi düşünün.");
                }
            }
            
            // Mevsimsel öneri
            int currentMonth = DateTime.Now.Month;
            if (currentMonth >= 11 || currentMonth <= 2) // Kış
            {
                if (plant.PlantType.MinTemperature > 10)
                {
                    recommendations.Add("❄️ Kış aylarında bitkiyi soğuktan koruyun.");
                }
            }
            else if (currentMonth >= 6 && currentMonth <= 8) // Yaz
            {
                if (plant.PlantType.SunlightNeed == "Az")
                {
                    recommendations.Add("☀️ Yaz aylarında direkt güneşten koruyun.");
                }
            }
            
            // Genel bilgi
            recommendations.Add($"ℹ️ {plant.PlantType.Name}: {plant.PlantType.Description}");
            
            return recommendations;
        }
    }
}
