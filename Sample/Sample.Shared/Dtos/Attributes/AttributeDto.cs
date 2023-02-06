using Sample.Shared.Common;
using Sample.Shared.Dtos.AttributeProducts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Shared.Dtos.Attributes
{
    public class AttributeDto : EntityAuditBase<int>
    {
        public string Name { get; set; }
        public List<AttributeProductDto> AttributeProductDtos { get; set; }

    }
}
