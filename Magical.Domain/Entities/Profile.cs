namespace Magical.Domain.Entities
{
    public class Profile : BaseAuditableEntity
    {
         
        public string? FirstName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string? LastName { get; set; }
        public string? Description { get; set; }
        public MainRole? ChampionRole { get; set; }
        public DateTime? BirthDay { get; set; }
        public string? PicturePath { get; set; }
        public DateTime RegistrationDate { get; set; }

        public DateTime? LastVisit { get; set; }
        public int TotalMatches { get; set; }
        public int Wins { get; set; }
        public int Defeats { get; set; }

        public int? RosterId { get; set; }
        public Roster Roster { get; set; }

        public List<Team> Teams { get; set; } = new List<Team> { };
        public List<Pool> Pools { get; set; } = new List<Pool> { };
        public List<Schedule> Schedules { get; set; } = new List<Schedule> { };
        public List<Statistics> Statistics { get; set; } = new List<Statistics> { };
    }
}
