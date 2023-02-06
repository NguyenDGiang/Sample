using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Shared.Dtos.Products
{
    public class CreateProductMappingAttributeDto
    {
        [Validation("Nhập Tên vào!!!")]
        public int AttributeId { get; set; }
        public Guid ProductId { get; set; }
        public int AttributeProductId { get; set; } 
        public decimal Price { get; set; }
        public decimal Quantity { get; set; }   
        public string Sku { get; set; }
    } 
}
