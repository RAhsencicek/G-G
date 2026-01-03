namespace GreenGuard.Models
{
    /// <summary>
    /// Bitki türü bilgilerini tutan sınıf (50+ önceden tanımlı tür)
    /// </summary>
    public class PlantType
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;           // Örn: "Orkide"
        public string ScientificName { get; set; } = string.Empty; // Örn: "Orchidaceae"
        public string Category { get; set; } = string.Empty;       // İç mekan, Dış mekan, Sebze, Çiçek
        
        // Optimal bakım değerleri
        public int OptimalWateringDays { get; set; }    // Kaç günde bir sulanmalı
        public int OptimalFertilizingDays { get; set; } // Kaç günde bir gübrelenmeli
        public int OptimalPruningDays { get; set; }     // Kaç günde bir budanmalı
        public string SunlightNeed { get; set; } = string.Empty;   // Az, Orta, Çok
        public int MinTemperature { get; set; }         // Minimum sıcaklık (°C)
        public int MaxTemperature { get; set; }         // Maksimum sıcaklık (°C)
        public string Description { get; set; } = string.Empty;    // Açıklama
        
        // Navigation property
        public virtual ICollection<Plant> Plants { get; set; } = new List<Plant>();
    }
}
