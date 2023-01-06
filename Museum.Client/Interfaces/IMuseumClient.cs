using MuseumAPI.Mapping.Resources;
using System.Collections.Generic;

namespace Museum.Client.Interfaces
{
    interface IMuseumClient
    {
        List<MuseumResource> Get();
        void Create(NewMuseumResource resource);
        void Update(int id, MuseumResource resource);
        void Delete(int id);

        MuseumResource ListById(int id);
        List<MuseumResource> ListByThemeID(int id);
    }
}
