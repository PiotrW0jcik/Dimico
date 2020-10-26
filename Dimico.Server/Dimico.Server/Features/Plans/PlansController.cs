using System.Collections.Generic;
using System.Threading.Tasks;
using Dimico.Server.Features.Plans.Models;
using Dimico.Server.Infrastructure;
using Dimico.Server.Infrastructure.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dimico.Server.Features.Plans
{
    [Authorize]
    public class PlansController : ApiController
    {
        private readonly IPlanService planService;

        public PlansController(IPlanService planService) => this.planService = planService;

        [HttpGet]
        public async Task<IEnumerable<PlanListingServiceModel>> Mine()
        {
            var userId = this.User.GetId();

            return await this.planService.ByUser(userId);

        }

        [Route("{id}")]
        [HttpGet]
        public async Task<ActionResult<PlanDetailsServiceModel>> Details(int id)
            => await this.planService.Details(id);

           
        

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
