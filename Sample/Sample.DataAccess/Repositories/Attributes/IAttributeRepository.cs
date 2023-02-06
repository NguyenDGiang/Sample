using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.DataAccess.Repositories.Attributes
{
    public interface IAttributeRepository : IRepository<Sample.Core.Entities.Attribute, int>
    {
    }
}
