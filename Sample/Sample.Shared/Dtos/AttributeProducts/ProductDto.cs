using Sample.Shared.Common;
using Sample.Shared.Dtos.Attributes;
using Sample.Shared.Dtos.Categories;
using Sample.Shared.Dtos.Products;
using Sample.Shared.Dtos.ProductVariants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Shared.Dtos.AttributeProducts
{
    public class ProductDto : EntityAuditBase<Guid>, IProductDto
    {
        public string Name { get; set; }
        public List<AttributeDto> Attributes { get; set; }
        public List<ProductVariantDto> ProductVariants  { get; set; }
        public CategoryDto CategoryDto { get; set; }
       
    }
}
