using App.Repositories;

namespace App.Services.Products;

public interface IProductService
{
    Task<ServiceResult<IEnumerable<ProductDto>>> GetTopPriceProductsAsync(int count);
    Task<ServiceResult<IEnumerable<ProductDto>>> GetAllAsync();
    Task<ServiceResult<PaginatedResult<ProductDto>>> GetPagedAsync(int pageNumber, int pageSize);
    Task<ServiceResult<ProductDto?>> GetByIdAsync(int id);
    Task<ServiceResult<CreateProductResponse>> CreateAsync(CreateProductRequest request);
    Task<ServiceResult> UpdateAsync(UpdateProductRequest request);
    Task<ServiceResult> UpdateStockAsync(int id, int stock);
    Task<ServiceResult> DeleteAsync(int id);
}
