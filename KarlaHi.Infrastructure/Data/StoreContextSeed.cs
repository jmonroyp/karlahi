using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using KarlaHi.Infrastructure.Entities;
using Microsoft.Extensions.Logging;

namespace KarlaHi.Infrastructure.Data
{
    public class StoreContextSeed
    {
        public static async Task SeedAsync(StoreContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                if (!context.ProductBrands.Any())
                {
                    var brands =
                    JsonSerializer.Deserialize<List<ProductBrand>>(File.ReadAllText("../KarlaHi.Infrastructure/SeedData/brands.json"));
                    foreach (var brand in brands)
                    {
                        context.ProductBrands.Add(brand);
                    }
                    await context.SaveChangesAsync();
                }
                if (!context.ProductTypes.Any())
                {
                    var types =
                    JsonSerializer.Deserialize<List<ProductType>>(File.ReadAllText("../KarlaHi.Infrastructure/SeedData/types.json"));
                    foreach (var type in types)
                    {
                        context.ProductTypes.Add(type);
                    }
                    await context.SaveChangesAsync();
                }
                if (!context.Products.Any())
                {
                    var products =
                    JsonSerializer.Deserialize<List<Product>>(File.ReadAllText("../KarlaHi.Infrastructure/SeedData/products.json"));
                    foreach (var product in products)
                    {
                        context.Products.Add(product);
                    }
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
    }
}