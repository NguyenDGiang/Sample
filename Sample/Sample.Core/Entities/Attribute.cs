using Sample.Shared.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Core.Entities
{
    [Table("Attribute")]
    public class Attribute : EntityAuditBase<int>
    {
        public string Name { get; set; }
        public ICollection<AttributeProduct> AttributeProduct { get; set; }
        [ForeignKey("Product")]
        public Guid? ProductId { get; set; }
        public Product? Product { get; set; }
    }
}
