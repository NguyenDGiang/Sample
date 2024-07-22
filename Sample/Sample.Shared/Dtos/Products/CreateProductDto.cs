using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Shared.Dtos.Products
{
    public class CreateProductDto
    {
        [Validation("Nhập Tên vào!!!")]
        public string Name { get; set; }
        public string SKU { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }
    }
}
