using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Domain.Contracts;
using Domain.Entities.ProductModule;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace Persistence.Data
{
    public class DataSeeding : IDataSeeding
    {
        private readonly StoreDbContext dbContext;

        public DataSeeding(StoreDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        public async Task  SeedDataAsync()
        {
            try
            {
                if ((await dbContext.Database.GetPendingMigrationsAsync()).Any())
                {
                   await dbContext.Database.MigrateAsync();
                }

                if (!dbContext.ProductBrands.Any())
                {
                    var ProductsBrands =  File.OpenRead(@"..\Infrastructure\Persistence\Data\Files\brands.json");
                    var Brands = await JsonSerializer.DeserializeAsync<List<ProductBrand>>(ProductsBrands);
                    if (Brands is not null && Brands.Any())
                    {
                       await   dbContext.ProductBrands.AddRangeAsync(Brands);

                    }
                }
                if (!dbContext.ProductTypes.Any())
                {
                    var ProductsTypes =  File.OpenRead(@"..\Infrastructure\Persistence\Data\Files\types.json");
                    var Types = await JsonSerializer.DeserializeAsync<List<ProductType>>(ProductsTypes);
                    if (Types is not null && Types.Any())
                    {
                        await dbContext.ProductTypes.AddRangeAsync(Types);

                    }
                }
                if (!dbContext.Products.Any())
                {
                    var ProductData = File.OpenRead(@"..\Infrastructure\Persistence\Data\Files\products.json");
                    var Products = await JsonSerializer.DeserializeAsync<List<Product>>(ProductData);
                    if (Products is not null && Products.Any())
                    {
                        await dbContext.Products.AddRangeAsync(Products);

                    }
                }
               await dbContext.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
