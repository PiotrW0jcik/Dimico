using System.Threading.Tasks;
using Dimico.Server.Features.Follows;
using Dimico.Server.Features.Profiles.Models;
using Dimico.Server.Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using static Dimico.Server.Infrastructure.WebConstants;

namespace Dimico.Server.Features.Profiles
{
    [Authorize]
    public class ProfilesController : ApiController
    {
        private readonly IProfileServices profiles;
        private readonly IFollowService follows;
        private readonly ICurrentUserService currentUser;

        public ProfilesController(
            IProfileServices profiles, 
            ICurrentUserService currentUser, IFollowService follows)
        {
            this.profiles = profiles;
            this.currentUser = currentUser;
            this.follows = follows;
        }

        [HttpGet]
        public async Task<ProfileServiceModel> Mine()
            => await this.profiles.ByUser(this.currentUser.GetId(),allInformation: true);

        [HttpGet]
        [Route(Id)]
        public async Task<ProfileServiceModel> Details(string id)
        {
            var includeAllInformation = await this.follows
                .IsFollower(id, this.currentUser.GetId());

            if (!includeAllInformation)
            {
                includeAllInformation = await this.profiles.IsPublic(id);
            }

            return await this.profiles.ByUser(id,includeAllInformation);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateProfileRequestModel model)
        {
            var userId = this.currentUser.GetId();

            var result = await this.profiles.Update(
                userId,
                model.Email,
                model.UserName,
                model.Name,
                model.MainPhotoUrl,
                model.WebSite,
                model.Biography,
                model.Gender,
                model.IsPrivate);

            if (result.Failure)
            {
                return BadRequest(result.Error);
            }

            return Ok();
        }
    }
}
