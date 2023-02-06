using AutoMapper;
using Sample.Core.Entities;
using Sample.Shared.Dtos.AttributeProducts;
using Sample.Shared.Dtos.Attributes;
using Sample.Shared.Dtos.Categories;
using Sample.Shared.Dtos.Products;
using Sample.Shared.Dtos.ProductVariants;
using Sample.Shared.Dtos.UploadFiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Application.MappingProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateProductDto, Product>();
            CreateMap<UploadFile, InsertUploadFileRequest>();
            CreateMap<Category, CategoryDto>();
            CreateMap<Product, ProductReponse>();
            CreateMap<Product, ProductDto>();
            CreateMap<ProductVariant, ProductVariantDto>();
            CreateMap<AttributeProduct, AttributeProductDto>();
            CreateMap<Sample.Core.Entities.Attribute, AttributeDto>();
            CreateMap<CreateCategoryDto, Category>();
            CreateMap<UpdateCategoryDto, Category>();
            CreateMap<CreateAttributeDto, Sample.Core.Entities.Attribute>();
            CreateMap<CreateAttributeProductDto, AttributeProduct>();
            CreateMap<CreateProductMappingAttributeDto, ProductVariant>();
            CreateMap<UpdateProductDto, Product>();
            CreateMap<Product, ProductDto>()
                  .ForMember(dest => dest.Attributes, opt => opt.MapFrom(src => src.Attribute))
                  .ForMember(dest => dest.ProductVariants, opt => opt.MapFrom(src => src.ProductVariant))
                  .ForMember(dest => dest.CategoryDto, opt => opt.MapFrom(src => src.Category));
        }
    }
}
