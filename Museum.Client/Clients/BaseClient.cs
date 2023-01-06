using RestSharp;

namespace Museum.Client.Clients
{
    abstract class BaseClient
    {
        protected readonly IRestClient _client;
        protected readonly string _resource;


        public BaseClient(IRestClient client, string resource)
        {
            _client = client;
            _resource = resource;
        }

    }
}
