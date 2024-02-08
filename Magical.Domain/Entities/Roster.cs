namespace Magical.Domain.Entities
{
    public class Roster : BaseAuditableEntity
    {
         
        public Team Team { get; set; }

        public List<Profile> Profiles { get; set; } = new List<Profile> { };
    }
}
