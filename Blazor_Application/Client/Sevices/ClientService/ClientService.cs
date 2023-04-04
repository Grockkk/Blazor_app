using Blazor_Application.Shared;
using Microsoft.AspNetCore.Components;
using System;
using System.Net.Http.Json;

namespace Blazor_Application.Client.Sevices.ClientService
{
    public class ClientService : IClientService
    {

        private readonly HttpClient _http;
        private readonly NavigationManager _navigationManager;

        public ClientService(HttpClient http, NavigationManager navigationManager) {
            _http = http;
            _navigationManager = navigationManager;
        }

        public List<client> Clients { get; set; } = new List<client>();

        public async Task CreateClient(client client)
        {
            var outcome = await _http.PostAsJsonAsync($"api/client", client);
            await UpdateList(outcome);
        }

        public async Task DeleteClient(int VAT_ID_number)
        {
            var outcome = await _http.DeleteAsync($"api/client/{VAT_ID_number}");
            await UpdateList(outcome);
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
            var outcome = await _http.GetFromJsonAsync<client>($"api/client/{VAT_ID_number}");

            if (outcome != null)
            {
                return outcome;
            }
            throw new Exception("Client not found");
        }

        public async Task UpdateClient(client client)
        {
            var outcome = await _http.PutAsJsonAsync($"api/client/{client.VAT_ID_number}", client);
            await UpdateList(outcome);
        }

        public async Task UpdateList(HttpResponseMessage outcome)
        {
            var updatedList = await outcome.Content.ReadFromJsonAsync<List<client>>();
            Clients = updatedList;
            _navigationManager.NavigateTo("client");
        }

    }
}
