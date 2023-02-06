using Sample.Shared.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Shared.Dtos.AttributeProducts
{
    public class AttributeProductDto : EntityAuditBase<int>
    {
        public string value { get; set; }
    }
}
