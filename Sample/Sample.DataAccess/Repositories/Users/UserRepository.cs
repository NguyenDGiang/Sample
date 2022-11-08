using Sample.Shared.Entities;
using Sample.DataAccess.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.DataAccess.Repositories.Users
{
    public class UserRepository : Repository<User, Guid>, IUserRepository
    {
        public UserRepository(DatabaseContext appContext) : base(appContext)
        {
        }
    }
}
