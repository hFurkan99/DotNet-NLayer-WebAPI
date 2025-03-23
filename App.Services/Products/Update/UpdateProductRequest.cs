namespace App.Services.Products.Update;

public record UpdateProductRequest(int Id, string Name, decimal Price, int Stock);