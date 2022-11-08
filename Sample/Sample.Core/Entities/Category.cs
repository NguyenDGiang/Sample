using Sample.Shared.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Core.Entities
{
    public class Category: EntityAuditBase<Guid>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
