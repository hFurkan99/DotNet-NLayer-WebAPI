using App.Repositories.Products;

namespace App.Repositories.Categories;

public class Category : BaseEntity<int>, IAuditEntity
{
    public string Name { get; set; } = default!;
    public DateTime Created { get; set; }
    public DateTime? Updated { get; set; }

    public List<Product>? Products { get; set; }
}
