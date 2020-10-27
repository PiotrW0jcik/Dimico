using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dimico.Server.Controllers
{
    public class PlansController : ApiController
    {
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<int>> Create()
    }
}
