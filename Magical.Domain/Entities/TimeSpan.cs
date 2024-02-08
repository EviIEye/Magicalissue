namespace  Magical.Domain.Entities
{
    public class TimeSpan : BaseAuditableEntity
    {
        public System.TimeSpan StartSpan { get; set; }
        public System.TimeSpan FinishSpan { get; set; }
        public int ScheduleId { get; set; }
        public Schedule Schedule { get; set; }
    }
}
