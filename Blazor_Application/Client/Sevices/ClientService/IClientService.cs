using Blazor_Application.Shared;

namespace Blazor_Application.Client.Sevices.ClientService
{
    public interface IClientService
    {
        List<client> Clients { get; set; }
        Task GetClients();

        Task<client> GetSingleClient(int VAT_ID_number);
        Task DeleteClient(int VAT_ID_number);
        Task CreateClient(client client);
        Task UpdateClient(client client);
    }
}
