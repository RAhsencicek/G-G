namespace GreenGuard.Helpers
{
    /// <summary>
    /// Bitki haberleri ve makaleleri için veri sağlayıcı
    /// </summary>
    public static class PlantNewsData
    {
        /// <summary>
        /// Tüm makaleler
        /// </summary>
        public static List<PlantArticle> AllArticles => _articles;

        /// <summary>
        /// Rastgele ipucu döndürür (Dashboard için)
        /// </summary>
        public static string GetRandomTip()
        {
            var tips = _articles.Select(a => a.ShortTip).Where(t => !string.IsNullOrEmpty(t)).ToList();
            return tips.Count > 0 ? tips[new Random().Next(tips.Count)] : "Bitkilerinize iyi bakın! 🌱";
        }

        /// <summary>
        /// Kategoriye göre makaleler
        /// </summary>
        public static List<PlantArticle> GetByCategory(string category)
        {
            return _articles.Where(a => a.Category == category).ToList();
        }

        /// <summary>
        /// Günün makalesi
        /// </summary>
        public static PlantArticle GetArticleOfTheDay()
        {
            var index = DateTime.Now.DayOfYear % _articles.Count;
            return _articles[index];
        }

        private static readonly List<PlantArticle> _articles = new()
        {
            // ===== SULAMA İPUÇLARI =====
            new PlantArticle
            {
                Id = 1,
                Title = "Orkide Sulama: Buz Küpü Yöntemi",
                ShortTip = "💧 Orkideleri buz küpüyle\nsulamayı denedin mi?",
                Summary = "Orkidelerinizi aşırı sulamadan koruyun! Buz küpü yöntemi, köklere zarar vermeden yavaş sulama sağlar.",
                FullContent = @"Orkideler, tropikal bölgelerin en zarif bitkilerinden biridir ve en yaygın bakım hatası aşırı sulamadır.

🧊 BUZ KÜPÜ YÖNTEMİ NEDİR?

Haftada 2-3 buz küpünü orkidenizin toprak yüzeyine koyun. Buz küpleri yavaşça eriyerek köklere nazikçe su sağlar.

✅ AVANTAJLARI:
• Aşırı sulamayı önler
• Kök çürümesi riskini azaltır
• Su miktarını kontrol etmenizi sağlar
• Nem seviyesini dengeler

⚠️ DİKKAT EDİLMESİ GEREKENLER:
• Buz küplerini doğrudan köklere değil, toprak yüzeyine koyun
• Çok soğuk havalarda bu yöntemi kullanmayın
• Yapraklara buz değmemesine dikkat edin

📅 NE SIKLIKTA?
Yaz aylarında haftada 2-3 kez, kış aylarında haftada 1 kez yeterlidir.",
                Category = "Sulama",
                ImageName = "orchid.png",
                ReadTimeMinutes = 3
            },
            new PlantArticle
            {
                Id = 2,
                Title = "Aşırı Sulama Belirtileri ve Çözümleri",
                ShortTip = "💧 Sararan yapraklar\naşırı sulama işareti!",
                Summary = "Bitkileriniz sarı yapraklar, yumuşak gövde veya küf gösteriyorsa aşırı sulama olabilir.",
                FullContent = @"Aşırı sulama, ev bitkilerinin en yaygın ölüm nedenidir. İşte belirtiler ve çözümler:

🚨 BELİRTİLER:
• Sararan ve düşen yapraklar
• Yumuşak, sulu gövde
• Toprakta küf veya mantar
• Kötü koku (kök çürümesi)
• Sinek ve böcek artışı

🔧 ÇÖZÜMLER:
1. Sulamayı hemen durdurun
2. Bitkiyi saksıdan çıkarın
3. Çürümüş kökleri temizleyin
4. Taze, kuru toprakla yeniden ekin
5. Drenaj deliklerini kontrol edin

💡 ÖNLEYİCİ TEDBİRLER:
• Parmak testi yapın - toprak 2-3 cm kadar kuruyorsa sulayın
• Drenaj delikli saksı kullanın
• Her bitki için sulama takvimi oluşturun",
                Category = "Sulama",
                ImageName = "water_drop.png",
                ReadTimeMinutes = 4
            },
            new PlantArticle
            {
                Id = 3,
                Title = "Mevsime Göre Sulama Rehberi",
                ShortTip = "❄️ Kışın sulama\nsıklığını azalt!",
                Summary = "İlkbahar, yaz, sonbahar ve kış için farklı sulama stratejileri öğrenin.",
                FullContent = @"Bitkilerinizin su ihtiyacı mevsime göre değişir. İşte detaylı rehber:

🌸 İLKBAHAR:
• Büyüme dönemi başlıyor
• Sulamayı kademeli olarak artırın
• Haftada 2-3 kez kontrol edin

☀️ YAZ:
• En yoğun sulama dönemi
• Sabah erken veya akşam geç sulayın
• Sıcak günlerde günlük kontrol

🍂 SONBAHAR:
• Büyüme yavaşlıyor
• Sulamayı azaltmaya başlayın
• Haftada 1-2 kez yeterli

❄️ KIŞ:
• Dinlenme dönemi
• Minimum sulama
• Toprak kurusun arada",
                Category = "Sulama",
                ImageName = "watering_can.png",
                ReadTimeMinutes = 3
            },
            
            // ===== BİTKİ BAKIM =====
            new PlantArticle
            {
                Id = 4,
                Title = "Monstera Bakım Rehberi",
                ShortTip = "🌿 Monstera yaprakları\nneden delikli?",
                Summary = "Monstera deliciosa, yapraklarındaki deliklerle ünlü tropik bir bitkidir.",
                FullContent = @"Monstera deliciosa, ev bitkisi tutkunlarının favorisidir!

🌿 YAPRAK DELİKLERİ NEDİR?
Fenestrasyon adı verilen bu delikler, yağmur ormanlarında:
• Rüzgar direncini azaltır
• Alt yapraklara ışık geçirir
• Yağmur suyunun köklere ulaşmasını sağlar

☀️ IŞIK İHTİYACI:
• Parlak, dolaylı ışık ideal
• Doğrudan güneş yaprağı yakabilir

💧 SULAMA:
• Toprak kurudukça sulayın
• Haftada 1-2 kez yeterli
• Yaprakları nemli bezle silin

🌡️ SICAKLIK:
• 18-30°C arası ideal
• 15°C altında büyüme durur",
                Category = "Bakım",
                ImageName = "monstera.png",
                ReadTimeMinutes = 4
            },
            new PlantArticle
            {
                Id = 5,
                Title = "Kaktüs ve Sukulent Bakımı",
                ShortTip = "🌵 Sukulentleri 2-3\nhaftada bir sula!",
                Summary = "Kaktüs ve sukulentler az bakım ister ama doğru bakım önemlidir.",
                FullContent = @"Kaktüsler ve sukulentler, meşgul insanlar için ideal bitkilerdir!

💧 SULAMA:
• Yaz: 2 haftada bir
• Kış: Ayda bir
• Toprak tamamen kurusun

☀️ IŞIK:
• Günde 4-6 saat güneş
• Güneye bakan pencere ideal

🪴 TOPRAK:
• İyi drene eden karışım
• Kum + perlit + toprak
• Normal toprak KULLANMAYIN

⚠️ HATALAR:
• Aşırı sulama en büyük düşman
• Süs taşları kötü havalandırma
• Cam teraryum = nem fazlası",
                Category = "Bakım",
                ImageName = "cactus.png",
                ReadTimeMinutes = 3
            },
            
            // ===== MEVSIMSEL =====
            new PlantArticle
            {
                Id = 6,
                Title = "Kış Aylarında Bitki Bakımı",
                ShortTip = "☀️ Kışın bitkileri\nradyatörden uzak tut!",
                Summary = "Kış aylarında bitkilerinizi soğuk ve kuru havadan nasıl korursunuz?",
                FullContent = @"Kış, ev bitkileri için zorlu bir dönemdir. İşte hayatta kalma rehberi:

🌡️ SICAKLIK:
• Radyatörlerden uzak tutun
• Pencere önü gece çok soğuk olabilir
• 15-20°C ideal

💡 IŞIK:
• Gün kısalıyor, ışık azalıyor
• Bitkileri aydınlık yerlere taşıyın
• Yapay ışık kullanabilirsiniz

💧 SULAMA:
• Büyük ölçüde azaltın
• Toprak uzun süre nemli kalır
• Soğuk su kullanmayın

🌬️ NEM:
• Kalorifer havayı kurutur
• Püskürtme yapın
• Nem tepsisi kullanın",
                Category = "Mevsimsel",
                ImageName = "fern.png",
                ReadTimeMinutes = 4
            },
            
            // ===== İLGİNÇ BİLGİLER =====
            new PlantArticle
            {
                Id = 7,
                Title = "Bitkiler Müzik Dinler mi?",
                ShortTip = "🎵 Bitkiler müzikten\nhoşlanır biliyor muydun?",
                Summary = "Araştırmalar, klasik müziğin bitki büyümesini %20'ye kadar artırabildiğini gösteriyor!",
                FullContent = @"Bitkiler ve müzik ilişkisi bilim dünyasında ilginç bir konu!

🔬 ARAŞTIRMALAR:
• 1960'larda Dr. T.C. Singh'in deneyleri
• Klasik müzik dinleyen bitkiler %20 daha hızlı büyüdü
• Heavy metal dinleyenler zarar gördü!

🎼 EN İYİ MÜZİK TÜRLERİ:
1. Klasik müzik (Mozart, Bach)
2. Caz
3. Doğa sesleri
4. Yumuşak pop

🤔 NEDEN?
• Ses dalgaları stomata hareketini etkiler
• Fotosentez hızlanır
• Titreşimler büyümeyi uyarır

💡 DENEYİN:
Bitkilerinize günde 1-2 saat müzik açın ve farkı gözlemleyin!",
                Category = "İlginç",
                ImageName = "flower.png",
                ReadTimeMinutes = 3
            },
            new PlantArticle
            {
                Id = 8,
                Title = "NASA'nın Hava Temizleyici Bitkileri",
                ShortTip = "🌬️ Barış Zambağı\nhavayı temizler!",
                Summary = "NASA araştırması, bazı bitkilerin ev havasındaki toksinleri temizlediğini kanıtladı.",
                FullContent = @"1989 NASA araştırması, evlerdeki hava kalitesini iyileştiren bitkileri belirledi:

🏆 EN İYİ 5 BİTKİ:

1. BARIŞ ZAMBAĞI
• Formaldehit, benzen, trikloretilen temizler
• Düşük ışıkta yaşar

2. ÖRÜMCEK BİTKİSİ 
• Karbonmonoksit emer
• Bakımı çok kolay

3. POTHOS
• Her ortamda yaşar
• Formaldehit temizler

4. KAUČUK AĞACI
• Büyük yapraklar = daha çok temizlik
• Haftalık sulama

5. ALOE VERA
• Formaldehit ve benzen
• Şifalı jöle bonus!

📊 KAÇ TANESİ GEREKİR?
Her 9 m² alan için 1 bitki önerilir.",
                Category = "Sağlık",
                ImageName = "palm.png",
                ReadTimeMinutes = 4
            },
            
            // ===== GÜBRELEME =====
            new PlantArticle
            {
                Id = 9,
                Title = "Organik Gübre Yapımı",
                ShortTip = "🌱 Kahve telvesi\ndoğal gübre!",
                Summary = "Evde organik gübre yapmak hem ekonomik hem de çevre dostudur.",
                FullContent = @"Mutfak atıklarınızı bitkileriniz için gübreye dönüştürün!

☕ KAHVE TELVESİ:
• Azot kaynağı
• Asit seven bitkiler için ideal
• Toprağa karıştırın

🍌 MUZ KABUĞU:
• Potasyum deposu
• Çiçeklenmeyi artırır
• Küçük parçalara doğrayın

🥚 YUMURTA KABUĞU:
• Kalsiyum kaynağı
• Ezin ve toprağa karıştırın
• Salyangoz kovucu

🫖 ÇAY POSASİ:
• Tanin içerir
• Asid bitkiler (açelya) için

⚠️ DİKKAT:
• Et ve süt ürünleri KULLANMAYIN
• Hastalıklı bitki parçaları KULLANMAYIN",
                Category = "Gübreleme",
                ImageName = "herbs.png",
                ReadTimeMinutes = 3
            },
            new PlantArticle
            {
                Id = 10,
                Title = "NPK Nedir? Gübre Okuma Rehberi",
                ShortTip = "🌱 NPK: Azot, Fosfor,\nPotasyum oranı!",
                Summary = "Gübre paketlerindeki sayıların anlamını öğrenin.",
                FullContent = @"Gübre paketlerinde gördüğünüz 10-10-10 gibi sayılar ne anlama gelir?

📊 NPK NEDİR?
N = Azot (Nitrogen)
P = Fosfor (Phosphorus)  
K = Potasyum (Potassium)

🌿 AZOT (N):
• Yaprak büyümesi
• Yeşil renk
• Eksiklik: Sarı yapraklar

🌸 FOSFOR (P):
• Kök gelişimi
• Çiçeklenme
• Eksiklik: Mor yapraklar

🍎 POTASYUM (K):
• Genel sağlık
• Hastalık direnci
• Meyve kalitesi

💡 ÖRNEK ORANLAR:
• 10-10-10: Genel amaçlı
• 20-10-10: Yapraklı bitkiler
• 10-20-20: Çiçekli bitkiler",
                Category = "Gübreleme",
                ImageName = "tomato.png",
                ReadTimeMinutes = 4
            },
            
            // ===== IŞIK VE YER =====
            new PlantArticle
            {
                Id = 11,
                Title = "Bitkilerin Işık İhtiyacı Rehberi",
                ShortTip = "☀️ Her bitki farklı\nışık ister!",
                Summary = "Düşük, orta ve yüksek ışık ihtiyacı olan bitkiler ve ideal yerleşimleri.",
                FullContent = @"Bitkilerinizi doğru yere koymak hayati önemde!

☀️ YÜKSEK IŞIK (Güneye bakan pencere):
• Kaktüsler ve sukulentler
• Zeytin ağacı
• Biberiye, kekik
• Domates, biber

🌤️ ORTA IŞIK (Doğu/Batı pencere):
• Monstera
• Pothos
• Fikus
• Orkide

🌑 DÜŞÜK IŞIK (Kuzey pencere):
• Zamia
• Barış zambağı
• Yılan bitkisi
• Asparagus

💡 BELİRTİLER:
• Az ışık: Uzun, seyrek büyüme
• Çok ışık: Yanık, solgun yapraklar",
                Category = "Bakım",
                ImageName = "ficus.png",
                ReadTimeMinutes = 3
            },
            new PlantArticle
            {
                Id = 12,
                Title = "Yaprak Temizliği Neden Önemli?",
                ShortTip = "🍃 Yaprak temizliği\nfotosentezi artırır!",
                Summary = "Toz biriken yapraklar fotosentez yapamaz. Düzenli temizlik şart!",
                FullContent = @"Yaprak temizliği sadece estetik değil, hayati önem taşır!

🔬 NEDEN ÖNEMLİ?
• Toz fotosentezi %30 azaltır
• Stomalar tıkanır
• Zararlılar saklanır
• Hastalıklar yayılır

🧹 NASIL TEMİZLENİR?

1. BÜYÜK YAPRAKLAR:
• Nemli yumuşak bez
• Süt + su karışımı (parlaklık için)

2. KÜÇÜK YAPRAKLAR:
• Püskürtme ve silme
• Yumuşak fırça

3. TÜYLÜ YAPRAKLAR:
• Kuru fırça
• Asla ıslatmayın!

📅 NE SIKLIKLA?
Haftada bir kez yeterli. Toz biriken ortamlarda 2 kez.",
                Category = "Bakım",
                ImageName = "monstera.png",
                ReadTimeMinutes = 3
            },
            new PlantArticle
            {
                Id = 13,
                Title = "Böcek ve Zararlılarla Mücadele",
                ShortTip = "🐛 Yaprak bitleri\nsabunlu suyla gider!",
                Summary = "Ev bitkilerinde en sık görülen zararlılar ve doğal çözümler.",
                FullContent = @"Zararlıları erken fark etmek önemli!

🐛 YAYGIN ZARARLILAR:

1. YAPRAK BİTİ (Afid):
• Yeşil/siyah küçük böcekler
• Yapak altında toplanır
• Çözüm: Sabunlu su spreyi

2. ÖRÜMCEK AKARİ:
• İnce ağlar
• Kuru ortamda çoğalır
• Çözüm: Nemi artırın

3. KABUKLU BİT:
• Kahverengi kabuklar
• Gövdede yapışık
• Çözüm: Alkollü pamuk

4. SİNEK (SCIARID):
• Toprakta larva
• Nemli topraktan gelir
• Çözüm: Sarı yapışkan tuzak

🧪 DOĞAL ÇÖZÜMLER:
• Neem yağı
• Sarımsak spreyi
• Zeytinyağı + su",
                Category = "Hastalık",
                ImageName = "herbs.png",
                ReadTimeMinutes = 4
            },
            new PlantArticle
            {
                Id = 14,
                Title = "Çelik ile Bitki Çoğaltma",
                ShortTip = "✂️ Çelik çoğaltma\nücretiz bitki!",
                Summary = "Tek bir bitkiden onlarca yeni bitki üretin - ücretsiz ve kolay!",
                FullContent = @"Çelik çoğaltma, bitki tutkunlarının en sevdiği yöntem!

✂️ NASIL YAPILIR?

1. Sağlıklı bir sürgün seçin
2. 10-15 cm uzunluğunda kesin
3. Alt yaprakları temizleyin
4. Suya veya toprağa koyun
5. 2-4 hafta bekleyin

💧 SUDA KÖKLENDİRME:
• Şeffaf kap kullanın
• Suyu haftada bir değiştirin
• 2-3 cm kök çıkınca toprağa aktarın

🪴 TOPRAKTA KÖKLENDİRME:
• Nemli tutun
• Poşetle örtün (nem için)

✅ KOLAY ÇOĞALAN BİTKİLER:
• Pothos
• Tradescantia
• Begonia
• Fikus
• Geranium",
                Category = "Çoğaltma",
                ImageName = "flower.png",
                ReadTimeMinutes = 4
            },
            new PlantArticle
            {
                Id = 15,
                Title = "Saksı Değiştirme Zamanı",
                ShortTip = "🪴 Kökler taşıyorsa\nsaksı değiştir!",
                Summary = "Bitkini ne zaman büyük saksıya taşımalısın? İşaretler ve teknikler.",
                FullContent = @"Saksı değiştirme bitkinin sağlığı için kritik!

🚨 DEĞİŞTİRME İŞARETLERİ:
• Kökler drenaj deliğinden çıkıyor
• Su hemen alt tabaktan akıyor
• Büyüme durdu
• Toprak çok hızlı kuruyor

📅 İDEAL ZAMAN:
• İlkbahar (büyüme mevsimi başı)
• Çiçeklenme döneminde DEĞİL

📏 SASKI BOYUTU:
• Mevcut saksıdan 2-3 cm büyük
• Çok büyük saksı = kök çürümesi

🔧 ADIMLAR:
1. Yeni saksının altına drenaj taşı koyun
2. Bitkiyi nazikce çıkarın
3. Kökleri hafifçe gevşetin
4. Yeni toprağa yerleştirin
5. Sulayın ama gübrelemeyein (1 hafta)",
                Category = "Bakım",
                ImageName = "succulent.png",
                ReadTimeMinutes = 3
            },
            
            // ===== FARKLI BİTKİ TÜRLERİ =====
            new PlantArticle
            {
                Id = 16,
                Title = "Eğrelti Otu Bakımı",
                ShortTip = "🌿 Eğreltiler nem\naşığıdır!",
                Summary = "Eğrelti otları zarif ama nazik bitkilerdir. Nem ve gölge isterler.",
                FullContent = @"Eğreltiler, antik çağlardan kalma zarif bitkilerdir!

🌿 ÖZELLİKLERİ:
• Çiçek açmazlar (sporla çoğalır)
• Gölge severler
• Yüksek nem isterler

💧 SULAMA:
• Toprak her zaman nemli olmalı
• Kurumaya izin vermeyin
• Musluk suyu yerine yağmur suyu

🌡️ NEM:
• %50-80 nem ideal
• Banyo için mükemmel
• Püskürtme yapın

⚠️ DİKKAT:
• Doğrudan güneş = yanık
• Kuru hava = kahverengi uçlar
• Klima yakını = ölüm",
                Category = "Bakım",
                ImageName = "fern.png",
                ReadTimeMinutes = 3
            },
            new PlantArticle
            {
                Id = 17,
                Title = "Palmiyelerin Dünyası",
                ShortTip = "🌴 Palmiyeler tropik\nhava yaratır!",
                Summary = "İç mekan palmiyeleri evize tropik bir hava katar. Bakım ipuçları burada!",
                FullContent = @"Palmiyeler evde tatil havası yaratır!

🌴 POPÜLER TÜRLER:
• Areka Palmiyesi
• Kentiya Palmiyesi
• Parlor Palm
• Yelpaze Palmiyesi

☀️ IŞIK:
• Parlak, dolaylı ışık
• Güneş yaprağı yakabilir

💧 SULAMA:
• Toprak yüzeyi kurusun
• Yaz: Haftada 1-2 kez
• Kış: 10-14 günde bir

🌡️ NEM:
• %40-60 nem ideal
• Yaprakları silin veya püskürtün

⚠️ SORUNLAR:
• Kahverengi uçlar = kuru hava
• Sarı yaprak = aşırı su
• Kahverengi lekeler = güneş yanığı",
                Category = "Bakım",
                ImageName = "palm.png",
                ReadTimeMinutes = 3
            },
            new PlantArticle
            {
                Id = 18,
                Title = "Aromalı Bitkiler: Mutfak Bahçesi",
                ShortTip = "🌿 Fesleğen\npencerenizde yetişir!",
                Summary = "Evde aromatik bitkiler yetiştirmek hem pratik hem de keyifli!",
                FullContent = @"Mutfakta taze aromalık her zaman elinizde!

🌿 KOLAY YETİŞEN AROMALAR:

1. FESLEĞEN:
• Çok güneş ister
• Sık sulayın
• Çiçekleri koparın

2. NANE:
• Gölge sever
• Hızlı yayılır
• Ayrı saksıda tutun

3. KEKIK:
• Az su ister
• Güneşli pencere
• Kışa dayanıklı

4. MAYDANOZ:
• Orta ışık
• Nemli toprak
• Kesildikçe büyür

5. BİBERİYE:
• Güneş ve kuru
• Taşlı toprak
• Kışta içeri alın

💡 İPUCU: Plastik değil pişmiş toprak saksı kullanın.",
                Category = "Bakım",
                ImageName = "herbs.png",
                ReadTimeMinutes = 4
            },
            new PlantArticle
            {
                Id = 19,
                Title = "Çiçek Açtırma Sırları",
                ShortTip = "🌸 Çiçek için fosfor\ngerekli!",
                Summary = "Bitkileriniz çiçek açmıyor mu? İşte nedenleri ve çözümleri!",
                FullContent = @"Çiçek açmayan bitki sinir bozucu olabilir. İşte sırlar:

🤔 NEDEN ÇİÇEK AÇMIYOR?

1. YETERSİZ IŞIK:
• Çoğu çiçekli bitki 6+ saat güneş ister
• Daha aydınlık yere taşıyın

2. YANLIŞ GÜBRE:
• Çok azot = sadece yaprak
• Fosfor ağırlıklı gübre kullanın (10-30-20)

3. YAŞ FAKTÖRÜ:
• Bazı bitkiler olgunlaşınca açar
• Sabırlı olun

4. DİNLENME DÖNEMİ:
• Kışın soğuk gerekir
• 6-8 hafta düşük sıcaklık

🌸 ÇİÇEK AÇTIRMA İPUÇLARI:
• Güneşli yer seçin
• Fosforlu gübre kullanın
• Sulamayı azaltın (çiçeklenme öncesi)
• Solmuş çiçekleri koparın",
                Category = "Bakım",
                ImageName = "orchid.png",
                ReadTimeMinutes = 4
            },
            new PlantArticle
            {
                Id = 20,
                Title = "Domates Yetiştirme 101",
                ShortTip = "🍅 Domates balkon\nbahçesi yıldızı!",
                Summary = "Evde veya balkonda taze domates yetiştirmek sandığınızdan kolay!",
                FullContent = @"Kendi domatesini yetiştir, tadını yakala!

🍅 BAŞLANGIÇ:

1. TOHUM veya FİDE:
• Fide daha kolay başlangıç
• Tohum daha ekonomik
• Mart-Nisan ekimi

2. SAKSI:
• En az 30 cm çap
• Derin saksı gerekli
• İyi drenaj şart

☀️ BAKIM:
• Günde 8 saat güneş
• Her gün sulama (yaz)
• Haftalık fosforlu gübre

🌱 DESTEKLEME:
• Büyüyünce destek çubuğu
• Yan sürgünleri koparın

🍅 HASAT:
• Meyve kırmızılaşınca
• Sabahleyin toplayın
• Oda sıcaklğında saklayın",
                Category = "Sebze",
                ImageName = "tomato.png",
                ReadTimeMinutes = 4
            },
            
            // ===== EK MAKALELER (21-50) =====
            new PlantArticle
            {
                Id = 21,
                Title = "Teraryum Yapımı ve Bakımı",
                ShortTip = "🏺 Teraryum kendi\nekosistemini yaratır!",
                Summary = "Cam kavanozda mini orman! Teraryum yapımı ve bakımı hakkında bilmeniz gerekenler.",
                FullContent = @"Teraryumlar, mini bir ekosistemdir!

🏺 MALZEMELER:
• Cam kap (kapaklı veya açık)
• Drenaj taşları
• Aktif karbon
• Teraryum toprağı
• Küçük bitkiler
• Dekoratif öğeler

📝 YAPIM ADIMLARI:
1. Alt katman: Drenaj taşları (2-3 cm)
2. Aktif karbon (ince tabaka)
3. Toprak (5-7 cm)
4. Bitkileri yerleştirin
5. Dekorasyon ekleyin

💧 BAKIM:
• Kapalı: Ayda 1 kez püskürtme
• Açık: Haftada 1 kez hafif sulama
• Direkt güneşten kaçının",
                Category = "Proje",
                ImageName = "fern.png",
                ReadTimeMinutes = 5
            },
            new PlantArticle
            {
                Id = 22,
                Title = "Hava Bitkileri (Tillandsia)",
                ShortTip = "🌬️ Hava bitkileri\ntoprak istemez!",
                Summary = "Topraksız yaşayan büyüleyici bitkiler: Tillandsialar nasıl bakılır?",
                FullContent = @"Tillandsialar, havadan nem alan ilginç bitkilerdir!

🌬️ ÖZELLİKLERİ:
• Toprak gerektirmez
• Havadan nem alır
• Köksü bitkiler
• 500+ tür var

💧 SULAMA:
• Haftada 1 kez suya batırın (20-30 dk)
• Sonra baş aşağı kurutun
• Püskürtme de yapabilirsiniz

☀️ IŞIK:
• Parlak, dolaylı ışık
• Güneş yakar!

🏠 YERLEŞİM:
• Tel askılar
• Tahta parçaları
• Deniz kabukları
• Teraryumlar",
                Category = "Bakım",
                ImageName = "flower.png",
                ReadTimeMinutes = 3
            },
            new PlantArticle
            {
                Id = 23,
                Title = "Bonsai Sanatına Giriş",
                ShortTip = "🌳 Bonsai sabır\nve sevgi ister!",
                Summary = "Minyatür ağaç yetiştirme sanatı: Bonsai için başlangıç rehberi.",
                FullContent = @"Bonsai, Japonya'dan gelen antik bir sanattır!

🌳 BAŞLANGIÇ:
• Kolay türlerle başlayın (Fikus, Juniper)
• Hazır bonsai alın veya tohum ekin
• Sabırlı olun (yıllar alır)

✂️ BUDAMA:
• İlkbahar ve yaz aylarında
• Şekil vermek için
• Yapraksız dalları kesin

💧 SULAMA:
• Toprak kurudukça
• Daldırma yöntemi ideal
• Aşırı sulamadan kaçının

🪴 SAKSIYA ALMA:
• 2-3 yılda bir
• İlkbaharda
• Kökleri %30 kesin

⚠️ HATALAR:
• İç mekanda sürekli tutmak
• Sulamayı unutmak
• Aşırı budama",
                Category = "Hobi",
                ImageName = "ficus.png",
                ReadTimeMinutes = 5
            },
            new PlantArticle
            {
                Id = 24,
                Title = "Yılan Bitkisi (Sansevieria) Rehberi",
                ShortTip = "🐍 Yılan bitkisi\nölümsüz gibidir!",
                Summary = "En dayanıklı ev bitkisi: Yılan bitkisi bakımı ve çoğaltması.",
                FullContent = @"Sansevieria, acemi dostudur!

🐍 NEDEN POPÜLER?
• Ölmesi çok zor
• Düşük ışıkta yaşar
• Az su ister
• Havayı temizler
• Gece oksijen üretir

💧 SULAMA:
• Ayda 1-2 kez
• Kışın daha az
• Toprak tamamen kurusun

☀️ IŞIK:
• Her koşulda yaşar
• En iyi: Dolaylı ışık

🌱 ÇOĞALTMA:
• Yaprak kesimi (yavaş)
• Rizom bölme (hızlı)

⚠️ DİKKAT:
• Aşırı su = kök çürümesi
• Soğuğa hassas (<10°C)",
                Category = "Bakım",
                ImageName = "succulent.png",
                ReadTimeMinutes = 3
            },
            new PlantArticle
            {
                Id = 25,
                Title = "Pothos: Başlangıç Bitkisi",
                ShortTip = "💚 Pothos her yerde\nyaşar!",
                Summary = "Acemiler için ideal: Pothos bakımı ve dekoratif kullanımı.",
                FullContent = @"Pothos (Epipremnum), en kolay ev bitkisidir!

💚 AVANTAJLARI:
• Çok dayanıklı
• Hızlı büyür
• Kolay çoğalır
• Asılı veya saksıda
• Hava temizler

💧 SULAMA:
• Toprak kurudukça
• Sararan yaprak = çok su
• Sarkık yaprak = susuz

☀️ IŞIK:
• Dolaylı ışık ideal
• Düşük ışıkta da yaşar
• Güneş yaprağı yakar

✂️ ÇOĞALTMA:
1. Düğüm noktasından kesin
2. Suya koyun
3. 2 hafta bekleyin
4. Kök çıkınca toprağa

🎨 ÇEŞİTLER:
• Golden Pothos (sarı)
• Marble Queen (beyaz)
• Neon (limon yeşili)",
                Category = "Bakım",
                ImageName = "monstera.png",
                ReadTimeMinutes = 3
            },
            new PlantArticle
            {
                Id = 26,
                Title = "Bitkilerde Yaprak Problemleri",
                ShortTip = "🍂 Kahverengi uçlar\nnem eksikliği!",
                Summary = "Yaprak renk değişimleri ne anlama gelir? Sorun giderme rehberi.",
                FullContent = @"Yapraklar bitkinin sağlık göstergesidir!

🟡 SARI YAPRAKLAR:
• Aşırı sulama
• Besin eksikliği
• Yaşlılık (normal)
• Çözüm: Sulamayı azaltın, gübreleyin

🟤 KAHVERENGİ UÇLAR:
• Kuru hava
• Florlu su
• Gübre yanığı
• Çözüm: Nem artırın, yağmur suyu

⚫ SİYAH LEKELER:
• Mantar hastalığı
• Soğuk hasar
• Çözüm: Hasta yaprakları kesin

🟣 MOR YAPRAKLAR:
• Fosfor eksikliği
• Soğuk stres
• Çözüm: Fosforlu gübre

⬜ BEYAZ LEKELER:
• Külleme hastalığı
• Çözüm: Fungusit",
                Category = "Hastalık",
                ImageName = "fern.png",
                ReadTimeMinutes = 4
            },
            new PlantArticle
            {
                Id = 27,
                Title = "İlkbahar Bitki Bakımı",
                ShortTip = "🌸 İlkbahar büyüme\nzamanı!",
                Summary = "Kıştan çıkan bitkilerinize bahar bakımı nasıl yapılır?",
                FullContent = @"İlkbahar, bitkiler için uyanış zamanı!

🌸 YAPILACAKLAR:

1. GÜBREYE BAŞLAYIN:
• Mart'tan itibaren
• 2 haftada bir
• Dengeli gübre (10-10-10)

2. SAKSI DEĞİŞTİRİN:
• Köklere bakın
• Gerekirse büyük saksıya

3. BUDAMA YAPIN:
• Kuru dalları kesin
• Şekil verin
• Yeni büyümeyi teşvik edin

4. SULAMAYI ARTIRIN:
• Büyüme = daha çok su
• Ama aşırıya kaçmayın

5. BALKONA ÇIKARIN:
• Don tehlikesi geçince
• Yavaş yavaş alıştırın

6. ZARARLI KONTROLÜ:
• Yaprakları inceleyin
• Erken müdahale edin",
                Category = "Mevsimsel",
                ImageName = "flower.png",
                ReadTimeMinutes = 4
            },
            new PlantArticle
            {
                Id = 28,
                Title = "Yaz Sıcağında Bitki Koruma",
                ShortTip = "☀️ Sıcakta bitkiler\nstrese girer!",
                Summary = "Aşırı sıcaklarda ev bitkilerini koruma yöntemleri.",
                FullContent = @"35°C üzeri sıcaklar bitkiler için tehlikelidir!

☀️ SORUNLAR:
• Yaprak yanığı
• Hızlı kuruma
• Stres belirtileri
• Çiçek dökümü

🛡️ KORUMA YÖNTEMLERİ:

1. GÜNEŞTEN UZAKLAŞTIRIN:
• Cam önünden alın
• Gölgeye taşıyın

2. SULAMAYI ARTIRIN:
• Sabah erken sulayın
• Akşam da kontrol edin
• Yaprak püskürtme yapın

3. NEM ARTIRIN:
• Su dolu tepsiler
• Bitkileri gruplandırın
• Nemlendir kullanın

4. KLİMA DİKKAT:
• Direkt üflemeyin
• Kuru hava tehlikeli

5. HAREKET ETTİRMEYİN:
• Stres yapmayın
• Sabit tutun",
                Category = "Mevsimsel",
                ImageName = "palm.png",
                ReadTimeMinutes = 3
            },
            new PlantArticle
            {
                Id = 29,
                Title = "Sonbahar Hazırlıkları",
                ShortTip = "🍂 Sonbaharda\nbitkileri hazırlayın!",
                Summary = "Kışa hazırlık: Sonbahar bitki bakım listesi.",
                FullContent = @"Sonbahar, kış hazırlığı zamanıdır!

🍂 KONTROL LİSTESİ:

1. DIŞARIDAKİLERİ ALIN:
• İlk don öncesi
• Yavaş yavaş alıştırın
• Zararlı kontrolü yapın

2. GÜBREYI AZALTIN:
• Eylül'den sonra durdurun
• Dinlenme dönemine hazırlık

3. SULAMAYI AZALTIN:
• Büyüme yavaşlıyor
• Daha az su gerekli

4. IŞIK AYARI:
• Güneşli yerlere taşıyın
• Yapay ışık düşünün

5. BUDAMA:
• Kuru yaprakları temizleyin
• Şekil budaması Hayır!

6. NEM KONTROLÜ:
• Kalorifer açılacak
• Nem düşecek
• Nem tepsisi hazırlayın",
                Category = "Mevsimsel",
                ImageName = "herbs.png",
                ReadTimeMinutes = 4
            },
            new PlantArticle
            {
                Id = 30,
                Title = "Bitkiler ve Evcil Hayvanlar",
                ShortTip = "🐱 Bazı bitkiler\nevcillere zararlı!",
                Summary = "Kedi ve köpekler için güvenli ve tehlikeli bitkiler listesi.",
                FullContent = @"Evcil hayvan sahipleri dikkat!

☠️ ZEHİRLİ BİTKİLER:
• Zambaklılar (çok tehlikeli!)
• Difenbahya
• Filodendron
• Pothos
• Aloe Vera
• Yılan bitkisi

✅ GÜVENLİ BİTKİLER:
• Areka palmiyesi
• Boston eğreltisi
• Örümcek bitkisi
• Bambu palmiyesi
• Kedi otu
• Afrika menekşesi

🚨 ZEHİRLENME BELİRTİLERİ:
• Kusma
• İshal
• Ağız şişmesi
• Nefes darlığı
• ACİL VETERİNER!

💡 ÖNERİLER:
• Bitkileri yükseğe koyun
• Kedi otu verin
• Araştırarak alın",
                Category = "Sağlık",
                ImageName = "cactus.png",
                ReadTimeMinutes = 4
            },
            new PlantArticle
            {
                Id = 31,
                Title = "Biber Yetiştirme Rehberi",
                ShortTip = "🌶️ Biberler güneş\naşığıdır!",
                Summary = "Evde veya balkonda biber yetiştirmenin püf noktaları.",
                FullContent = @"Biberleri evde yetiştirmek kolay!

🌶️ BAŞLANGIÇ:
• Tohum veya fide
• Şubat-Mart ekimi
• 25°C çimlendirme

☀️ IŞIK:
• Günde 8+ saat güneş
• Güneye bakan pencere
• Yapay ışık destekli

💧 SULAMA:
• Düzenli ama aşırı değil
• Sabah erken
• Yapraklara su değmesin

🌱 GÜBRELEME:
• Çiçeklenince fosforlu gübre
• 2 haftada bir
• Aşırı azot = az meyve

🍃 BUDAMA:
• İlk çiçeği koparın
• Dallanmayı artırın

🌡️ SICAKLIK:
• 20-30°C ideal
• 15°C altında büyümez",
                Category = "Sebze",
                ImageName = "tomato.png",
                ReadTimeMinutes = 4
            },
            new PlantArticle
            {
                Id = 32,
                Title = "Marul ve Yeşillik Yetiştirme",
                ShortTip = "🥬 Marul hızlı\nbüyür!",
                Summary = "Pencere kenarında taze marul ve yeşillik yetiştirmek.",
                FullContent = @"4-6 haftada taze marul!

🥬 KOLAY YEŞİLLİKLER:
• Marul
• Roka
• Maydanoz
• Dereotu
• Tere

📦 GEREKLİ MALZEMELER:
• Sığ geniş kap
• Tohum başlangıç karışımı
• Püskürtme şişesi

🌱 EKİM:
1. Toprağı nemlendirin
2. Tohumları serpin
3. İnce toprak örtün
4. Püskürtme sulayın

☀️ BAKIM:
• 4-6 saat ışık
• Nemli tutun
• 18-22°C ideal

✂️ HASAT:
• Dış yapraklardan kesin
• Tekrar büyür
• Sürekli taze ürün!",
                Category = "Sebze",
                ImageName = "herbs.png",
                ReadTimeMinutes = 3
            },
            new PlantArticle
            {
                Id = 33,
                Title = "Bitki Terapisi: Ruh Sağlığı",
                ShortTip = "🧘 Bitkiler stresi\nazaltır!",
                Summary = "Bitki bakımının ruh sağlığına faydaları bilimsel olarak kanıtlandı.",
                FullContent = @"Bitkilerle terapi gerçek!

🧠 BİLİMSEL FAYDALAR:
• Stres hormonu %37 azalma
• Kan basıncı düşmesi
• Konsantrasyon artışı
• Kaygı azalması
• Uyku kalitesi iyileşmesi

🌿 NASIL ÇALIŞIR?
• Toprakla temas (mikrobiyom)
• Yeşil rengin etkisi
• Başarı hissi
• Rutin oluşturma
• Doğayla bağ

💆 TERAPİ ÖNERİLERİ:
• Günde 10 dk bitki bakımı
• Toprakla çalışın
• Büyümeyi gözlemleyin
• Günlük tutun

🌱 İDEAL TERAPİ BİTKİLERİ:
• Lavanta (koku)
• Sukulent (kolay)
• Yeniden ekme projeleri",
                Category = "Sağlık",
                ImageName = "flower.png",
                ReadTimeMinutes = 4
            },
            new PlantArticle
            {
                Id = 34,
                Title = "Pencere Yönüne Göre Bitkiler",
                ShortTip = "🧭 Her pencere\nfarklı bitki ister!",
                Summary = "Kuzey, güney, doğu ve batı pencereleri için ideal bitkiler.",
                FullContent = @"Pencere yönü her şeyi değiştirir!

🧭 GÜNEY PENCERE:
En çok ışık! (6-8 saat)
• Kaktüsler
• Sukulentler
• Sitrus
• Biberiye

🌅 DOĞU PENCERE:
Sabah güneşi (3-4 saat)
• Orkideler
• Begonya
• Eğreltiler
• Afrika menekşesi

🌇 BATI PENCERE:
Öğleden sonra (3-4 saat)
• Pothos
• Monstera
• Fikus
• Palmiyeler

❄️ KUZEY PENCERE:
En az ışık (dolaylı)
• Yılan bitkisi
• Barış zambağı
• Zamia
• Aspidistra

💡 İPUCU:
Perdeler ışığı %50 azaltır!",
                Category = "Bakım",
                ImageName = "ficus.png",
                ReadTimeMinutes = 3
            },
            new PlantArticle
            {
                Id = 35,
                Title = "Su Kültüründe Bitki Yetiştirme",
                ShortTip = "💧 Topraksız tarım\nevde mümkün!",
                Summary = "Hidroponik: Evde topraksız bitki yetiştirme temelleri.",
                FullContent = @"Hidroponik, topraksız tarımdır!

💧 AVANTAJLARI:
• Daha hızlı büyüme
• Daha az hastalık
• Su tasarrufu (%90)
• Yıl boyu üretim

🧪 TEMEL SİSTEM:
1. Kap + net pot
2. Genleşen kil topakları
3. Besin solüsyonu
4. Hava pompası (opsiyonel)

🌱 KOLAY BAŞLANGIÇ:
• Marul
• Fesleğen
• Nane
• Yeşil soğan

📊 BESİN SOLÜSYONU:
• Hazır karışım alın
• pH 5.5-6.5
• Her hafta değiştirin

⚠️ DİKKAT:
• Kök çürümesine dikkat
• Işık yeterli olmalı
• Hava sirkülasyonu",
                Category = "Proje",
                ImageName = "water_drop.png",
                ReadTimeMinutes = 4
            },
            new PlantArticle
            {
                Id = 36,
                Title = "Çiçek Soğanları Yetiştirme",
                ShortTip = "🌷 Lale soğanlarını\nsonbaharda ekin!",
                Summary = "Lale, sümbül, nergis gibi soğanlı çiçekler nasıl yetiştirilir?",
                FullContent = @"Soğanlı çiçekler muhteşemdir!

🌷 POPÜLER TÜRLER:
• Lale
• Sümbül
• Nergis
• Zambak
• Safran

📅 EKİM ZAMANI:
• Sonbahar soğanları: Ekim-Kasım
• İlkbahar soğanları: Mart-Nisan

🪴 EKİM:
1. Soğan boyunun 2-3 katı derinlik
2. Sivri uç yukarı
3. 10-15 cm aralık
4. İyi drene eden toprak

❄️ SOĞUK İHTİYACI:
• Çoğu tür kış gerektirir
• Buzdolabında 8 hafta
• Plastik poşette

💡 İPUÇLARI:
• Grup halinde ekin
• Farklı renkleri karıştırın
• Gübrelemek gerekmez",
                Category = "Bakım",
                ImageName = "flower.png",
                ReadTimeMinutes = 3
            },
            new PlantArticle
            {
                Id = 37,
                Title = "Evde Avokado Yetiştirme",
                ShortTip = "🥑 Avokado çekirdeği\neğlenceli proje!",
                Summary = "Avokado çekirdeğinden ağaç yetiştirmek: Adım adım rehber.",
                FullContent = @"Avokado yetiştirmek çok eğlenceli!

🥑 ADIMLAR:

1. ÇEKİRDEĞİ HAZIRLAYIN:
• Temizce yıkayın
• Zarını soyma
• Üst ve altını belirleyin

2. KÜRDAN YÖNTEMİ:
• 3-4 kürdan batırın
• Yarısı suya girsin
• Cam kavanozda

3. BEKLEYİN:
• 2-6 hafta
• Suyu değiştirin
• Yarılacak ve kök çıkacak

4. TOPRAĞA:
• 15 cm kök çıkınca
• Yarısı dışarıda
• 20 cm saksı

☀️ BAKIM:
• Bol güneş
• Düzenli sulama
• Sabır (meyve için yıllar)

⚠️ NOT: Evde meyve vermez genellikle!",
                Category = "Proje",
                ImageName = "herbs.png",
                ReadTimeMinutes = 4
            },
            new PlantArticle
            {
                Id = 38,
                Title = "Limon Ağacı Bakımı",
                ShortTip = "🍋 Limon evde\nyetiştirilebilir!",
                Summary = "Saksıda limon ağacı yetiştirme ve bakım rehberi.",
                FullContent = @"Evinizde limon ağacı mümkün!

🍋 GEREKLİLİKLER:
• Meyer limonu önerilir
• Büyük saksı (40+ cm)
• Asidik toprak (pH 5.5-6.5)

☀️ IŞIK:
• Günde 8-12 saat
• Güneye bakan pencere
• Yazın dışarı çıkarın

💧 SULAMA:
• Toprak kurudukça
• Yaz: Sık
• Kış: Azaltın

🌱 GÜBRELEME:
• Sitrus gübresi
• İlkbahar-yaz ayları
• Ayda bir

❄️ KIŞ BAKIMI:
• İçeri alın
• 15°C civarı
• Sulamayı azaltın

🍋 PRO İPUÇLARI:
• Fırçayla tozlaşma yapın
• Yaprakları nemli tutun
• Zararlıları kontrol edin",
                Category = "Meyve",
                ImageName = "herbs.png",
                ReadTimeMinutes = 4
            },
            new PlantArticle
            {
                Id = 39,
                Title = "Çilek Yetiştirme",
                ShortTip = "🍓 Çilek saksıda\nbüyür!",
                Summary = "Balkonda veya pencere kenarında taze çilek yetiştirmek.",
                FullContent = @"Taze çilek yetiştirmek kolay!

🍓 TÜR SEÇİMİ:
• Everbearing: Sürekli meyve
• June-bearing: Tek hasat
• Alpine: Küçük ama aromatik

🪴 SAKSI:
• En az 20 cm derinlik
• Geniş kap ideal
• Asılı sepetler güzel

☀️ GÜN IŞIĞI:
• Günde 6-8 saat
• Güneşli balkon
• Az güneş = az meyve

💧 SULAMA:
• Düzenli ama aşırı değil
• Sabah sulayın
• Yapraklara su değmesin

🌸 POLİNASYON:
• Açık havada kendiliğinden
• İçeride fırçayla

🍓 HASAT:
• Tamamen kırmızı iken
• Hafifçe çekin
• Hemen yiyin!",
                Category = "Meyve",
                ImageName = "flower.png",
                ReadTimeMinutes = 4
            },
            new PlantArticle
            {
                Id = 40,
                Title = "Aloe Vera Mucizesi",
                ShortTip = "🌵 Aloe vera şifa\nkaynağı!",
                Summary = "Aloe vera bakımı ve yapraklarını nasıl kullanabilirsiniz?",
                FullContent = @"Aloe vera, doğal eczanedir!

🌵 BAKIM:
• Çok az su (ayda 1-2)
• Parlak ışık
• İyi drene eden toprak
• Kaktüs karışımı ideal

💧 SULAMA HATALARI:
• En yaygın hata: Aşırı su
• Yapraklar yumuşaksa = çok su
• Kahverengileşme = susuzluk

☀️ IŞIK:
• Parlak dolaylı ışık
• Güneş yaprağı yakabilir
• Kuzey pencere yeterli

✨ KULLANIM ALANLARI:
• Cilt nemlendiricisi
• Güneş yanığı
• Saç bakımı
• Küçük kesikler

✂️ YAPRAK KESME:
• Dışardan kesin
• Jeli sıyırın
• Taze kullanın veya buzdolabı",
                Category = "Bakım",
                ImageName = "cactus.png",
                ReadTimeMinutes = 3
            },
            new PlantArticle
            {
                Id = 41,
                Title = "Lavanta Yetiştirme",
                ShortTip = "💜 Lavanta kokusu\nrahattır!",
                Summary = "Evde lavanta yetiştirmek ve kurutmak için ipuçları.",
                FullContent = @"Lavanta hem güzel hem kullanışlı!

💜 BAKIMI:
• Çok güneş (6+ saat)
• Az su (kuraklık sever)
• İyi drene eden toprak
• Kireçli toprak ideal

💧 SULAMA:
• Toprak tamamen kurusun
• Aşırı su = kök çürümesi
• Kış: Çok az

✂️ BUDAMA:
• Çiçekten sonra %30 kesin
• Şekil verin
• Odunsu kısma kesmeyin

🌸 HASAT:
• Çiçekler açmadan önce
• Sabah erken
• Demetler halinde kurutun

💡 KULLANIM:
• Kurutma keseleri
• Yağ çıkarma
• Çay (bazı türler)
• Doğal böcek kovucu",
                Category = "Bakım",
                ImageName = "flower.png",
                ReadTimeMinutes = 3
            },
            new PlantArticle
            {
                Id = 42,
                Title = "Kırmızı Yapraklı Bitkiler",
                ShortTip = "❤️ Kırmızı yapraklar\ngöz alıcı!",
                Summary = "Evde renk katacak kırmızı ve bordo yapraklı bitki türleri.",
                FullContent = @"Kırmızı bitkiler eve renk katar!

❤️ POPÜLER TÜRLER:

1. REX BEGONIA:
• Metalik kırmızı desenler
• Dolaylı ışık
• Yüksek nem

2. COLEUS:
• Parlak renk kombinasyonları
• Çok kolay bakım
• Çilek çoğalır

3. CROTON:
• Tropikal renk patlaması
• Çok güneş ister
• Sıcak hava sever

4. RED AGLAONEMA:
• Düşük ışıkta yaşar
• Kolay bakım
• Hava temizler

5. CALATHEA:
• Altı mor yapraklar
• Yüksek nem
• Dolaylı ışık

💡 NOT:
Kırmızı yaprak = daha çok ışık ihtiyacı!",
                Category = "Dekorasyon",
                ImageName = "flower.png",
                ReadTimeMinutes = 3
            },
            new PlantArticle
            {
                Id = 43,
                Title = "Saksı Seçim Rehberi",
                ShortTip = "🪴 Doğru saksı\nsağlıklı bitki!",
                Summary = "Plastik, seramik, terracotta: Hangi saksı hangı bitki için?",
                FullContent = @"Saksı seçimi bitkiye göre değişir!

🪴 SAKSI TÜRLERİ:

TERRACOTTA (Pişmiş Toprak):
• Nefes alır
• Hızlı kurur
• Kaktüs, sukulent için ideal
• Ağır ve kırılgan

PLASTİK:
• Hafif
• Nem tutar
• Tropik bitkiler için
• Ucuz ama estetik değil

SERAMİK:
• Dekoratif
• Ağır, dengeli
• Genellikle drenajsız
• İç saksı gerektirir

AHŞAP:
• Doğal görünüm
• Çabuk çürür
• Dış mekan için

📏 BOYUT:
• Mevcut saksıdan 2-3 cm büyük
• Çok büyük = kök çürümesi

🕳️ DRENAJ:
• Mutlaka delik olmalı!
• Alt tabak kullanın",
                Category = "Bakım",
                ImageName = "succulent.png",
                ReadTimeMinutes = 3
            },
            new PlantArticle
            {
                Id = 44,
                Title = "Toprak Karışımları",
                ShortTip = "🌱 Her bitki farklı\ntoprak ister!",
                Summary = "Farklı bitki türleri için ideal toprak karışımları nasıl hazırlanır?",
                FullContent = @"Toprak, bitkinin evidir!

🌱 TEMEL BİLEŞENLER:
• Bahçe toprağı
• Torf (nem tutar)
• Perlit (hava/drenaj)
• Kum (drenaj)

🌵 KAKTÜS/SUKULENT:
• %50 kum
• %30 perlit
• %20 torf
• Hızlı kuruyan

🌿 TROPİK BİTKİLER:
• %40 torf
• %30 perlit
• %30 toprak
• Nemli ama drene

🌸 ORKİDELER:
• Kabuk
• Kömür
• Sfagnum yosunu
• Toprak YOK!

🌳 GENEL AMAÇLI:
• %40 bahçe toprağı
• %30 torf
• %30 perlit

💡 İPUCU:
Hazır karışımlar kolaylık sağlar!",
                Category = "Bakım",
                ImageName = "herbs.png",
                ReadTimeMinutes = 4
            },
            new PlantArticle
            {
                Id = 45,
                Title = "Bitkilerde Mantar Hastalıkları",
                ShortTip = "🍄 Küf görürsen\nhemen müdahale et!",
                Summary = "Ev bitkilerinde yaygın görülen mantar hastalıkları ve tedavisi.",
                FullContent = @"Mantar hastalıkları yaygın ama tedavi edilebilir!

🍄 YAYGIN HASTALIKLAR:

1. KÖK ÇÜRÜMESİ:
• Neden: Aşırı sulama
• Belirti: Yumuşak kök, koku
• Tedavi: Hasta kökleri kesin, kuru toprağa

2. KÜLLEME:
• Belirti: Beyaz toz
• Tedavi: Fungusit, hava sirkülasyonu

3. PAS HASTALIĞI:
• Belirti: Turuncu lekeler
• Tedavi: Hasta yaprakları kesin

4. TOPRAK KÜFLENMESİ:
• Belirti: Beyaz tabaka
• Tedavi: Üst toprağı değiştin

🛡️ ÖNLEME:
• Aşırı sulamayın
• Hava sirkülasyonu sağlayın
• Yaprakları kuru tutun
• Hasta bitkileri izole edin",
                Category = "Hastalık",
                ImageName = "fern.png",
                ReadTimeMinutes = 4
            },
            new PlantArticle
            {
                Id = 46,
                Title = "Yaprak Bölme ile Çoğaltma",
                ShortTip = "✂️ Tek yapraktan\nbitki üret!",
                Summary = "Yaprak kesimi ile bitki çoğaltma: Hangi bitkiler, nasıl yapılır?",
                FullContent = @"Yaprak çoğaltma sihir gibi!

✂️ UYGUN BİTKİLER:
• Sukulent
• Afrika menekşesi
• Begonia (rex)
• Peperomia
• Yılan bitkisi

🌿 SUKULENT YÖNTEMİ:
1. Sağlıklı yaprak koparın
2. 2-3 gün kurumasını bekleyin
3. Kuru toprağa yatırın
4. Hafif nemlendirin
5. 2-4 hafta bekleyin

🌸 AFRİKA MENEKŞESİ:
1. Saplı yaprak kesin
2. Suya koyun
3. Kök çıkınca toprağa

🐍 YILAN BİTKİSİ:
1. Yaprağı parçalara bölün
2. Üst işareti unuttmayın!
3. Toprağa dikin
4. Çok yavaş (aylar)

⚠️ SABIR GEREKLİ!
Haftalarca bekleyebilirsiniz.",
                Category = "Çoğaltma",
                ImageName = "succulent.png",
                ReadTimeMinutes = 4
            },
            new PlantArticle
            {
                Id = 47,
                Title = "Ofiste Bitki Bakımı",
                ShortTip = "🏢 Ofis bitkileri\nstresi azaltır!",
                Summary = "Ofisinizi yeşillendirmek için en iyi bitkiler ve bakım ipuçları.",
                FullContent = @"Ofis yeşillensin!

🏢 OFİS İÇİN İDEAL BİTKİLER:
• Pothos (kolay)
• ZZ Plant (ölümsüz)
• Yılan bitkisi (az bakım)
• Barış zambağı (hava temizler)
• Bambu (şans)

💡 OFİS AVANTAJLARI:
• Stres %37 azalır
• Verimlilik %15 artar
• Hasta günleri azalır
• Yaratıcılık artar

⚠️ OFİS ZORLUKLARI:
• Klima/havalandırma
• Floresan ışık
• Hafta sonu bakımsızlık
• Düşük nem

🔧 ÇÖZÜMLER:
• Dayanıklı bitkiler seçin
• Kendini sulayan saksılar
• Cuma günü iyi sulayın
• Klimayadan uzak tutun",
                Category = "Bakım",
                ImageName = "palm.png",
                ReadTimeMinutes = 3
            },
            new PlantArticle
            {
                Id = 48,
                Title = "Bitkiler İçin DIY Gübre",
                ShortTip = "♻️ Mutfak atıkları\ngübreye döner!",
                Summary = "Evde kolayca yapabileceğiniz organik gübre tarifleri.",
                FullContent = @"Atıklarınızı gübreye dönüştürün!

♻️ DIY GÜBRE TARİFLERİ:

1. MUZ KABUĞU SUYU:
• Kabukları suya atın
• 24 saat bekletin
• Suyu kullanın

2. YUMURTA KABUĞU TOZU:
• Ezin, toz haline getirin
• Toprağa karıştırın
• Kalsiyum kaynağı

3. ÇAY/KAHVE TORBASİ:
• Kullanılmış torbaları yırtın
• Toprağa karıştırın
• Azot kaynağı

4. PİRİNÇ SUYU:
• Pirinç yıkama suyunu saklayın
• Doğrudan sulayın
• Büyümeyi hızlandırır

5. SALIK SUYU:
• Akvaryum suyu
• Doğrudan sulayın
• Besin zengini

⚠️ DİKKAT:
Aşırı kullanım zarar verir!",
                Category = "Gübreleme",
                ImageName = "watering_can.png",
                ReadTimeMinutes = 4
            },
            new PlantArticle
            {
                Id = 49,
                Title = "Yapay Işık ile Yetiştirme",
                ShortTip = "💡 Güneş yoksa\nbitki lambası!",
                Summary = "Az güneş alan evlerde bitkileri yapay ışıkla desteklemek.",
                FullContent = @"Güneşsiz evlerde de bitki mümkün!

💡 IŞIK TÜRLERİ:

LED GROW LIGHT:
• En verimli
• Az ısı
• Uzun ömür
• Kırmızı/mavi spektrum

FLORESAN:
• Ucuz
• Geniş alan
• Düşük ışık bitkileri için

FULL SPECTRUM:
• Güneşe en yakın
• Tüm bitkiler için
• Pahalı ama ideal

⏰ KULLANIM:
• Günde 10-12 saat
• 15-30 cm mesafe
• Timer kullanın

🌱 YARARLI DURUMLAR:
• Kuzey pencere
• Kış ayları
• Bodrum/iç mekan
• Fide yetiştirme",
                Category = "Bakım",
                ImageName = "flower.png",
                ReadTimeMinutes = 3
            },
            new PlantArticle
            {
                Id = 50,
                Title = "Tatilde Bitki Bakımı",
                ShortTip = "✈️ Tatile giderken\nbitkileri hazırla!",
                Summary = "Uzun süre evden uzak kalırken bitkilerinizi nasıl korursunuz?",
                FullContent = @"Tatil öncesi bitki hazırlığı!

✈️ KISA TATİL (1-2 hafta):

• Işık günü sulayn
• Gölgeye alın (az buharlaşma)
• Grup halinde koyun (nem)
• Banyoya taşıyın (nemli)

🏖️ UZUN TATİL (2-4 hafta):

1. OTOMATİK SULAMA:
• Fitil sistemi
• Su şişesi ters çevirmeli
• Seramik koni

2. ARKADAŞ/KOMŞU:
• Sulama talimatı verin
• Basit tutun

3. HAZIRLIK:
• Çiçekleri koparın
• Gübrelemyin
• Zararlı kontrolü

⚠️ DÖNÜŞTE:
• Hemen güneşe koymayın
• Yavaş yavaş alıştırın
• Sarı yaprakları kesin",
                Category = "Bakım",
                ImageName = "watering_can.png",
                ReadTimeMinutes = 4
            }
        };
    }

    /// <summary>
    /// Makale modeli
    /// </summary>
    public class PlantArticle
    {
        public int Id { get; set; }
        public string Title { get; set; } = "";
        public string ShortTip { get; set; } = "";
        public string Summary { get; set; } = "";
        public string FullContent { get; set; } = "";
        public string Category { get; set; } = "";
        public string ImageName { get; set; } = "";
        public int ReadTimeMinutes { get; set; } = 2;
    }
}
