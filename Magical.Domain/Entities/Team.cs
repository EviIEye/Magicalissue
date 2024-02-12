using Magical.Domain.Common;

namespace Magical.Domain.Entities
{
    public class Team : BaseAuditableEntity
    {
         
        public string Name { get; set; }
        public string ImageLogo { get; set; }
        public int TotalMatches { get; set; }
        public int Defeats { get; set; }
        public int Wins { get; set; }

        public int RosterId { get; set; }
        public Roster Roster { get; set; }

        public List<Profile> Profiles { get; set; } = new List<Profile> { };
        public List<Match> Matches { get; set; } = new List<Match> { };

    }
}
