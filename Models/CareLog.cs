namespace GreenGuard.Models
{
    /// <summary>
    /// Bakım türlerini tanımlayan enum
    /// </summary>
    public enum CareType
    {
        Watering,       // Sulama
        Fertilizing,    // Gübreleme
        Pruning,        // Budama
        Repotting,      // Saksı değiştirme
        Other           // Diğer
    }
    
    /// <summary>
    /// Bakım kaydını tutan sınıf
    /// </summary>
    public class CareLog
    {
        public int Id { get; set; }
        public CareType CareType { get; set; }          // Bakım türü
        public DateTime CareDate { get; set; }          // Bakım tarihi
        public string? Notes { get; set; }              // Notlar
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        
        // Foreign Key
        public int PlantId { get; set; }
        
        // Navigation Property
        public virtual Plant? Plant { get; set; }
    }
}
