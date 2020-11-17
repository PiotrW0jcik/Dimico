using System.Collections.Generic;
using System.Threading.Tasks;
using Dimico.Server.Features.Plans.Models; 
using Dimico.Server.Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using static Dimico.Server.Infrastructure.WebConstants;




namespace Dimico.Server.Features.Plans
{
    [Authorize]
    public class PlansController : ApiController
    {
        private readonly IPlanService plans;
        private readonly ICurrentUserService currentUser;

        public PlansController(
            IPlanService planService, 
            ICurrentUserService currentUser)
        {
            this.plans = planService;
            this.currentUser = currentUser;
        }

        [HttpGet]
        public async Task<IEnumerable<PlanListingServiceModel>> Mine() 
            => await this.plans.ByUser(this.currentUser.GetId());

        
        [HttpGet]
        [Route(Id)]
        public async Task<PlanDetailsServiceModel> Details(int id)
            => await this.plans.Details(id);

           
        

        [HttpPost]
        public async Task<ActionResult<int>> Create(CreatePlanRequestModel model)
        {
            var userId = this.currentUser.GetId();

            var id = await this.plans.Create(
                model.ImageUrl, 
                model.Description, 
                userId);

            return Created(nameof(this.Create), id);
        }

        [HttpPut]
        [Route(Id)]
        public async Task<ActionResult> Update(int id,UpdatePlanRequestModel model)
        {
            var userId = this.currentUser.GetId();

            var result = await this.plans.Update(
                id,
                model.Description,
                userId);

            if (result.Failure)
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpDelete]
        [Route(Id)]
        public async Task<ActionResult> Delete(int id)
        {
            var userId = this.currentUser.GetId();

            var result = await this.plans.Delete(id, userId);

            if (result.Failure)
            {
                return BadRequest();
            }

            return Ok();
        }

    }
}
