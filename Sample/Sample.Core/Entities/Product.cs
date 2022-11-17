using Sample.Shared.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Core.Entities
{
    public class Product : EntityAuditBase<Guid>
    {
        public string Name { get; set; }
        public string SKU { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }
        public Category? Category { get; set; }  
    }
}
