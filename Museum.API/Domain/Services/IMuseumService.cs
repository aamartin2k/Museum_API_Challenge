﻿using MuseumAPI.Domain.Models;
using MuseumAPI.Domain.Services.Responses;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MuseumAPI.Domain.Services
{
    public interface IMuseumService
    {
        Task<IEnumerable<Museum>> ListAsync();
        Task<Museum> ListByIdAsync(int id);


        Task<MuseumResponse> SaveAsync(Museum museum);
        Task<MuseumResponse> UpdateAsync(int id, Museum museum);
        Task<MuseumResponse> DeleteAsync(int id);
        
    }
}
