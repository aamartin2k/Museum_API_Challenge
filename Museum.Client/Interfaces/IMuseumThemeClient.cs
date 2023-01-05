using MuseumAPI.Mapping.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Museum.Client.Interfaces
{
    interface IMuseumThemeClient
    {
        List<MuseumThemeResource> Get();
        void Create(MuseumThemeResource resource);
        void Update(int id, MuseumThemeResource resource);
        void Delete(int id);
    }
}
