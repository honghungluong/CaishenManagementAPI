using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CaishenManagementAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HeathCheckController : ControllerBase
    {
        [HttpGet(Name = "HealthCheck")]
        public string Get()
        {
            return "CaishenManagementAPI HealthCheck successfully!";
        }
    }
}
