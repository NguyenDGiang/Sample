using AutoMapper;
using Sample.Core.Entities;
using Sample.Shared.Dtos.Categories;
using Sample.Shared.Dtos.Products;
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
            CreateMap<CreateProductDto, Product>()
                .ForMember(dest=>dest.Name,otp=> otp.MapFrom(src=>src.Name))
                .ForMember(dest => dest.Price, otp => otp.MapFrom(src => src.Price))
                .ForMember(dest => dest.SKU, otp => otp.MapFrom(src => src.SKU))
                .ForMember(dest => dest.Image, otp => otp.MapFrom(src => src.Image));
            CreateMap<UploadFile, InsertUploadFileRequest>();
            CreateMap<Category, CategoryReponse>();
            CreateMap<CreateCategoryDto, Category>();
            CreateMap<UpdateCategoryDto, Category>();
        }
    }
}
