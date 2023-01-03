﻿using MuseumAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MuseumAPI.Domain.Repositories
{
    public interface IMuseumRepository
    {
        Task<IEnumerable<Museum>> ListAsync();
    }
}