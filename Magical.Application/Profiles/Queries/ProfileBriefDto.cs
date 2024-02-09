using Magical.Domain.Entities;
using Magical.Domain.Enums;

namespace Magical.Application.Profiles.Queries
{
    public class ProfileBriefDto
    {
        public string UserName { get; set; }
        public MainRole ChampionRole { get; set; }
        public string? PicturePath { get; set; }
        public string Team { get; set; }

        private class Mapping : AutoMapper.Profile
        {
            public Mapping() => CreateMap<Profile, ProfileBriefDto>();
        }
    }
}
