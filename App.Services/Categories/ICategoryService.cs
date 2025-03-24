using App.Services.Categories.Create;
using App.Services.Categories.Dto;
using App.Services.Categories.Update;

namespace App.Services.Categories;

public interface ICategoryService
{
    Task<ServiceResult<CategoryWithProductsDto>> GetCategoryWithProductsAsync(int categoryId);
    Task<ServiceResult<IEnumerable<CategoryWithProductsDto>>> GetCategoriesWithProductsAsync();
    Task<ServiceResult<IEnumerable<CategoryDto>>> GetAllAsync();
    Task<ServiceResult<CategoryDto?>> GetByIdAsync(int id);
    Task<ServiceResult<int>> CreateAsync(CreateCategoryRequest request);
    Task<ServiceResult> UpdateAsync(UpdateCategoryRequest request);
    Task<ServiceResult> DeleteAsync(int id);
}
