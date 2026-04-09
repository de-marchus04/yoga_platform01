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
        [MinLength(3, ErrorMessage = "Контактные данные слишком короткие.")]
        public string ContactDetails { get; set; } = string.Empty;

        [StringLength(50)]
        public string? Messager { get; set; }

        [StringLength(1000, ErrorMessage = "Комментарий слишком длинный.")]
        public string? Comment { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public Guid? CourseId { get; set; }
        public Guid? ConsultationId { get; set; }

        public string TargetFormat { get; set; } = string.Empty;
    }
}
