using Sample.Shared.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Shared.Dtos.ProductVariants
{
    public class ProductVariantDto : EntityAuditBase<int>
    {
        public string Sku { get; set; }
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
