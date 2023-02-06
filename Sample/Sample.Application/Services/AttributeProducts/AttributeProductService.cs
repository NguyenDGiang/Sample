using AutoMapper;
using Sample.Core.Entities;
using Sample.DataAccess.Repositories.AttributeProducts;
using Sample.Shared.Dtos.AttributeProducts;
using Sample.Shared.Extensions;
using Sample.Shared.SeedWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Application.Services.AttributeProducts
{
    public class AttributeProductService : IAttributeProductService
    {
        private readonly IAttributeProductRepository _attributeProductRepository;
        private readonly IMapper _mapper;
        public AttributeProductService(IAttributeProductRepository attributeProductRepository, IMapper mapper)
        {
            _mapper = mapper;
            _attributeProductRepository = attributeProductRepository;
        }
        public ApiResult<CreateAttributeProductDto> Create(CreateAttributeProductDto createAttributeProductDto)
        {
            var valid = createAttributeProductDto.CheckValidation<CreateAttributeProductDto>();
            if (valid.IsSuccess == false)
            {
                return new ApiErrorResult<CreateAttributeProductDto>(false, 400, valid.Message);
            }
            AttributeProduct attributeProductMapper = _mapper.Map<AttributeProduct>(createAttributeProductDto);
            
            _attributeProductRepository.Add(attributeProductMapper);
            return new ApiSuccessResult<CreateAttributeProductDto>(true, "Thêm mới thành công", 200, createAttributeProductDto);

        }
    }
}
