
namespace Magical.Domain.Events
{
    public class ProfileUpdateEvent : BaseEvent
    {
        public ProfileUpdateEvent(Profile profile) => Profile = profile;

        public Profile Profile { get; }
    }
}
