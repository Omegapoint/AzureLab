using System;
using System.IO;
using System.Threading.Tasks;
using Ginastics.Domain;
using Ginastics.Domain.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ginastics.Controller.Controllers
{
    public class ImageController : ControllerBase
    {
        private readonly GinService _ginService;

        public ImageController(GinService ginService)
        {
            _ginService = ginService ?? throw new ArgumentNullException(nameof(ginService));
        }

        [HttpPost("image/gin/{ginId:guid}")]
        public async Task<IActionResult> Upload(IFormFile file, [FromRoute] Guid ginId)
        {
            if (file == null || file.Length <= 0)
            {
                return BadRequest();
            }

            var memoryStream = new MemoryStream();

            await file.CopyToAsync(memoryStream);
            var array = memoryStream.ToArray();

            var imageId = new ImageId(Guid.NewGuid());
            var image = new Image(file.Name, array, new GinId(ginId), imageId);
            _ginService.UploadImage(image);
            return new CreatedResult($"image/{imageId.Value}", image);
        }

        [HttpGet("image/{imageId:guid}")]
        public async Task<FileContentResult> Get(Guid imageId)
        {
            var image = _ginService.Image(imageId.AsImageId());
            return image.AsFileContentResult();
        }
    }
}