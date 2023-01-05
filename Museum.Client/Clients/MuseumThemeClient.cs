using Museum.Client.Interfaces;
using MuseumAPI.Mapping.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Museum.Client.Clients
{
    class MuseumThemeClient : BaseClient, IMuseumThemeClient
    {

        public MuseumThemeClient(string baseUrl, string resource) : base(baseUrl, resource) { }


        public void Create(MuseumThemeResource resource)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<MuseumThemeResource> Get()
        {
            throw new NotImplementedException();
        }

        public void Update(int id, MuseumThemeResource resource)
        {
            throw new NotImplementedException();
        }
    }
}
