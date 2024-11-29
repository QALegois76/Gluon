using Microsoft.EntityFrameworkCore;

namespace Client.Api
{
    public class ClientDbContext  : DbContext
    {
        public DbSet<Client> Clients {  get; set; }


        // constructor
        public ClientDbContext(DbContextOptions options) : base(options)
        {
            if (Database.EnsureCreated())
                Console.WriteLine("DB connected and valid");
            else
                Console.WriteLine("DB NOT valid");
        }

    }
}
