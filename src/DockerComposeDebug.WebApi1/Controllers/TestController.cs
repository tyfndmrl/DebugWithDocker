using DockerComposeDebug.WebApi1.Configurations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace DockerComposeDebug.WebApi1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly WebApiConfiguration _webApiConfiguration;
        public TestController(IOptions<WebApiConfiguration> webApiConfiguration)
        {
            _webApiConfiguration = webApiConfiguration.Value;
        }

        [HttpGet("Web2GetApiName")]
        public async Task<ActionResult<string>> ApiName()
        {
            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(_webApiConfiguration.BaseUrl);
            var httpResponseMessage = await httpClient.GetAsync(_webApiConfiguration.GetApiName);
            httpResponseMessage.EnsureSuccessStatusCode();
            return Ok(await httpResponseMessage.Content.ReadAsStringAsync());
        }
    }
}
