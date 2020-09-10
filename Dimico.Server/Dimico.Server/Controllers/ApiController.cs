using Microsoft.AspNetCore.Mvc;

namespace Dimico.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public abstract class ApiController : ControllerBase
    {
    }
}
