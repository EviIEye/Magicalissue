
namespace Magical.Domain.Events
{
    public class ProfileCompletedEvent : BaseEvent
    {
        public ProfileCompletedEvent(Profile profile) => Profile = profile;

        public Profile Profile { get; }
    }
}
