using MuseumAPI.Domain.Models;
using MuseumAPI.Domain.Repositories;
using MuseumAPI.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MuseumAPI.Services
{
    public class MuseumService : IMuseumService
    {
        private readonly IMuseumRepository _museumRepository;


        public MuseumService(IMuseumRepository museumRepository)
        {
            _museumRepository = museumRepository;
        }



        public async Task<IEnumerable<Museum>> ListAsync()
        {
            return await _museumRepository.ListAsync();  
        }

        public async Task<Museum> ListByIdAsync(int id)
        {
            return await _museumRepository.ListByIdAsync(id);
        }
    }
}
