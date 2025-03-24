using Microsoft.EntityFrameworkCore;

namespace App.Repositories.Products;

public class ProductRepository(AppDbContext context) : GenericRepository<Product, int>(context), IProductRepository
{
    public async Task<IEnumerable<Product>> GetTopPriceProductsAsync(int count)
    {
        return await Context.Products
            .AsNoTracking()
            .OrderByDescending(x => x.Price)
            .Take(count)
            .ToListAsync();
    }
}
