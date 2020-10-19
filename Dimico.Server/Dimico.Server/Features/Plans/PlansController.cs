using System.Threading.Tasks;
using Dimico.Server.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dimico.Server.Features.Plans
{
    public class PlansController : ApiController
    {
        private readonly IPlanService planService;

        public PlansController(IPlanService planService) => this.planService = planService;

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<int>> Create(CreatePlanRequestModel model)
        {
            var userId = this.User.GetId();

            var id = await this.planService.Create(
                model.ImageUrl, 
                model.Description, 
                userId);

            return Created(nameof(this.Create), id);
        }
    }
}
