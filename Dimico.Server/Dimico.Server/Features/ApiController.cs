using Microsoft.AspNetCore.Mvc;

namespace Dimico.Server.Features
{
    [ApiController]
    [Route("[controller]")]
    public abstract class ApiController : ControllerBase
    {
    }
}
