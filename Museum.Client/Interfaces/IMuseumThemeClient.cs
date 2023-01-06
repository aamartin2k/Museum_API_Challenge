using MuseumAPI.Mapping.Resources;
using System.Collections.Generic;

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
