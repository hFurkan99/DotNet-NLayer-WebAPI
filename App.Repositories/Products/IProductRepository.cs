namespace App.Repositories.Products;

public interface IProductRepository : IGenericRepository<Product, int>
{
    Task<IEnumerable<Product>> GetTopPriceProductsAsync(int count);
}
