using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProductBackEnd.Data;
using ProductBackEnd.Models;

namespace ProductBackendTest.IntegrationTest
{
    public class IntegrationTest
    {
        protected readonly HttpClient _client;

        public IntegrationTest()
        {
            var appFactory = new WebApplicationFactory<ProductBackEnd.Startup>()
                .WithWebHostBuilder(builder =>
                {
                    builder.ConfigureServices(services =>
                    {

                        var descriptor = services.SingleOrDefault
                        (d => d.ServiceType == typeof(DbContextOptions<InventoryContext>));

                        if (descriptor != null)
                        {
                            services.Remove(descriptor);
                        }
                        
                        services.AddDbContext<InventoryContext>
                          ((_, context) => context.UseInMemoryDatabase("InMemoryDbForTesting"));


                        var sp = services.BuildServiceProvider();

                        using (var scope = sp.CreateScope())
                        {
                            var scopedServices = scope.ServiceProvider;
                            var db = scopedServices.GetRequiredService<InventoryContext>();

                            db.Database.EnsureCreated();

                            try
                            {
                                _ = InitializeDbForTests(db);
                            }
                            catch (Exception ex)
                            {
                                Console.Write(ex.Message);
                            }
                        }
                    });
                });

            _client = appFactory.CreateClient();
        }

        public async Task InitializeDbForTests(InventoryContext inventoryContext)
        {           
            inventoryContext.Products.AddRange(GetProducts());
            await inventoryContext.SaveChangesAsync();
        }

        public List<Product> GetProducts()
        {
            return new List<Product>() {
                new Product(){ProductId = 1, Name = ConstantsTest.ProductName,
                    Description = ConstantsTest.ProductDesc, Image = ConstantsTest.ProductImage,
                    Price = ConstantsTest.ProductPrice, Rating = ConstantsTest.ProductRating,
                    Reviews = ConstantsTest.ProductReviews},
                new Product(){ProductId = 2},
                new Product(){ProductId = 3},
                new Product(){ProductId = 4}
                };
        }
    }
}
