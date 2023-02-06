using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Shared.Dtos.AttributeProducts
{
    public class CreateAttributeProductDto
    {
        [Validation("Không được để trống")]
        public string value { get; set; }
        [Validation("Không được để trống")]
        public int AttributeId { get; set; }
    }
}
