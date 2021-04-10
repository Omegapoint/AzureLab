using System;
using System.Linq;
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

            return new CreatedResult($"gin/{domainGin.GinId}", domainGin.ToApi());
        }

        [HttpGet("gin")]
        [ProducesResponseType(typeof(AllGins), StatusCodes.Status200OK)]
        public IActionResult Get()
        {
            var gins = _ginService.Get();
            return new OkObjectResult(new AllGins
            {
                Gins = gins.Select(gin => gin.ToApi()).ToList()
            });
        }
        
        [HttpGet("gin/{id:guid}")]
        [ProducesResponseType(typeof(Gin), StatusCodes.Status200OK)]
        public IActionResult Get(Guid id)
        {
            try
            {
                var gin = _ginService.Get(id);
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