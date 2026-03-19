namespace Yoga.Shared.Models
{
    public class Consultation
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Slug { get; set; } = string.Empty; // "energy" | "ayurveda" | "spirituality"
        public int SortOrder { get; set; } = 0;
        public bool IsActive { get; set; } = true;
        
        public bool IsOnline { get; set; } = false;
        public bool IsOffline { get; set; } = false;

        public Guid? LiveEventId { get; set; }

    }
}
