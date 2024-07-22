using Sample.Shared.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Core.Entities
{
    [Table("AttributeProduct")]
    public class AttributeProduct : EntityAuditBase<int>
    {
        public string value { get; set; }
        public Attribute Attribute { get; set; }
        public Product Product { get; set; }    
    }
}
