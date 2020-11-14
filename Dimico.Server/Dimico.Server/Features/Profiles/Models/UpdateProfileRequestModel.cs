using System.ComponentModel.DataAnnotations;
using Dimico.Server.Data.Models;

using static Dimico.Server.Data.Validation.User;

namespace Dimico.Server.Features.Profiles.Models
{
    public class UpdateProfileRequestModel
    {
        [EmailAddress]
        public string Email { get; set; }

        public string UserName { get; set; }

        [MaxLength(MaxNameLenght)]
        public string Name { get; set; }

        public string MainPhotoUrl { get; set; }

        public string WebSite { get; set; }

        [MaxLength(MaxBiographyLenght)]
        public string Biography { get; set; }

        public Gender Gender { get; set; }

        public bool IsPrivate { get; set; }
    }
}
