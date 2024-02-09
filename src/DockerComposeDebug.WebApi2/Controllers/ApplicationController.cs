using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DockerComposeDebug.WebApi2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationController : ControllerBase
    {
        public ApplicationController() { }

        [HttpGet("GetApiName")]
        public string GetApiName()
        {
            return nameof(WebApi2);
        }
    }
}
