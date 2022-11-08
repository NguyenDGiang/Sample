using Sample.Shared.Entities;
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
            

            if (!context.Users.Any())
            {
                var encryptPassword = Cryptography.EncryptPassword("Giang");

                User user = new User()
                {
                    UserName = "NguyenGiang",
                    Email = "nguyengiang99oe@gmail.com",
                    DisplayName = "NguyenGiang",
                    StoreSalt = encryptPassword.Salt,
                    Password = encryptPassword.Hash,

                };
                await context.Users.AddAsync(user);
                await context.SaveChangesAsync();   
            }
        }
    }
}
