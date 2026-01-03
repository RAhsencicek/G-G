using GreenGuard.Data;
using GreenGuard.Models;
using GreenGuard.Services;
using Microsoft.EntityFrameworkCore;

namespace GreenGuard.Helpers
{
    /// <summary>
    /// Test için örnek bitkiler oluşturur
    /// </summary>
    public static class SamplePlantSeeder
    {
        private static readonly Random _random = new();

        /// <summary>
        /// Mevcut kullanıcı için örnek bitkiler oluşturur
        /// </summary>
        public static async Task SeedSamplePlantsAsync(GreenGuardDbContext context)
        {
            if (AuthService.CurrentUser == null) return;

            var userId = AuthService.CurrentUser.Id;

            // Zaten bitki varsa ekleme
            var existingCount = context.Plants.Count(p => p.UserId == userId);
            if (existingCount >= 5) return;

            var plantTypes = context.PlantTypes.ToList();
            if (plantTypes.Count == 0) return;

            var samplePlants = new List<Plant>
            {
                // Dashboard slotlarına atanacak bitkiler (1-8)
                CreatePlant("Monstera", "Yeşil Dev", "Salon", plantTypes, 2, userId, 1, -3, -10, -20),
                CreatePlant("Orkide", "Prenses", "Yatak Odası", plantTypes, 1, userId, 2, -5, -25, -40),
                CreatePlant("Kaktüs", "Dikenci", "Çalışma Odası", plantTypes, 8, userId, 3, -15, -50, null),
                CreatePlant("Aloe Vera", "Şifacı", "Mutfak", plantTypes, 6, userId, 4, -10, -45, -30),
                CreatePlant("Pothos", "Sarmaşık", "Balkon", plantTypes, 7, userId, 5, 0, -20, -25),
                CreatePlant("Barış Zambağı", "Huzur", "Oturma Odası", plantTypes, 4, userId, 6, -2, -15, -28),
                CreatePlant("Fesleğen", "Lezzetli", "Mutfak", plantTypes, 21, userId, 7, 0, -18, -10),
                CreatePlant("Domates", "Kırmızı", "Balkon", plantTypes, 16, userId, 8, -1, -12, -8),
                
                // Dashboard'da olmayan ama listede görünecek bitkiler
                CreatePlant("Gül", "Romantik", "Bahçe", plantTypes, 11, userId, null, -2, -10, -15),
                CreatePlant("Lavanta", "Mor Hayal", "Balkon", plantTypes, 12, userId, null, -5, -20, -25),
                CreatePlant("Nane", "Ferah", "Mutfak", plantTypes, 22, userId, null, 0, -25, -12),
                CreatePlant("Filodendron", "Kalp", "Salon", plantTypes, 10, userId, null, -4, -22, -18),
                CreatePlant("Yılan Bitkisi", "Koruyucu", "Koridor", plantTypes, 5, userId, null, -8, -40, null),
                CreatePlant("Biberiye", "Kokulu", "Mutfak", plantTypes, 23, userId, null, -6, -28, -20),
            };

            context.Plants.AddRange(samplePlants);
            await context.SaveChangesAsync();
        }

        private static Plant CreatePlant(
            string name, 
            string nickname, 
            string location, 
            List<PlantType> plantTypes, 
            int plantTypeId, 
            int userId, 
            int? slotNumber,
            int waterDaysAgo,
            int fertilizeDaysAgo,
            int? pruneDaysAgo)
        {
            var now = DateTime.Now;
            var acquiredDaysAgo = _random.Next(30, 180);

            return new Plant
            {
                Name = name,
                Nickname = nickname,
                Location = location,
                PlantTypeId = plantTypeId,
                UserId = userId,
                SlotNumber = slotNumber,
                AcquiredDate = now.AddDays(-acquiredDaysAgo),
                CreatedAt = now.AddDays(-acquiredDaysAgo),
                LastWateredDate = now.AddDays(waterDaysAgo),
                LastFertilizedDate = now.AddDays(fertilizeDaysAgo),
                LastPrunedDate = pruneDaysAgo.HasValue ? now.AddDays(pruneDaysAgo.Value) : null,
                HealthScore = 100
            };
        }

        /// <summary>
        /// Dashboard'da bekleyen bakım sayısını hesaplar
        /// </summary>
        public static int GetPendingCareCount(GreenGuardDbContext context)
        {
            if (AuthService.CurrentUser == null) return 0;

            var userId = AuthService.CurrentUser.Id;
            var today = DateTime.Today;
            int count = 0;

            var plants = context.Plants
                .Where(p => p.UserId == userId)
                .Include(p => p.PlantType)
                .ToList();

            foreach (var plant in plants)
            {
                if (plant.PlantType == null) continue;

                // Sulama kontrolü
                if (plant.LastWateredDate.HasValue)
                {
                    var nextWater = plant.LastWateredDate.Value.AddDays(plant.PlantType.OptimalWateringDays);
                    if (nextWater.Date <= today) count++;
                }
                else
                {
                    count++; // Hiç sulanmadıysa
                }

                // Gübreleme kontrolü
                if (plant.LastFertilizedDate.HasValue)
                {
                    var nextFertilize = plant.LastFertilizedDate.Value.AddDays(plant.PlantType.OptimalFertilizingDays);
                    if (nextFertilize.Date <= today) count++;
                }

                // Budama kontrolü
                if (plant.PlantType.OptimalPruningDays > 0)
                {
                    if (plant.LastPrunedDate.HasValue)
                    {
                        var nextPrune = plant.LastPrunedDate.Value.AddDays(plant.PlantType.OptimalPruningDays);
                        if (nextPrune.Date <= today) count++;
                    }
                }
            }

            return count;
        }
    }
}
