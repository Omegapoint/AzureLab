using System.Collections.Generic;
using System.Linq;
using Ginastics.Domain;
using Ginastics.Domain.Model;

namespace Infrastructure
{
    public class ImageRepository : IImageRepository
    {
        // gin to images
        private readonly IDictionary<GinId, List<ImageId>> _ginImages = new Dictionary<GinId, List<ImageId>>();

        // imageId to Image
        private readonly IDictionary<ImageId, Image> _imageDatabase = new Dictionary<ImageId, Image>();

        public void UploadImage(Image image)
        {
            if (_ginImages.ContainsKey(image.GinId))
            {
                _ginImages[image.GinId].Add(image.ImageId);
                _imageDatabase[image.ImageId] = image;
            }
            else
            {
                _ginImages.Add(image.GinId, new List<ImageId> {image.ImageId});
                _imageDatabase[image.ImageId] = image;
            }
        }

        public List<Image> Images(GinId ginId)
        {
            return _ginImages[ginId].Select(id => _imageDatabase[id]).ToList();
        }

        public Image Image(ImageId imageId)
        {
            return _imageDatabase[imageId];
        }
    }
}