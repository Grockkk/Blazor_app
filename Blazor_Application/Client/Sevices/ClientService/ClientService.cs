using Blazor_Application.Shared;
using System;
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

        public async Task CreateClient(client client)
        {
            var outcome = await _http.PostAsJsonAsync($"api/client", client);
            var updatedList = await outcome.Content.ReadFromJsonAsync<List<client>>();
            Clients = updatedList;
        }

        public async Task DeleteClient(int VAT_ID_number)
        {
            var outcome = await _http.DeleteAsync($"api/client/byTax?id={VAT_ID_number}");
            var updatedList = await outcome.Content.ReadFromJsonAsync<List<client>>();
            Clients = updatedList;
        }

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
            var outcome = await _http.GetFromJsonAsync<client>($"api/client/byTax?id={VAT_ID_number}");

            if (outcome != null)
            {
                return outcome;
            }
            throw new Exception("Client not found");
        }

        public async Task UpdateClient(client client)
        {
            var outcome = await _http.PutAsJsonAsync($"api/client/byTax?id={client.VAT_ID_number}", client);
            var updatedList = await outcome.Content.ReadFromJsonAsync<List<client>>();
            Clients = updatedList;
        }

    }
}
