#nullable enable
using System;
using System.Collections.Generic;
using Ginastics.Domain.Model;

namespace Ginastics.Domain
{
    public interface IGinInformationRepository
    {
        public void Create(Gin gin);
        public IEnumerable<Gin> Get();
        public Gin? Get(Guid ginId);
    }
}