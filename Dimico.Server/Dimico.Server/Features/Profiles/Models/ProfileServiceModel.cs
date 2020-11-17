﻿ using Dimico.Server.Data.Models;

namespace Dimico.Server.Features.Profiles.Models
{
    public class ProfileServiceModel
    {
        public string? Name { get; set; }

        public string? MainPhotoUrl { get; set; }

        public bool? IsPrivate { get; set; }
    }
}
