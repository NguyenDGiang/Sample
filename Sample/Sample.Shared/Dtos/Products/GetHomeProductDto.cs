using Sample.Shared.Dtos.AttributeProducts;
using Sample.Shared.Dtos.ProductVariants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Shared.Dtos.Products
{
    public class GetHomeProductCategoryDto
    {
        public string CategoryName { get; set; }
        public List<ProductHomeDto> productDtos { get; set; }
    }
    public class ProductHomeDto
    {
        public string Name { get; set; }
        public List<ProductVariantDto> ProductVariants { get; set; }
    }
}
