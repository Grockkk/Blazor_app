using Blazor_Application.Shared;
using System.Net.Http.Json;

namespace Blazor_Application.Client.Sevices.ClientService
{
    public class ClientService : IClientService
    {

        private readonly HttpClient _http;

        public ClientService(HttpClient http) {
            _http = http;
        }

        public List<client> Clients { get; set; } = new List<client>();

        public async Task GetClients()
        {
            var outcome = await _http.GetFromJsonAsync<List<client>>("api/client");

            if (outcome != null)
            {
                Clients = outcome;
            }
        }

        public Task GetSingleClient(int VAT_ID_number)
        {
            throw new NotImplementedException();
        }
    }
}
