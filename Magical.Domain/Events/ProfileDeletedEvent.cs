﻿using Magical.Domain.Common;
using Magical.Domain.Entities;

namespace Magical.Domain.Events
{
    public class ProfileDeletedEvent : BaseEvent
    {
        public ProfileDeletedEvent(Profile profile) => Profile = profile;

        public Profile Profile { get; }
    }
}
