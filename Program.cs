using GreenGuard.Forms;
using GreenGuard.Data;

namespace GreenGuard
{
    internal static class Program
    {
        /// <summary>
        /// GreenGuard uygulamasının giriş noktası
        /// </summary>
        [STAThread]
        static void Main()
        {
            // DevExpress tema ayarları - Modern koyu tema
            DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle(
                DevExpress.LookAndFeel.SkinStyle.Office2019Black);
            
            // SVG ikonları ve yüksek DPI desteği
            DevExpress.Utils.AppearanceObject.DefaultFont = new System.Drawing.Font("Segoe UI", 10F);
            
            // Veritabanını kontrol et/oluştur
            using (var context = new GreenGuardDbContext())
            {
                context.Database.EnsureCreated();
            }
            
            ApplicationConfiguration.Initialize();
            Application.Run(new LoginForm());
        }
    }
}
