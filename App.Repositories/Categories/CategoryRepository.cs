

using Microsoft.EntityFrameworkCore;

namespace App.Repositories.Categories;

public class CategoryRepository(AppDbContext context) : GenericRepository<Category>(context), ICategoryRepository
{
    public Task<Category?> GetCategoryWithProductsAsync(int id)
    {
        return Context.Categories
            .Include(x => x.Products)
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public IQueryable<Category> GetCategoriesWithProducts()
    {
        return Context.Categories.Include(x => x.Products).AsNoTracking();
    }
}
