using MuseumAPI.Domain.Models;
using MuseumAPI.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MuseumAPI.Services
{
    public class MuseumService : IMuseumService
    {
        public Task<IEnumerable<Museum>> ListAsync()
        {
            throw new NotImplementedException();


        }
    }
}
