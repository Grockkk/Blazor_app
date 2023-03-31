using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

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

        //Get list of clientsKC
        [HttpGet("all")]
        public async Task<ActionResult<List<client>>> GetClients()
        {
            return Ok(clients);
        }

        //Get one client
       [HttpGet("byTax")]
        public async Task<ActionResult<client>> GetClient(int id)
        {
            var client = clients.FirstOrDefault(cl => cl.VAT_ID_number == id);
            if (client == null)
            {
                return NotFound("client with this vat id number doesn't exist");
            } 
            return Ok(client);

        }


    }
}
