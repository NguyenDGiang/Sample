using Sample.Shared.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Shared.Dtos.Attributes
{
    public class CreateAttributeDto 
    {
        [Validation("Nhập Tên vào!!!")]
        public string Name { get; set; }
    }
}
