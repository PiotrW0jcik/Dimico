using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Dimico.Server.Data;
using Dimico.Server.Data.Models;
using Dimico.Server.Infrastructure;
using Dimico.Server.Models.Plans;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dimico.Server.Controllers
{
    public class PlansController : ApiController
    {
        private readonly DimicoDbContext data;

        public PlansController(DimicoDbContext data)
        {
            this.data = data;
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<int>> Create(CreatePlanRequestModel model)
        {
            var userId = this.User.GetId();

            var plan = new Plan
            {
                Description = model.Description,
                ImageUrl =  model.ImageUrl,
                UserId = userId
            };
            this.data.Add(plan);
            await this.data.SaveChangesAsync();

            return Created(nameof(this.Create), plan.Id);
        }
    }
}
