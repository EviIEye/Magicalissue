using Magical.Domain.Common;
using Magical.Domain.Enums;

namespace Magical.Domain.Entities
{
    public class Champion : BaseAuditableEntity
    {
        
        public string ChampionName { get; set; }
        public MainRole ChampionRole { get; set; }
        public string ChampionImgPath { get; set; }

        public List<Pool> Pools { get; set; } = new List<Pool> { };

        public List<Statistics> Statistics { get; set; } = new List<Statistics> { };
    }
}
