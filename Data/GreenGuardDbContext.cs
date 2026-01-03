using Microsoft.EntityFrameworkCore;
using GreenGuard.Models;

namespace GreenGuard.Data
{
    /// <summary>
    /// Entity Framework DbContext - Veritabanı bağlantısı ve tablo tanımlamaları
    /// </summary>
    public class GreenGuardDbContext : DbContext
    {
        // Tablolar
        public DbSet<User> Users { get; set; }
        public DbSet<Plant> Plants { get; set; }
        public DbSet<PlantType> PlantTypes { get; set; }
        public DbSet<CareLog> CareLogs { get; set; }
        public DbSet<UserReminder> UserReminders { get; set; }
        
        // Veritabanı bağlantı ayarları
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // SQL Server LocalDB bağlantı dizesi
            optionsBuilder.UseSqlServer(
                @"Server=(localdb)\MSSQLLocalDB;Database=GreenGuardDB;Trusted_Connection=True;MultipleActiveResultSets=true"
            );
        }
        
        // Tablo ilişkileri ve konfigürasyonları
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            // User - Plant ilişkisi (1'e çok)
            modelBuilder.Entity<Plant>()
                .HasOne(p => p.User)
                .WithMany(u => u.Plants)
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.Cascade);
            
            // PlantType - Plant ilişkisi (1'e çok)
            modelBuilder.Entity<Plant>()
                .HasOne(p => p.PlantType)
                .WithMany(pt => pt.Plants)
                .HasForeignKey(p => p.PlantTypeId)
                .OnDelete(DeleteBehavior.Restrict);
            
            // Plant - CareLog ilişkisi (1'e çok)
            modelBuilder.Entity<CareLog>()
                .HasOne(c => c.Plant)
                .WithMany(p => p.CareLogs)
                .HasForeignKey(c => c.PlantId)
                .OnDelete(DeleteBehavior.Cascade);
            
            // User - UserReminder ilişkisi (1'e çok)
            modelBuilder.Entity<UserReminder>()
                .HasOne(r => r.User)
                .WithMany()
                .HasForeignKey(r => r.UserId)
                .OnDelete(DeleteBehavior.NoAction);
            
            // Plant - UserReminder ilişkisi (1'e çok, opsiyonel)
            modelBuilder.Entity<UserReminder>()
                .HasOne(r => r.Plant)
                .WithMany()
                .HasForeignKey(r => r.PlantId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.NoAction);
            
            // Varsayılan bitki türlerini ekle
            SeedPlantTypes(modelBuilder);
        }
        
        /// <summary>
        /// Varsayılan bitki türlerini veritabanına ekler
        /// </summary>
        private void SeedPlantTypes(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PlantType>().HasData(
                // İç Mekan Bitkileri (Budama: 30-45 gün)
                new PlantType { Id = 1, Name = "Orkide", ScientificName = "Orchidaceae", Category = "İç Mekan", OptimalWateringDays = 7, OptimalFertilizingDays = 30, OptimalPruningDays = 45, SunlightNeed = "Orta", MinTemperature = 15, MaxTemperature = 25, Description = "Zarif çiçekleriyle bilinen popüler iç mekan bitkisi" },
                new PlantType { Id = 2, Name = "Monstera", ScientificName = "Monstera deliciosa", Category = "İç Mekan", OptimalWateringDays = 7, OptimalFertilizingDays = 14, OptimalPruningDays = 30, SunlightNeed = "Orta", MinTemperature = 18, MaxTemperature = 30, Description = "Delikli yapraklarıyla dekoratif tropik bitki" },
                new PlantType { Id = 3, Name = "Kauçuk", ScientificName = "Ficus elastica", Category = "İç Mekan", OptimalWateringDays = 10, OptimalFertilizingDays = 30, OptimalPruningDays = 45, SunlightNeed = "Orta", MinTemperature = 15, MaxTemperature = 30, Description = "Parlak yapraklı dayanıklı iç mekan bitkisi" },
                new PlantType { Id = 4, Name = "Barış Zambağı", ScientificName = "Spathiphyllum", Category = "İç Mekan", OptimalWateringDays = 5, OptimalFertilizingDays = 30, OptimalPruningDays = 30, SunlightNeed = "Az", MinTemperature = 15, MaxTemperature = 25, Description = "Beyaz çiçekleri ve hava temizleme özelliğiyle bilinir" },
                new PlantType { Id = 5, Name = "Yılan Bitkisi", ScientificName = "Sansevieria", Category = "İç Mekan", OptimalWateringDays = 14, OptimalFertilizingDays = 60, OptimalPruningDays = 60, SunlightNeed = "Az", MinTemperature = 10, MaxTemperature = 30, Description = "Çok az bakım gerektiren dayanıklı bitki" },
                new PlantType { Id = 6, Name = "Aloe Vera", ScientificName = "Aloe barbadensis", Category = "İç Mekan", OptimalWateringDays = 14, OptimalFertilizingDays = 60, OptimalPruningDays = 45, SunlightNeed = "Çok", MinTemperature = 10, MaxTemperature = 30, Description = "Şifalı özellikleriyle bilinen sukulent" },
                new PlantType { Id = 7, Name = "Pothos", ScientificName = "Epipremnum aureum", Category = "İç Mekan", OptimalWateringDays = 7, OptimalFertilizingDays = 30, OptimalPruningDays = 30, SunlightNeed = "Az", MinTemperature = 15, MaxTemperature = 30, Description = "Sarkan yapraklarıyla popüler asma bitki" },
                new PlantType { Id = 8, Name = "Kaktüs", ScientificName = "Cactaceae", Category = "İç Mekan", OptimalWateringDays = 21, OptimalFertilizingDays = 60, OptimalPruningDays = 90, SunlightNeed = "Çok", MinTemperature = 10, MaxTemperature = 35, Description = "Az su gerektiren çöl bitkisi" },
                new PlantType { Id = 9, Name = "Zamioculcas", ScientificName = "Zamioculcas zamiifolia", Category = "İç Mekan", OptimalWateringDays = 14, OptimalFertilizingDays = 60, OptimalPruningDays = 60, SunlightNeed = "Az", MinTemperature = 15, MaxTemperature = 30, Description = "Çok az bakım gerektiren şanslı bitki" },
                new PlantType { Id = 10, Name = "Filodendron", ScientificName = "Philodendron", Category = "İç Mekan", OptimalWateringDays = 7, OptimalFertilizingDays = 30, OptimalPruningDays = 30, SunlightNeed = "Orta", MinTemperature = 15, MaxTemperature = 30, Description = "Kalp şeklinde yapraklı popüler bitki" },
                
                // Dış Mekan / Bahçe Bitkileri (Budama: 21-30 gün)
                new PlantType { Id = 11, Name = "Gül", ScientificName = "Rosa", Category = "Dış Mekan", OptimalWateringDays = 3, OptimalFertilizingDays = 14, OptimalPruningDays = 21, SunlightNeed = "Çok", MinTemperature = 5, MaxTemperature = 30, Description = "Güzel kokulu klasik bahçe çiçeği" },
                new PlantType { Id = 12, Name = "Lavanta", ScientificName = "Lavandula", Category = "Dış Mekan", OptimalWateringDays = 7, OptimalFertilizingDays = 30, OptimalPruningDays = 30, SunlightNeed = "Çok", MinTemperature = 5, MaxTemperature = 35, Description = "Hoş kokulu mor çiçekli aromatik bitki" },
                new PlantType { Id = 13, Name = "Ortanca", ScientificName = "Hydrangea", Category = "Dış Mekan", OptimalWateringDays = 3, OptimalFertilizingDays = 14, OptimalPruningDays = 30, SunlightNeed = "Orta", MinTemperature = 5, MaxTemperature = 25, Description = "Büyük çiçek kümeleriyle bilinen çalı" },
                new PlantType { Id = 14, Name = "Sardunya", ScientificName = "Pelargonium", Category = "Dış Mekan", OptimalWateringDays = 3, OptimalFertilizingDays = 14, OptimalPruningDays = 21, SunlightNeed = "Çok", MinTemperature = 10, MaxTemperature = 30, Description = "Renkli çiçekleriyle popüler balkon bitkisi" },
                new PlantType { Id = 15, Name = "Menekşe", ScientificName = "Viola", Category = "Dış Mekan", OptimalWateringDays = 3, OptimalFertilizingDays = 21, OptimalPruningDays = 21, SunlightNeed = "Orta", MinTemperature = 5, MaxTemperature = 20, Description = "Küçük renkli çiçekleri olan kır çiçeği" },
                
                // Sebzeler (Budama: 15 gün)
                new PlantType { Id = 16, Name = "Domates", ScientificName = "Solanum lycopersicum", Category = "Sebze", OptimalWateringDays = 2, OptimalFertilizingDays = 14, OptimalPruningDays = 15, SunlightNeed = "Çok", MinTemperature = 15, MaxTemperature = 35, Description = "Popüler bahçe sebzesi" },
                new PlantType { Id = 17, Name = "Biber", ScientificName = "Capsicum", Category = "Sebze", OptimalWateringDays = 2, OptimalFertilizingDays = 14, OptimalPruningDays = 15, SunlightNeed = "Çok", MinTemperature = 15, MaxTemperature = 35, Description = "Çeşitli boyut ve acılıkta sebze" },
                new PlantType { Id = 18, Name = "Salatalık", ScientificName = "Cucumis sativus", Category = "Sebze", OptimalWateringDays = 2, OptimalFertilizingDays = 14, OptimalPruningDays = 15, SunlightNeed = "Çok", MinTemperature = 15, MaxTemperature = 35, Description = "Serinletici yaz sebzesi" },
                new PlantType { Id = 19, Name = "Marul", ScientificName = "Lactuca sativa", Category = "Sebze", OptimalWateringDays = 2, OptimalFertilizingDays = 21, OptimalPruningDays = 14, SunlightNeed = "Orta", MinTemperature = 10, MaxTemperature = 25, Description = "Yapraklı salata bitkisi" },
                new PlantType { Id = 20, Name = "Havuç", ScientificName = "Daucus carota", Category = "Sebze", OptimalWateringDays = 3, OptimalFertilizingDays = 21, OptimalPruningDays = 21, SunlightNeed = "Çok", MinTemperature = 10, MaxTemperature = 25, Description = "Turuncu köklü sebze" },
                
                // Aromatik Bitkiler (Budama: 21 gün)
                new PlantType { Id = 21, Name = "Fesleğen", ScientificName = "Ocimum basilicum", Category = "Aromatik", OptimalWateringDays = 2, OptimalFertilizingDays = 21, OptimalPruningDays = 14, SunlightNeed = "Çok", MinTemperature = 15, MaxTemperature = 30, Description = "Mutfakta kullanılan aromatik bitki" },
                new PlantType { Id = 22, Name = "Nane", ScientificName = "Mentha", Category = "Aromatik", OptimalWateringDays = 2, OptimalFertilizingDays = 30, OptimalPruningDays = 14, SunlightNeed = "Orta", MinTemperature = 10, MaxTemperature = 25, Description = "Ferahlatıcı kokulu şifalı bitki" },
                new PlantType { Id = 23, Name = "Biberiye", ScientificName = "Rosmarinus officinalis", Category = "Aromatik", OptimalWateringDays = 7, OptimalFertilizingDays = 30, OptimalPruningDays = 21, SunlightNeed = "Çok", MinTemperature = 5, MaxTemperature = 30, Description = "Akdeniz mutfağının vazgeçilmezi" },
                new PlantType { Id = 24, Name = "Kekik", ScientificName = "Thymus vulgaris", Category = "Aromatik", OptimalWateringDays = 7, OptimalFertilizingDays = 30, OptimalPruningDays = 21, SunlightNeed = "Çok", MinTemperature = 5, MaxTemperature = 30, Description = "Yemeklere lezzet katan aromatik bitki" },
                new PlantType { Id = 25, Name = "Maydanoz", ScientificName = "Petroselinum crispum", Category = "Aromatik", OptimalWateringDays = 2, OptimalFertilizingDays = 21, OptimalPruningDays = 14, SunlightNeed = "Orta", MinTemperature = 10, MaxTemperature = 25, Description = "Her yemeğe yakışan yeşillik" }
            );
        }
    }
}
