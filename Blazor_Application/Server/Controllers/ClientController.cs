using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blazor_Application.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        public static List<client> clients = new List<client> { 
            new client{ 
                Name = "Jan" , 
                Surname = "Kowalski" , 
                Address = "Kraków ulica malinowa 5" , 
                Current_Date = DateTime.Today , 
                VAT_ID_number = 1
            }

        };

        // Get list of clients
        [HttpGet]
        public async Task<ActionResult<List<client>>> GetClients()
        {
            return Ok(clients);
        }

        // Get one client
        [HttpGet("VAT_ID_number")]
        public async Task<ActionResult<client>> GetClient(int VAT_ID_number)
        {
            var client = clients.FirstOrDefault(cl => cl.VAT_ID_number == VAT_ID_number);
            if (client == null)
            {
                return NotFound("Client with this VAT ID number doesn't exist");
            }
            return Ok(clients);
        }
    }
}
