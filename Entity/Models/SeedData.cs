using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Entity.Data;
using System;
using System.Linq;

namespace Entity.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new EntityContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<EntityContext>>()))
            {
                // Look for any movies.
                if (context.CarMovie.Any())
                {
                    return;   // DB has been seeded
                }

                context.CarMovie.AddRange(
                    new Entity.Models.CarMovie
                    {
                        CarTitle = "Audi A3",
                        State = "Used",
                        Country = "Poland",
                        Price = 7.99M
                    },

                    new Entity.Models.CarMovie
                    {
                        CarTitle = "BMW E36",
                        State = "Used",
                        Country = "Germany",
                        Price = 15.99M
                    },

                    new Entity.Models.CarMovie
                    {
                        CarTitle = "Lexus X2",
                        State = "Used",
                        Country = "USA",
                        Price = 27.99M
                    },

                    new Entity.Models.CarMovie
                    {
                        CarTitle = "Mercedes Class E",
                        State = "New",
                        Country = "Japan",
                        Price = 33.25M
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
