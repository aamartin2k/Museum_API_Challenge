using MuseumAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MuseumAPI.Domain.Services.Responses
{
    public class MuseumResponse : BaseResponse
    {
        public Museum Museum { get; private set; }

        private MuseumResponse(bool success, string message, Museum museum) : base(success, message)
        {
            Museum = museum;
        }

        // Success response constructor
        public MuseumResponse(Museum museum) : this(true, string.Empty, museum)
        { }

        // Error response constructor
        public MuseumResponse(string message) : this(false, message, null)
        { }
    }
}
