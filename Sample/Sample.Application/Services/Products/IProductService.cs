using Sample.Core.Entities;
using Sample.Shared.Dtos.Products;
using Sample.Shared.SeedWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Application.Services.Products
{
    public interface IProductService
    {
<<<<<<< HEAD
        List<ProductDto> GetAll();
        ProductDto Get(Guid id);
        PagingList<ProductDto> GetPaging(PagingParamesters pagingParamesters);
        ApiResult<CreateProductDto>  Create(CreateProductDto product);
        ApiResult<CreateProductMappingAttributeDto> CreateMappingAttribute(CreateProductMappingAttributeDto createProductMappingAttributeDto);
        ApiResult<UpdateProductDto> Update(UpdateProductDto product);
        ApiResult<ProductDto> Update(Guid id);
        ApiResult Delete(Guid id);
        List<GetHomeProductCategoryDto> GetHomeProductCategory();
=======
        List<ProductReponse> GetAll();
        List<ProductReponse> Get(Guid id);
        List<ProductReponse> GetPaging();
        ApiResult<ProductReponse>  Create(CreateProductDto product);
        ApiResult<ProductReponse> Update(CreateProductDto product);
        ApiResult<ProductReponse> Update(Guid id);
>>>>>>> parent of acb1289 (update)
    }
}
