namespace GreenGuard.Models
{
    /// <summary>
    /// Kullanıcı bilgilerini tutan sınıf
    /// </summary>
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? LastLoginAt { get; set; }
        
        // Navigation property - Kullanıcının bitkileri
        public virtual ICollection<Plant> Plants { get; set; } = new List<Plant>();
    }
}
