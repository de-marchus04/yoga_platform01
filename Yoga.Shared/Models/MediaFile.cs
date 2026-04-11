using System;
using System.ComponentModel.DataAnnotations;

namespace Yoga.Shared.Models
{
    public class MediaFile
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [StringLength(256)]
        public string FileName { get; set; } = string.Empty;

        [Required]
        [StringLength(128)]
        public string ContentType { get; set; } = string.Empty;

        public long Size { get; set; }

        public DateTime UploadedAt { get; set; } = DateTime.UtcNow;

        [StringLength(512)]
        public string? AltText { get; set; }

        /// <summary>Relative path within the media store, e.g. /media/2026/04/filename.jpg</summary>
        [Required]
        [StringLength(512)]
        public string StoragePath { get; set; } = string.Empty;
    }
}
