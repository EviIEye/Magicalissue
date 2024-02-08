namespace  Magical.Domain.Entities
{
    public class Match : BaseAuditableEntity
    {
         
        public int? WinnerTeamId { get; set; }
        public DateTime? TotalTimePlayed { get; set; }
        public DateTime PlannedDate { get; set; }
        public DateTime? FactDate { get; set; }
        public GameStatus Status { get; set; }

        public List<Team> Teams { get; set; } = new List<Team> { };

        public List<Statistics> Statistics { get; set; } = new List<Statistics> { };


    }
}
