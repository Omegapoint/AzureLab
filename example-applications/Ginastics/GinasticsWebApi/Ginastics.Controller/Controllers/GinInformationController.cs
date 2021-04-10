using System;
using Ginastics.Api;
using Ginastics.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ginastics.Controller.Controllers
{
    // GinInformation == metadata om specifik gin
    public class GinInformationController : ControllerBase
    {
        private readonly GinService _ginService;

        public GinInformationController(GinService ginService)
        {
            _ginService = ginService ?? throw new ArgumentNullException(nameof(ginService));
        }

        [HttpPost("gin")]
        public IActionResult Create([FromBody] GinCreateRequest ginCreateRequest)
        {
            var domainGin = ginCreateRequest.ToDomain();

            _ginService.Create(domainGin);

            return new CreatedResult($"gin/{domainGin.GinId}", domainGin);
        }

        [HttpGet("gin/{id?}")]
        [ProducesResponseType(typeof(GinCreateRequest), StatusCodes.Status200OK)]
        public IActionResult Get(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }

            try
            {
                var gin = _ginService.Get(Guid.Parse(id));
                if (gin == null)
                {
                    return new NotFoundResult();
                }

                return new OkObjectResult(gin.ToApi());
            }
            catch (FormatException)
            {
                return BadRequest();
            }
        }

        [HttpDelete("gin/{id}")]
        public IActionResult Delete(string id)
        {
            return new NoContentResult();
        }

        [HttpPut("gin/{id}")]
        public IActionResult Modify(string id, [FromBody] GinCreateRequest ginCreateRequest)
        {
            return new OkResult();
        }
    }
}