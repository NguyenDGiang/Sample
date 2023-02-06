﻿using Sample.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.DataAccess.Repositories.RefreshTokens
{
    public interface IRefreshTokenRepository : IRepository<RefreshToken, int>
    {
    }
}
