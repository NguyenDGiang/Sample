using Sample.Core.Entities;
using Sample.DataAccess.Persistence;
using Sample.DataAccess.Repositories.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.DataAccess.Repositories.AttributeProducts
{
    public class AttributeProductRepository : Repository<AttributeProduct, int>, IAttributeProductRepository
    {
        public AttributeProductRepository(DatabaseContext appContext) : base(appContext)
        {
        }
    }
}
