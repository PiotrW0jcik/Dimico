using System.Threading.Tasks;
using Dimico.Server.Features.Follows.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dimico.Server.Features.Follows
{
    public class FollowsController : ApiController
    {
        [HttpPost]
        [Authorize]
        public async Task<ActionResult> Follow(FollowRequestModel model)
        {

        }
    }
}
