
using Core.Entities;
using Core.Interfaces;
using System.Text.Json;

namespace Infrastructure.Data;
public class StoreContextSeed {
    public static async Task SeedAsync (StoreContext context) {
        if (!context.Products.Any()) {
            var jsonString = await File.ReadAllTextAsync("../Infrastructure/Data/SeedData/products.json");
            var productList = JsonSerializer.Deserialize<List<Product>>(jsonString);
            if (productList == null)
                return;
            context.Products.AddRange(productList);
            await context.SaveChangesAsync();
        }
    }
}

