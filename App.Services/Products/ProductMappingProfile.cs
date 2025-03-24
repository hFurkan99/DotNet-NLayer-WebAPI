using App.Repositories.Products;
using App.Services.Products.Create;
using App.Services.Products.Dto;
using App.Services.Products.Update;
using AutoMapper;

namespace App.Services.Products;

public class ProductMappingProfile : Profile
{
    public ProductMappingProfile()
    {
        CreateMap<Product, ProductDto>().ReverseMap();

        CreateMap<UpdateProductRequest, Product>().
            ForMember(dest => dest.Id, opt => opt.Ignore());

        CreateMap<CreateProductRequest, Product>();
    }
}
