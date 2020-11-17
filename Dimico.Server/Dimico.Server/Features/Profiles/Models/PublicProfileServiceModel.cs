using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dimico.Server.Features.Profiles.Models
{
    public class PublicProfileServiceModel : ProfileServiceModel
    {
        public string? WebSite { get; set; }

        public string? Biography { get; set; }

        public string? Gender { get; set; }

    }
}
