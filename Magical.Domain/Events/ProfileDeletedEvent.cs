namespace Magical.Domain.Events
{
    public class ProfileDeletedEvent : BaseEvent
    {
        public ProfileDeletedEvent(Profile profile) => Profile = profile;

        public Profile Profile { get; }
    }
}
