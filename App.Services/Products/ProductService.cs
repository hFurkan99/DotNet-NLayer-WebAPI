﻿using App.Repositories;
using App.Repositories.Products;
using App.Services.ExceptionHandlers;
using App.Services.Products.Create;
using App.Services.Products.Dto;
using App.Services.Products.Update;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace App.Services.Products
{
    public class ProductService(IProductRepository productRepository, IUnitOfWork unitOfWork, IMapper mapper) : IProductService
    {
        public async Task<ServiceResult<IEnumerable<ProductDto>>> GetTopPriceProductsAsync(int count)
        {
            var products = await productRepository.GetTopPriceProductsAsync(count);

            var productsAsDto = mapper.Map<IEnumerable<ProductDto>>(products);

            return ServiceResult<IEnumerable<ProductDto>>.Success(productsAsDto);
        }

        public async Task<ServiceResult<IEnumerable<ProductDto>>> GetAllAsync()
        {
            var products = await productRepository.GetAll().ToListAsync();

            var productsAsDto = mapper.Map<List<ProductDto>>(products);

            return ServiceResult<IEnumerable<ProductDto>>.Success(productsAsDto);
        }

        public async Task<ServiceResult<PaginatedResult<ProductDto>>> GetPagedAsync(int pageNumber, int pageSize)
        {
            var paginatedProductsResults = await productRepository.GetPagedAsync(pageNumber, pageSize);

            var productsAsDto = mapper.Map<List<ProductDto>>(paginatedProductsResults.Items);

            var paginatedResult = new PaginatedResult<ProductDto>
            {
                Items = productsAsDto,
                TotalCount = paginatedProductsResults.TotalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };

            return ServiceResult<PaginatedResult<ProductDto>>.Success(paginatedResult);
        }


        public async Task<ServiceResult<ProductDto?>> GetByIdAsync(int id)
        {
            var product = await productRepository.GetByIdAsync(id);

            if(product is null) return 
                ServiceResult<ProductDto?>.Fail("Product not found", HttpStatusCode.NotFound);

            var productAsDto = mapper.Map<ProductDto>(product);

            return ServiceResult<ProductDto>.Success(productAsDto)!;
        }

        public async Task<ServiceResult<int>> CreateAsync(CreateProductRequest request)
        {
            var isProductNameExist = await productRepository.Where(x => x.Name == request.Name).AnyAsync();

            if (isProductNameExist)
                return ServiceResult<int>.Fail("Ürün ismi veritabanında bulunmaktadır.");

            var product = mapper.Map<Product>(request);

            await productRepository.AddAsync(product);
            await unitOfWork.SaveChangesAsync();

            return ServiceResult<int>.SuccessAsCreated(product.Id, $"/api/Products/GetById?id={product.Id}");
        }

        public async Task<ServiceResult> UpdateAsync(UpdateProductRequest request)
        {
            var product = await productRepository.GetByIdAsync(request.Id);
            if (product is null) 
                return ServiceResult.Fail("Product not found", HttpStatusCode.NotFound);

            var isProductNameExist = await productRepository.Where(x => x.Name == request.Name && x.Id != product.Id).AnyAsync();

            if (isProductNameExist)
                return ServiceResult.Fail("Ürün ismi veritabanında bulunmaktadır.");

            mapper.Map(request, product);

            productRepository.Update(product);
            await unitOfWork.SaveChangesAsync();

            return ServiceResult.Success(HttpStatusCode.NoContent);
        }

        public async Task<ServiceResult> UpdateStockAsync(int id, int stock)
        {
            var product = await productRepository.GetByIdAsync(id);
            if (product is null) return ServiceResult.Fail("Product not found", HttpStatusCode.NotFound);

            product.Stock = stock;

            productRepository.Update(product);
            await unitOfWork.SaveChangesAsync();

            return ServiceResult.Success(HttpStatusCode.NoContent);
        }

        public async Task<ServiceResult> DeleteAsync(int id)
        {
            var product = await productRepository.GetByIdAsync(id);
        
            productRepository.Delete(product!);
            await unitOfWork.SaveChangesAsync();

            return ServiceResult.Success(HttpStatusCode.NoContent);
        }
    }
}
