using Sample.Shared.Dtos.AttributeProducts;
using Sample.Shared.SeedWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Application.Services.AttributeProducts
{
    public interface IAttributeProductService
    {
        ApiResult<CreateAttributeProductDto> Create(CreateAttributeProductDto createAttributeProductDto);
    }
}
