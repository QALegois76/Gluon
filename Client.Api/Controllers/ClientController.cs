using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Client.Api.Controllers
{
    [ApiController]
    [Route("/")]
    public class ClientController : ControllerBase
    {
        public const string VERSION = "v1";

        private readonly ILogger<ClientController> _logger;
        private readonly ClientDbContext _db;

        private List<Client> _clientsTMP = new List<Client>();


        // construcor
        public ClientController(ILogger<ClientController> logger, ClientDbContext client)
        {
            _db = client;
            _logger = logger;
        }



        [HttpGet(Name = "Clients")]
        public async Task<IEnumerable<Client>> Get()
        {
            return await _db.Clients.ToArrayAsync();
        }


        [HttpGet("Status")]
        public string GetStatus()
        {
            Console.WriteLine("He's Alive !!!");
            return VERSION;
        }


        [HttpPost]
        public void PostClient(Client client)
        {
            _db.Clients.Add(client);
            _db.SaveChangesAsync();
        }


        [HttpPut]
        public void PutClient(Guid guid, Client client)
        {
            var c = _db.Clients.FirstOrDefault(x => x.Guid == guid);
            if (c == null)
                return;

            c.Copy(client);
            _db.SaveChangesAsync();
        }


        [HttpDelete]
        public void DeleteClient(Guid guid)
        {
            var c = _db.Clients.FirstOrDefault(x => x.Guid == guid);
            if (c == null)
                return;


            _db.Clients.Remove(c);
            _db.SaveChangesAsync();
        }


    }
}
