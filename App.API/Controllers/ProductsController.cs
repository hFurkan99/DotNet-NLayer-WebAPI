using App.Services.Products;
using App.Services.Products.Create;
using App.Services.Products.Update;
using Microsoft.AspNetCore.Mvc;

namespace App.API.Controllers;

public class ProductsController(IProductService productService) : CustomBaseController
{
    [HttpGet]
    public async Task<IActionResult> GetAll() => CreateActionResult(await productService.GetAllAsync());

    [HttpGet]
    public async Task<IActionResult> GetPaged(int pageNumber, int pageSize) => CreateActionResult(await productService.GetPagedAsync(pageNumber, pageSize));

    [HttpGet]
    public async Task<IActionResult> GetTopPriceProducts(int count) => CreateActionResult(await productService.GetTopPriceProductsAsync(count));

    [HttpGet]
    public async Task<IActionResult> GetById(int id) => CreateActionResult(await productService.GetByIdAsync(id));

    [HttpPost]
    public async Task<IActionResult> Create(CreateProductRequest request) => CreateActionResult(await productService.CreateAsync(request));

    [HttpPut]
    public async Task<IActionResult> Update(UpdateProductRequest request) => CreateActionResult(await productService.UpdateAsync(request));

    [HttpPatch]
    public async Task<IActionResult> UpdateStock(int id, int stock) => CreateActionResult(await productService.UpdateStockAsync(id, stock));

    [HttpDelete]
    public async Task<IActionResult> Delete(int id) => CreateActionResult(await productService.DeleteAsync(id));
}
