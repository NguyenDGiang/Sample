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
        public Category? Category { get; set; }  
        public ICollection<Attribute> Attribute  { get; set; }  
        public ICollection<ProductVariant> ProductVariant { get; set; }
        
    }
}
