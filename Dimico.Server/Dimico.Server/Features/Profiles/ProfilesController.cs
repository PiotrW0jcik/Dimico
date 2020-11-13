using System.Threading.Tasks;
using Dimico.Server.Features.Identity.Models;
using Dimico.Server.Features.Profiles.Models;
using Dimico.Server.Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Dimico.Server.Features.Profiles
{
    public class ProfilesController : ApiController
    {
        private readonly IProfileServices profiles;
        private readonly ICurrentUserService currentUser;

        public ProfilesController(
            IProfileServices profiles, 
            ICurrentUserService currentUser)
        {
            this.profiles = profiles;
            this.currentUser = currentUser;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<ProfileServiceModel>> Mine()
            => await this.profiles.ByUser(this.currentUser.GetId());

    }
}
