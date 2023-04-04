using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Blazor_Application.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        static int ID_number =0;

        public static List<client> clients = new List<client> {
            new client{
                Name = "Jan" ,
                Surname = "Kowalski" ,
                Address = "Kraków ulica malinowa 5" ,
                Current_Date = DateTime.Today ,
                VAT_ID_number = ID_number++
            }
        };

        //Get list of clientsKC
        [HttpGet("all")]
        public async Task<ActionResult<List<client>>> GetClients()
        {
            return Ok(clients);
        }

        //Get one client
       [HttpGet("{id}")]
        public async Task<ActionResult<client>> GetClient(int id)
        {
            var client = clients.FirstOrDefault(cl => cl.VAT_ID_number == id);
            if (client == null)
            {
                return NotFound("client with this vat id number doesn't exist");
            } 
            return Ok(client);

        }
        [HttpPost]
        public async Task<ActionResult<client>> CreateClient(client cl)
        {
            cl.Current_Date = DateTime.Today;
            cl.VAT_ID_number = ID_number++;
            clients.Add(cl);
            return Ok(clients);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<List<client>>> UpdateClient(client cl, int id)
        {
            var client = clients.FirstOrDefault(cl => cl.VAT_ID_number == id);
            if (client == null) 
            { 
                return NotFound("client with this vat id number doesn't exist"); 
            }
            client.Surname = cl.Surname;
            client.Address = cl.Address;
            client.Name = cl.Name;
            return Ok(client);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<client>>> DeleteClient(int id)
        {
            var client = clients.FirstOrDefault(cl => cl.VAT_ID_number == id);
            clients.Remove(client);
            return Ok(clients);
        }

    }
}
