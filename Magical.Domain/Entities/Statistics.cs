using Magical.Domain.Common;

namespace  Magical.Domain.Entities
{
    public class Statistics : BaseAuditableEntity
    {
         
        public int Kills { get; set; }
        public int Assists { get; set; }
        public int Deaths { get; set; }
        public int Credits { get; set; }
        public byte Series { get; set; }
        public int Damage { get; set; }
        public int Shielding { get; set; }
        public int Healing { get; set; }

        public int ChampionId { get; set; }
        public Champion Champion { get; set; }

        public int ProfileId { get; set; }
        public Profile Profile { get; set; }

        public int MatchId { get; set; }
        public Match Match { get; set; }



    }
}
