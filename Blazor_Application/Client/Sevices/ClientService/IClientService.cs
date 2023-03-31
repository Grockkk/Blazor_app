using Blazor_Application.Shared;

namespace Blazor_Application.Client.Sevices.ClientService
{
    public interface IClientService
    {
        List<client> Clients { get; set; }
        Task GetClients();

        Task<client> GetSingleClient(int VAT_ID_number);
    }
}
