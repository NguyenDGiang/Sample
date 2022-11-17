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
        List<ProductReponse> GetAll();
        List<ProductReponse> Get(Guid id);
        List<ProductReponse> GetPaging();
        ApiResult<ProductReponse>  Create(CreateProductDto product);
        ApiResult<ProductReponse> Update(CreateProductDto product);
        ApiResult<ProductReponse> Update(Guid id);
    }
}
