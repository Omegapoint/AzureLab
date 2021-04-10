using System;
using Ginastics.Domain.Model;

namespace Ginastics.Domain
{
    public class GinService
    {
        private readonly IGinInformationRepository _informationRepository;

        public GinService(IGinInformationRepository informationRepository)
        {
            _informationRepository =
                informationRepository ?? throw new ArgumentNullException(nameof(informationRepository));
        }


        public void Create(Gin gin)
        {
            _informationRepository.Create(gin);
        }

        public Gin Get(Guid guid)
        {
            return _informationRepository.Get(guid);
        }
    }
}