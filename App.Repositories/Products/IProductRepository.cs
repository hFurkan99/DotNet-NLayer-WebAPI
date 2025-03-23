namespace App.Repositories.Products;

public interface IProductRepository : IGenericRepository<Product>
{
    Task<IEnumerable<Product>> GetTopPriceProductsAsync(int count);
}
