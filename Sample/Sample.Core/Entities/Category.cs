using Sample.Shared.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Core.Entities
{
    [Table("Category")]
    public class Category: EntityAuditBase<int>
    {
        public string Name { get; set; }
        public int? ParentId { get; set; }
    }
}
