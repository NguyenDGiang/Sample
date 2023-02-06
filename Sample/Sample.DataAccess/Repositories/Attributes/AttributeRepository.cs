using Sample.DataAccess.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.DataAccess.Repositories.Attributes
{
    public class AttributeRepository : Repository<Sample.Core.Entities.Attribute, int>, IAttributeRepository
    {
        public AttributeRepository(DatabaseContext appContext) : base(appContext)
        {
        }
    }
}
