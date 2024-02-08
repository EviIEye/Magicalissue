namespace Magical.Domain.Events
{
    public class ProfileCreatedEvent : BaseEvent
    {
        public ProfileCreatedEvent(Profile profile) => Profile = profile;

        public Profile Profile { get; }
    }
}
