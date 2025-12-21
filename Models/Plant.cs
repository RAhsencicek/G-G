namespace GreenGuard.Models
{
    /// <summary>
    /// Kullanıcının bitkisini temsil eden sınıf
    /// </summary>
    public class Plant
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;           // Kullanıcının verdiği isim
        public string? Nickname { get; set; }                      // Takma ad (opsiyonel)
        public string Location { get; set; } = string.Empty;       // Konum (örn: "Salon", "Balkon")
        public string? PhotoPath { get; set; }                     // Fotoğraf dosya yolu
        public string? Notes { get; set; }                         // Notlar
        public DateTime AcquiredDate { get; set; }                 // Alınma tarihi
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        
        // Bakım bilgileri
        public DateTime? LastWateredDate { get; set; }
        public DateTime? LastFertilizedDate { get; set; }
        public DateTime? LastPrunedDate { get; set; }
        
        // Hesaplanan sağlık skoru (0-100)
        public int HealthScore { get; set; } = 100;
        
        // Foreign Keys
        public int UserId { get; set; }
        public int PlantTypeId { get; set; }
        
        // Dashboard slot numarası (1-14)
        public int? SlotNumber { get; set; }
        
        // Navigation Properties
        public virtual User? User { get; set; }
        public virtual PlantType? PlantType { get; set; }
        public virtual ICollection<CareLog> CareLogs { get; set; } = new List<CareLog>();
    }
}
