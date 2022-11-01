using Sample.Core.Entities;
using Sample.Shared.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.DataAccess.Persistence
{
    public static class DatabaseContextSeed
    {
        public static async Task SeedDatabaseAsync(DatabaseContext context)
        {
            User user = new User()
            {
                UserName = "NguyenGiang",
                Email = "nguyengiang99oe@gmail.com",
                DisplayName = "NguyenGiang",
                StoreSalt = Cryptography.EncryptPassword("Giang").Salt,
                Password = Cryptography.EncryptPassword("Giang").Hash,
      
            };

            if (!context.Users.Any())
            {
                await context.Users.AddAsync(user);
                await context.SaveChangesAsync();   
            }
        }
    }
}
