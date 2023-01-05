using Museum.Client.Interfaces;
using MuseumAPI.Mapping.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Museum.Client.Clients
{
    class MuseumClient : BaseClient, IMuseumClient
    {
        public MuseumClient(string baseUrl, string resource) : base(baseUrl, resource) { }

        public void Create(MuseumResource resource)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<MuseumResource> Get()
        {
            throw new NotImplementedException();
        }

        public void Update(int id, MuseumResource resource)
        {
            throw new NotImplementedException();
        }
    }
}
