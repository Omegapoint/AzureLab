using Ginastics.Api;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ginastics.Controller.Controllers
{
    // GinInformation == metadata om specifik gin
    public class GinInformationController : ControllerBase
    {
        [HttpPost("gin")]
        public IActionResult Create([FromBody] GinInformation ginInformation)
        {
            // search

            return new OkObjectResult(ginInformation);
        }

        [HttpGet("gin/{id?}")]
        [ProducesResponseType(typeof(GinInformation), StatusCodes.Status200OK)]
        public IActionResult Get(string id)
        {
            // gin/:id?
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }

            return new OkObjectResult(new GinInformation("Hendricks", "1000", "swe", "hendricks"));
        }

        [HttpDelete("gin/{id}")]
        public IActionResult Delete(string id)
        {
            return new NoContentResult();
        }

        [HttpPut("gin/{id}")]
        public IActionResult Modify(string id, [FromBody] GinInformation ginInformation)
        {
            return new OkResult();
        }
    }
}