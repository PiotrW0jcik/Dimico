using System.Threading.Tasks;
using Dimico.Server.Features.Follows.Models;
using Dimico.Server.Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dimico.Server.Features.Follows
{
    public class FollowsController : ApiController
    {
        private readonly ICurrentUserService currentUser;
        private readonly IFollowService follows;

        public FollowsController(
            IFollowService follows, 
            ICurrentUserService currentUser)
        {
            this.follows = follows;
            this.currentUser = currentUser;
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult> Follow(FollowRequestModel model)
        {
            var result = await this.follows.Follow(
                model.UserId,
                this.currentUser.GetId());

            if (result.Failure)
            {
                return this.BadRequest(result.Error);
            }

            return Ok();
        }
    }
}
