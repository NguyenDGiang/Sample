using Sample.Core.Entities;
using Sample.DataAccess.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.DataAccess.Repositories.RefreshTokens
{
    public class RefreshTokenRepository : Repository<RefreshToken, int>, IRefreshTokenRepository
    {
        public RefreshTokenRepository(DatabaseContext appContext) : base(appContext)
        {
        }
    }
}
