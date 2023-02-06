using AutoMapper;
using Sample.DataAccess.Repositories.Attributes;
using Sample.Shared.Dtos.Attributes;
using Sample.Shared.Extensions;
using Sample.Shared.SeedWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Application.Services.Attributes
{
    public class AttributeService : IAttributeService
    {
        private readonly IAttributeRepository _attributeRepository;
        private readonly IMapper _mapper;
        public AttributeService(IAttributeRepository attributeRepository, IMapper mapper)
        {
            _attributeRepository = attributeRepository; 
            _mapper = mapper;   
        }
        public ApiResult<CreateAttributeDto> Create(CreateAttributeDto createAttributeDto)
        {
            var valid = createAttributeDto.CheckValidation<CreateAttributeDto>();
            if (valid.IsSuccess == false)
            {
                return new ApiErrorResult<CreateAttributeDto>(false, 400, valid.Message);
            }
            Sample.Core.Entities.Attribute attributeMapper = _mapper.Map<Sample.Core.Entities.Attribute>(createAttributeDto);
            _attributeRepository.Add(attributeMapper);
            return new ApiSuccessResult<CreateAttributeDto>(true, "Thêm mới thành công", 200, createAttributeDto);
        }
    }
}
