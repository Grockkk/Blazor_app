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
            var outcome = await _http.GetFromJsonAsync<List<client>>("api/client/all");

            if (outcome != null)
            {
                Clients = outcome;
            }
        }

        public async Task<client> GetSingleClient(int VAT_ID_number)
        {
            var outcome = await _http.GetFromJsonAsync<client>($"api/client/bytax?id={VAT_ID_number}");

            if (outcome != null)
            {
                return outcome;
            }
            throw new Exception("Client not found");
        }


    }
}
