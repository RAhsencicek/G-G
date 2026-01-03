using GreenGuard.Data;
using GreenGuard.Models;
using Microsoft.EntityFrameworkCore;

namespace GreenGuard.Services
{
    /// <summary>
    /// Hatırlatma yönetim servisi
    /// - Otomatik hatırlatma oluşturma (2 gün önceden)
    /// - Kullanıcı notları yönetimi
    /// - Tamamlanan hatırlatmaları temizleme (5 gün sonra)
    /// </summary>
    public class ReminderService
    {
        private readonly GreenGuardDbContext _context;
        private readonly HealthAnalyzerService _healthAnalyzer;
        
        // Kaç gün önceden hatırlatma gösterilsin (0 = hemen göster)
        private const int REMINDER_DAYS_BEFORE = 7;
        
        // Tamamlanan hatırlatmalar kaç gün sonra silinsin
        private const int DELETE_COMPLETED_AFTER_DAYS = 5;
        
        // Yeni bitki için kaç gün içinde ilk bakım hatırlatması gösterilsin
        private const int NEW_PLANT_REMINDER_DAYS = 7;
        
        public ReminderService(GreenGuardDbContext context)
        {
            _context = context;
            _healthAnalyzer = new HealthAnalyzerService();
        }
        
        /// <summary>
        /// Kullanıcının tüm aktif hatırlatmalarını getirir (otomatik + manuel)
        /// </summary>
        public async Task<List<UserReminder>> GetActiveRemindersAsync(int userId)
        {
            // Önce eski tamamlanan hatırlatmaları temizle
            await CleanupCompletedRemindersAsync(userId);
            
            // Otomatik hatırlatmaları güncelle
            await GenerateAutoRemindersAsync(userId);
            
            // Tüm hatırlatmaları getir
            var reminders = await _context.UserReminders
                .Include(r => r.Plant)
                .ThenInclude(p => p!.PlantType)
                .Where(r => r.UserId == userId)
                .OrderBy(r => r.IsCompleted)
                .ThenByDescending(r => r.Priority)
                .ThenBy(r => r.DueDate ?? DateTime.MaxValue)
                .ToListAsync();
            
            return reminders;
        }
        
        /// <summary>
        /// Dashboard için özet hatırlatmalar (sadece ilk 5-6 tane)
        /// </summary>
        public async Task<List<UserReminder>> GetSummaryRemindersAsync(int userId, int count = 6)
        {
            var all = await GetActiveRemindersAsync(userId);
            
            // Önce tamamlanmamış olanlar, sonra tamamlananlar
            var uncompleted = all.Where(r => !r.IsCompleted).Take(count - 1).ToList();
            var completed = all.Where(r => r.IsCompleted).Take(1).ToList();
            
            return uncompleted.Concat(completed).ToList();
        }
        
        /// <summary>
        /// Otomatik hatırlatmaları oluşturur/günceller
        /// </summary>
        public async Task GenerateAutoRemindersAsync(int userId)
        {
            // Kullanıcının bitkilerini getir
            var plants = await _context.Plants
                .Include(p => p.PlantType)
                .Where(p => p.UserId == userId)
                .ToListAsync();
            
            foreach (var plant in plants)
            {
                if (plant.PlantType == null) continue;
                
                // Sulama hatırlatması kontrol et
                await CheckAndCreateWateringReminderAsync(userId, plant);
                
                // Gübreleme hatırlatması kontrol et
                await CheckAndCreateFertilizingReminderAsync(userId, plant);
                
                // Budama hatırlatması kontrol et
                await CheckAndCreatePruningReminderAsync(userId, plant);
            }
            
            await _context.SaveChangesAsync();
        }
        
        /// <summary>
        /// Sulama hatırlatması oluştur/güncelle
        /// </summary>
        private async Task CheckAndCreateWateringReminderAsync(int userId, Plant plant)
        {
            if (plant.PlantType == null) return;
            
            // Son sulama tarihinden itibaren kaç gün geçti?
            DateTime lastWatered = plant.LastWateredDate ?? plant.CreatedAt;
            int daysSinceWatering = (DateTime.Now - lastWatered).Days;
            int optimalDays = plant.PlantType.OptimalWateringDays;
            int daysUntilWatering = optimalDays - daysSinceWatering;
            
            // 2 gün önceden hatırlatma başlasın
            bool shouldRemind = daysUntilWatering <= REMINDER_DAYS_BEFORE;
            
            // Mevcut hatırlatma var mı?
            var existingReminder = await _context.UserReminders
                .FirstOrDefaultAsync(r => 
                    r.UserId == userId && 
                    r.PlantId == plant.Id && 
                    r.Type == ReminderType.Watering &&
                    !r.IsCompleted);
            
            if (shouldRemind)
            {
                // Öncelik belirle
                ReminderPriority priority;
                string title;
                
                if (daysUntilWatering <= 0)
                {
                    priority = ReminderPriority.Urgent;
                    title = $"💧 {plant.Name} - Sulanmalı!";
                }
                else
                {
                    priority = ReminderPriority.Upcoming;
                    title = $"💧 {plant.Name} - {daysUntilWatering} gün kaldı";
                }
                
                if (existingReminder != null)
                {
                    // Güncelle
                    existingReminder.Title = title;
                    existingReminder.Priority = priority;
                    existingReminder.DueDate = lastWatered.AddDays(optimalDays);
                }
                else
                {
                    // Yeni oluştur
                    var reminder = new UserReminder
                    {
                        UserId = userId,
                        PlantId = plant.Id,
                        Type = ReminderType.Watering,
                        Title = title,
                        Description = $"{plant.PlantType.Name} türü bitkiler {optimalDays} günde bir sulanmalı.",
                        Priority = priority,
                        DueDate = lastWatered.AddDays(optimalDays),
                        IsAutoGenerated = true,
                        CreatedAt = DateTime.Now
                    };
                    _context.UserReminders.Add(reminder);
                }
            }
            else if (existingReminder != null)
            {
                // Henüz zamanı gelmedi, hatırlatmayı sil
                _context.UserReminders.Remove(existingReminder);
            }
        }
        
        /// <summary>
        /// Gübreleme hatırlatması oluştur/güncelle
        /// </summary>
        private async Task CheckAndCreateFertilizingReminderAsync(int userId, Plant plant)
        {
            if (plant.PlantType == null) return;
            
            DateTime lastFertilized = plant.LastFertilizedDate ?? plant.CreatedAt;
            int daysSinceFertilizing = (DateTime.Now - lastFertilized).Days;
            int optimalDays = plant.PlantType.OptimalFertilizingDays;
            int daysUntilFertilizing = optimalDays - daysSinceFertilizing;
            
            bool shouldRemind = daysUntilFertilizing <= REMINDER_DAYS_BEFORE;
            
            var existingReminder = await _context.UserReminders
                .FirstOrDefaultAsync(r => 
                    r.UserId == userId && 
                    r.PlantId == plant.Id && 
                    r.Type == ReminderType.Fertilizing &&
                    !r.IsCompleted);
            
            if (shouldRemind)
            {
                ReminderPriority priority;
                string title;
                
                if (daysUntilFertilizing <= 0)
                {
                    priority = ReminderPriority.Urgent;
                    title = $"🌱 {plant.Name} - Gübre zamanı!";
                }
                else
                {
                    priority = ReminderPriority.Upcoming;
                    title = $"🌱 {plant.Name} - Gübre {daysUntilFertilizing} gün sonra";
                }
                
                if (existingReminder != null)
                {
                    existingReminder.Title = title;
                    existingReminder.Priority = priority;
                    existingReminder.DueDate = lastFertilized.AddDays(optimalDays);
                }
                else
                {
                    var reminder = new UserReminder
                    {
                        UserId = userId,
                        PlantId = plant.Id,
                        Type = ReminderType.Fertilizing,
                        Title = title,
                        Description = $"{plant.PlantType.Name} türü bitkiler {optimalDays} günde bir gübrelenmelidir.",
                        Priority = priority,
                        DueDate = lastFertilized.AddDays(optimalDays),
                        IsAutoGenerated = true,
                        CreatedAt = DateTime.Now
                    };
                    _context.UserReminders.Add(reminder);
                }
            }
            else if (existingReminder != null)
            {
                _context.UserReminders.Remove(existingReminder);
            }
        }
        
        /// <summary>
        /// Budama hatırlatması oluştur/güncelle
        /// </summary>
        private async Task CheckAndCreatePruningReminderAsync(int userId, Plant plant)
        {
            if (plant.PlantType == null) return;
            
            // Budama günü 0 ise bu bitki için budama gerekmiyor
            if (plant.PlantType.OptimalPruningDays <= 0) return;
            
            DateTime lastPruned = plant.LastPrunedDate ?? plant.CreatedAt;
            int daysSincePruning = (DateTime.Now - lastPruned).Days;
            int optimalDays = plant.PlantType.OptimalPruningDays;
            int daysUntilPruning = optimalDays - daysSincePruning;
            
            bool shouldRemind = daysUntilPruning <= REMINDER_DAYS_BEFORE;
            
            var existingReminder = await _context.UserReminders
                .FirstOrDefaultAsync(r => 
                    r.UserId == userId && 
                    r.PlantId == plant.Id && 
                    r.Type == ReminderType.Pruning &&
                    !r.IsCompleted);
            
            if (shouldRemind)
            {
                ReminderPriority priority;
                string title;
                
                if (daysUntilPruning <= 0)
                {
                    priority = ReminderPriority.Urgent;
                    title = $"✂️ {plant.Name} - Budama zamanı!";
                }
                else if (daysUntilPruning <= 3)
                {
                    priority = ReminderPriority.Upcoming;
                    title = $"✂️ {plant.Name} - Budama {daysUntilPruning} gün sonra";
                }
                else
                {
                    priority = ReminderPriority.Normal;
                    title = $"✂️ {plant.Name} - Budama {daysUntilPruning} gün sonra";
                }
                
                if (existingReminder != null)
                {
                    existingReminder.Title = title;
                    existingReminder.Priority = priority;
                    existingReminder.DueDate = lastPruned.AddDays(optimalDays);
                }
                else
                {
                    var reminder = new UserReminder
                    {
                        UserId = userId,
                        PlantId = plant.Id,
                        Type = ReminderType.Pruning,
                        Title = title,
                        Description = $"{plant.PlantType.Name} türü bitkiler {optimalDays} günde bir budanmalıdır.",
                        Priority = priority,
                        DueDate = lastPruned.AddDays(optimalDays),
                        IsAutoGenerated = true,
                        CreatedAt = DateTime.Now
                    };
                    _context.UserReminders.Add(reminder);
                }
            }
            else if (existingReminder != null)
            {
                _context.UserReminders.Remove(existingReminder);
            }
        }
        
        /// <summary>
        /// Kullanıcı notu ekler
        /// </summary>
        public async Task<UserReminder> AddUserNoteAsync(int userId, string title, string? description = null, DateTime? dueDate = null, int? plantId = null)
        {
            var reminder = new UserReminder
            {
                UserId = userId,
                PlantId = plantId,
                Type = ReminderType.UserNote,
                Title = $"📝 {title}",
                Description = description,
                DueDate = dueDate,
                Priority = dueDate.HasValue && dueDate.Value <= DateTime.Now.AddDays(REMINDER_DAYS_BEFORE) 
                    ? ReminderPriority.Upcoming 
                    : ReminderPriority.Normal,
                IsAutoGenerated = false,
                CreatedAt = DateTime.Now
            };
            
            _context.UserReminders.Add(reminder);
            await _context.SaveChangesAsync();
            
            return reminder;
        }
        
        /// <summary>
        /// Hatırlatmayı tamamlandı olarak işaretle
        /// </summary>
        public async Task MarkAsCompletedAsync(int reminderId)
        {
            var reminder = await _context.UserReminders.FindAsync(reminderId);
            if (reminder != null)
            {
                reminder.IsCompleted = true;
                reminder.CompletedAt = DateTime.Now;
                await _context.SaveChangesAsync();
            }
        }
        
        /// <summary>
        /// Hatırlatmayı tamamlanmadı olarak işaretle
        /// </summary>
        public async Task MarkAsUncompletedAsync(int reminderId)
        {
            var reminder = await _context.UserReminders.FindAsync(reminderId);
            if (reminder != null)
            {
                reminder.IsCompleted = false;
                reminder.CompletedAt = null;
                await _context.SaveChangesAsync();
            }
        }
        
        /// <summary>
        /// Hatırlatmayı siler
        /// </summary>
        public async Task DeleteReminderAsync(int reminderId)
        {
            var reminder = await _context.UserReminders.FindAsync(reminderId);
            if (reminder != null)
            {
                _context.UserReminders.Remove(reminder);
                await _context.SaveChangesAsync();
            }
        }
        
        /// <summary>
        /// 5 günden eski tamamlanmış hatırlatmaları temizler
        /// </summary>
        private async Task CleanupCompletedRemindersAsync(int userId)
        {
            var cutoffDate = DateTime.Now.AddDays(-DELETE_COMPLETED_AFTER_DAYS);
            
            var oldReminders = await _context.UserReminders
                .Where(r => r.UserId == userId && 
                           r.IsCompleted && 
                           r.CompletedAt.HasValue && 
                           r.CompletedAt.Value < cutoffDate)
                .ToListAsync();
            
            if (oldReminders.Any())
            {
                _context.UserReminders.RemoveRange(oldReminders);
                await _context.SaveChangesAsync();
            }
        }
        
        /// <summary>
        /// Belirli bir bitkinin bakım yapıldığında hatırlatmasını sil
        /// </summary>
        public async Task OnPlantCaredAsync(int plantId, ReminderType careType)
        {
            var reminder = await _context.UserReminders
                .FirstOrDefaultAsync(r => r.PlantId == plantId && r.Type == careType && !r.IsCompleted);
            
            if (reminder != null)
            {
                // Tamamlandı olarak işaretle, böylece üstü çizili görünür
                reminder.IsCompleted = true;
                reminder.CompletedAt = DateTime.Now;
                await _context.SaveChangesAsync();
            }
        }
    }
}
