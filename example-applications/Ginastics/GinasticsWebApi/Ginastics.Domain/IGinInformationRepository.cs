#nullable enable
using System;
using Ginastics.Domain.Model;

namespace Ginastics.Domain
{
    public interface IGinInformationRepository
    {
        public void Create(Gin gin);
        public Gin? Get(Guid ginId);
    }
}