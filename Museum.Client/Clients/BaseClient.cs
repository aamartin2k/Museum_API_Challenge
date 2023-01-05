using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Museum.Client.Clients
{
    abstract class BaseClient
    {
        protected readonly RestClient _client;
        protected readonly string _resource;

        public BaseClient(string baseUrl, string resource)
        {
            _client = new RestClient(baseUrl);
            _resource = resource;
        }
    }
}
