using MuseumAPI.Mapping.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Museum.Client.Interfaces
{
    interface IMuseumClient
    {
        List<MuseumResource> Get();
        void Create(MuseumResource resource);
        void Update(int id, MuseumResource resource);
        void Delete(int id);
    }
}
