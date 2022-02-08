using System;
using System.Linq;
using ClientsApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ClientsApp.Data
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ClientsContext 
                (serviceProvider.GetRequiredService<DbContextOptions<ClientsContext>>()))
            {
                if (!context.Clients.Any())
                {
                    context.Clients.AddRange(
                        new Client
                        {
                            TIN = 1234567890,
                            Name = "Anton",
                            Type = "ЮЛ",
                        }
                    );
                    context.SaveChanges();
                }

                if (!context.Founders.Any())
                {
                    context.Founders.AddRange(
                        new Founder
                        {
                            TIN = 123456789012,
                            FirstName = "Sergeev",
                            LastName = "Alex",
                            Patronymic = "Evgenevich",
                        }
                    );
                    context.SaveChanges();
                }
                
            }
        }
    }
}