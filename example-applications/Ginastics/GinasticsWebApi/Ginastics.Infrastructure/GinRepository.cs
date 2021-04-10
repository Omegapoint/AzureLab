#nullable enable
using System;
using System.Collections.Generic;
using Ginastics.Domain;
using Ginastics.Domain.Model;

namespace Infrastructure
{
    public class GinRepository : IGinInformationRepository
    {
        // TODO: make me database
        private readonly IDictionary<Guid, Gin> _ginDatabase = new Dictionary<Guid, Gin>();

        public void Create(Gin gin)
        {
            _ginDatabase[gin.GinId] = gin;
        }

        public IEnumerable<Gin> Get()
        {
            return _ginDatabase.Values;
        }

        public Gin? Get(Guid ginId)
        {
            try
            {
                return _ginDatabase[ginId];
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool Delete(Guid id)
        {
            try
            {
                _ginDatabase.Remove(id);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}