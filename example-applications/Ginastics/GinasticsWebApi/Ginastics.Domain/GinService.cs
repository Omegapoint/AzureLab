using System;
using System.Collections.Generic;
using Ginastics.Domain.Model;

namespace Ginastics.Domain
{
    public class GinService
    {
        private readonly IGinInformationRepository _informationRepository;
        private readonly IImageRepository _imageRepository;

        public GinService(
            IGinInformationRepository informationRepository,
            IImageRepository imageRepository)
        {
            _informationRepository =
                informationRepository ?? throw new ArgumentNullException(nameof(informationRepository));
            _imageRepository = imageRepository ?? throw new ArgumentNullException(nameof(imageRepository));
        }


        public void Create(Gin gin)
        {
            _informationRepository.Create(gin);
        }

        public IEnumerable<Gin> Get()
        {
            return _informationRepository.Get();
        }
        
        public Gin Get(Guid guid)
        {
            return _informationRepository.Get(guid);
        }

        public bool Delete(Guid id)
        {
            return _informationRepository.Delete(id);
        }

        public void UploadImage(Image image)
        {
            _imageRepository.UploadImage(image);
        }

        public List<Image> LoadImages(GinId ginId)
        {
            return _imageRepository.Images(ginId);
        }

        public Image Image(ImageId imageId)
        {
            return _imageRepository.Image(imageId);
        }
    }
}