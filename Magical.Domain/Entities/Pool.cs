using Magical.Domain.Common;

namespace  Magical.Domain.Entities
{
    public class Pool : BaseAuditableEntity
    {
         
        public int TotalMatches { get; set; }
        public DateTime TotalTimePlayed { get; set; }
        public int Wins { get; set; }
        public int Defeats { get; set; }
        public int Kills { get; set; }
        public int Assists { get; set; }
        public int Deaths { get; set; }
        public DateTime? LastMatchDate { get; set; }

        public int ProfileId { get; set; }
        public Profile Player { get; set; }

        public int ChampionId { get; set; }
        public Champion Champion { get; set; }


    }
}
