using System;

namespace Yoga.Shared.Models
{
    public class Retreat
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsActive { get; set; } = true;
        public string? ImageUrl { get; set; }
        public string? PriceLabel { get; set; }
        public string? Program { get; set; }
        /// <summary>Public URL segment, e.g. me01. Unique when set.</summary>
        public string? Slug { get; set; }
    }
}
