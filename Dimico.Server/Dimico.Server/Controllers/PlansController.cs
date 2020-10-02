using System.Threading.Tasks;
using Dimico.Server.Models.Plans;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dimico.Server.Controllers
{
    public class PlansController : ApiController
    {
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<int>> Create(CreatePlanRequestModel model)
        {

        }
    }
}
