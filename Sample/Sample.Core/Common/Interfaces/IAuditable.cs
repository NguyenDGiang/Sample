using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Shared.Common.Interfaces
{
    public interface IAuditable:IDateTracking
    {
        public bool? IsDelete { get; set; }
    }
}
