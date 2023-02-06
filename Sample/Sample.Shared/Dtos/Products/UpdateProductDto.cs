using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Shared.Dtos.Products
{
    public class UpdateProductDto
    {
        [Validation("Nhập Id vào!!!")]
        public Guid Id { get; set; }
        [Validation("Nhập Tên vào!!!")]
        public string Name { get; set; }
    }
}
