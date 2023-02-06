using Sample.Core.Entities;
using Sample.Shared.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Shared.Dtos.Products
{
    public class ProductReponse: EntityAuditBase<Guid>
    {
        public string Name { get; set; }
        public Category? Category { get; set; }
    }
}
