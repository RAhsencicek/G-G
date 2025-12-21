using System.Security.Cryptography;
using System.Text;
using GreenGuard.Data;
using GreenGuard.Models;
using Microsoft.EntityFrameworkCore;

namespace GreenGuard.Services
{
    /// <summary>
    /// Kullanıcı kimlik doğrulama servisi
    /// </summary>
    public class AuthService
    {
        private readonly GreenGuardDbContext _context;
        
        // Giriş yapan kullanıcı
        public static User? CurrentUser { get; internal set; }
        
        public AuthService(GreenGuardDbContext context)
        {
            _context = context;
        }
        
        /// <summary>
        /// Kullanıcı girişi yapar
        /// </summary>
        public async Task<(bool Success, string Message)> LoginAsync(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                return (false, "Kullanıcı adı ve şifre boş olamaz.");
            }
            
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Username.ToLower() == username.ToLower());
            
            if (user == null)
            {
                return (false, "Kullanıcı bulunamadı.");
            }
            
            string passwordHash = HashPassword(password);
            if (user.PasswordHash != passwordHash)
            {
                return (false, "Şifre hatalı.");
            }
            
            // Giriş başarılı
            user.LastLoginAt = DateTime.Now;
            await _context.SaveChangesAsync();
            
            CurrentUser = user;
            return (true, "Giriş başarılı!");
        }
        
        /// <summary>
        /// Yeni kullanıcı kaydı yapar
        /// </summary>
        public async Task<(bool Success, string Message)> RegisterAsync(string username, string email, string password, string fullName)
        {
            // Validasyonlar
            if (string.IsNullOrWhiteSpace(username) || username.Length < 3)
            {
                return (false, "Kullanıcı adı en az 3 karakter olmalıdır.");
            }
            
            if (string.IsNullOrWhiteSpace(password) || password.Length < 4)
            {
                return (false, "Şifre en az 4 karakter olmalıdır.");
            }
            
            if (string.IsNullOrWhiteSpace(email) || !email.Contains("@"))
            {
                return (false, "Geçerli bir e-posta adresi giriniz.");
            }
            
            // Kullanıcı adı kontrolü
            var existingUser = await _context.Users
                .FirstOrDefaultAsync(u => u.Username.ToLower() == username.ToLower());
            
            if (existingUser != null)
            {
                return (false, "Bu kullanıcı adı zaten kullanılıyor.");
            }
            
            // E-posta kontrolü
            var existingEmail = await _context.Users
                .FirstOrDefaultAsync(u => u.Email.ToLower() == email.ToLower());
            
            if (existingEmail != null)
            {
                return (false, "Bu e-posta adresi zaten kullanılıyor.");
            }
            
            // Yeni kullanıcı oluştur
            var newUser = new User
            {
                Username = username,
                Email = email,
                PasswordHash = HashPassword(password),
                FullName = fullName,
                CreatedAt = DateTime.Now
            };
            
            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();
            
            return (true, "Kayıt başarılı! Şimdi giriş yapabilirsiniz.");
        }
        
        /// <summary>
        /// Çıkış yapar
        /// </summary>
        public void Logout()
        {
            CurrentUser = null;
        }
        
        /// <summary>
        /// Şifreyi hash'ler (SHA256)
        /// </summary>
        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password + "GreenGuardSalt"));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
