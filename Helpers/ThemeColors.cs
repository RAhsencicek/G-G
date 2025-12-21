using System.Drawing;

namespace GreenGuard.Helpers
{
    /// <summary>
    /// GreenGuard tema renkleri - Pastel yeşil tonları
    /// IkigotchiGarden'dan ilham alınarak oluşturuldu
    /// </summary>
    public static class ThemeColors
    {
        // === ANA RENKLER ===
        
        /// <summary>Soft Sage - Ana renk, navigasyon arka planı</summary>
        public static Color SoftSage => Color.FromArgb(143, 188, 143);
        
        /// <summary>Mint Cream - İçerik arka planı</summary>
        public static Color MintCream => Color.FromArgb(245, 255, 250);
        
        /// <summary>Tea Green - Kartlar ve hover durumları</summary>
        public static Color TeaGreen => Color.FromArgb(208, 240, 192);
        
        /// <summary>Celadon - Buton arka planları</summary>
        public static Color Celadon => Color.FromArgb(172, 225, 175);
        
        /// <summary>Hunter Green - Yazı ve vurgular</summary>
        public static Color HunterGreen => Color.FromArgb(53, 94, 59);
        
        // === KART RENKLERİ ===
        
        /// <summary>Toplam bitki kartı - Soft Sage</summary>
        public static Color CardTotal => SoftSage;
        
        /// <summary>Sağlıklı bitki kartı - Tea Green</summary>
        public static Color CardHealthy => TeaGreen;
        
        /// <summary>Dikkat kartı - Pastel Yellow</summary>
        public static Color CardAttention => Color.FromArgb(255, 250, 205);
        
        /// <summary>Kritik kartı - Soft Coral</summary>
        public static Color CardCritical => Color.FromArgb(244, 164, 164);
        
        // === NAVİGASYON RENKLERİ ===
        
        /// <summary>Navigasyon arka planı</summary>
        public static Color NavBackground => Color.FromArgb(240, 248, 240); // Hafif yeşilimsi beyaz
        
        /// <summary>Navigasyon aktif öğe</summary>
        public static Color NavActive => Celadon;
        
        /// <summary>Navigasyon hover</summary>
        public static Color NavHover => TeaGreen;
        
        /// <summary>Navigasyon metin</summary>
        public static Color NavText => HunterGreen;
        
        // === YARDIMCI RENKLER ===
        
        /// <summary>Genel arka plan</summary>
        public static Color Background => MintCream;
        
        /// <summary>Başlık metni</summary>
        public static Color TitleText => HunterGreen;
        
        /// <summary>Normal metin</summary>
        public static Color BodyText => Color.FromArgb(70, 100, 70);
        
        /// <summary>Border rengi</summary>
        public static Color Border => Color.FromArgb(200, 220, 200);
        
        /// <summary>Gölge rengi</summary>
        public static Color Shadow => Color.FromArgb(30, 0, 50, 0);
    }
}
