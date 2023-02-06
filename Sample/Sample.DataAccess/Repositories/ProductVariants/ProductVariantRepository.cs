using Sample.Core.Entities;
using Sample.DataAccess.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.DataAccess.Repositories.ProductVariants
{
    public class ProductVariantRepository : Repository<ProductVariant, int>, IProductVariantRepository
    {
        public ProductVariantRepository(DatabaseContext appContext) : base(appContext)
        {
        }
    }
}
