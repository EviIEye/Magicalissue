using Magical.Domain.Common;

namespace  Magical.Domain.Entities
{
    public class Status : BaseAuditableEntity
    {
         
        public GameStatus StatusName { get; set; }
        public List<Match> Matches { get; set; } = new List<Match> { };
    }
}
