using System.Collections.Generic;
using Ginastics.Domain.Model;

namespace Ginastics.Domain
{
    public interface IImageRepository
    {
        public void UploadImage(Image image);
        public List<Image> Images(GinId ginId);
        public Image Image(ImageId imageId);
    }
}