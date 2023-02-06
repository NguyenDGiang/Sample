using Sample.Shared.Dtos.Attributes;
using Sample.Shared.SeedWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Application.Services.Attributes
{
    public interface IAttributeService
    {
        ApiResult<CreateAttributeDto> Create(CreateAttributeDto createAttributeDto);
        //ProductDto Get(Guid id);
        //PagingList<ProductDto> GetPaging(PagingParamesters pagingParamesters);
        //ApiResult<CreateProductDto> Create(CreateProductDto product);
        //ApiResult<CreateProductMappingAttributeDto> CreateMappingAttribute(CreateProductMappingAttributeDto createProductMappingAttributeDto);
        //ApiResult<UpdateProductDto> Update(UpdateProductDto product);
        //ApiResult<ProductDto> Update(Guid id);
        //ApiResult Delete(Guid id);
    }
}
