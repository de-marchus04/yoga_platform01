using System;
using System.ComponentModel.DataAnnotations;

namespace Yoga.Shared.Models
{
    public class Lead
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required(ErrorMessage = "Имя обязательно для заполнения.")]
        [StringLength(100, ErrorMessage = "Имя слишком длинное.")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Контактные данные обязательны.")]
        [StringLength(100, ErrorMessage = "Контактные данные слишком длинные.")]
        public string ContactDetails { get; set; } = string.Empty; // Phone or Email
        
        [StringLength(50)]
        public string? Messager { get; set; } // Telegram, WhatsApp, etc.
        
        [StringLength(1000, ErrorMessage = "Комментарий слишком длинный.")]
        public string? Comment { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public bool IsProcessed { get; set; } = false;
        
        // Exact targeting of what they applied for
        public Guid? CourseId { get; set; }
        public Guid? ConsultationId { get; set; }
        public Guid? RetreatId { get; set; }
        
        // Context formatting
        public string TargetFormat { get; set; } = string.Empty; // e.g. "Online" or "Offline"
        
        // Admin Management
        public string Status { get; set; } = "Входящая"; // "Входящая", "В работе", "Успешно", "Отказ"
        [StringLength(2000)]
        public string? AdminNotes { get; set; }
        
        // Link to Customer account (set when admin creates/associates account from this lead)
        public Guid? CustomerId { get; set; }
    }
}
