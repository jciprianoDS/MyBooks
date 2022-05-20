using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyBooks.Controllers.v1
{
    [ApiVersion("1.0")]
    [ApiVersion("1.2")]
    [ApiVersion("1.9")]
    [Route("api/[controller]")]
    //[Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet("GetTestData")]
        public IActionResult GetV1()
        {
            return Ok("This is Version V1.0");
        }

        [HttpGet("GetTestData"), MapToApiVersion("1.2")]
        public IActionResult GetV12()
        {
            return Ok("This is Version V1.2");
        }

        [HttpGet("GetTestData"), MapToApiVersion("1.9")]
        public IActionResult GetV19()
        {
            return Ok("This is Version V1.9");
        }
    }
}
