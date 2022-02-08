using ClientsApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ClientsApp.Data
{
    public class ClientsContext: DbContext
    {
        public ClientsContext (DbContextOptions<ClientsContext> options) : base(options)
        {
        }
        
        public DbSet<Client> Clients { get; set; }
        public DbSet<Founder> Founders{ get; set; }

    }
}