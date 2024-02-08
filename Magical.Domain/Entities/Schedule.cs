namespace  Magical.Domain.Entities
{
    public class Schedule : BaseAuditableEntity
    {
        
        public DateTime Day { get; set; }
        
        public int ProfileId { get; set; }
        public Profile Profile { get; set; }

        public List<TimeSpan> TimeSpans { get; set; } = new List<TimeSpan> { };

    }
}
