using Sample.Shared.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Shared.Dtos.Categories
{
    public class CategoryDto : EntityAuditBase<int>
    {
        public string Name { get; set; }
        public int? ParentId { get; set; }
        public List<CategoryDto>? CategoryChildren { get; set; }
    }
}
