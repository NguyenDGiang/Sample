    using Microsoft.EntityFrameworkCore;
using Sample.Core.Entities;
using Sample.Shared.Common.Interfaces;
using Sample.Shared.Entities;
using System.Reflection;

namespace Sample.DataAccess.Persistence
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var decimalProps = modelBuilder.Model
                .GetEntityTypes()
                .SelectMany(t => t.GetProperties())
                .Where(p => (System.Nullable.GetUnderlyingType(p.ClrType) ?? p.ClrType) == typeof(decimal));

            foreach (var property in decimalProps)
            {
                property.SetPrecision(18);
                property.SetScale(2);
            }
            modelBuilder.Entity<Product>().Property(x => x.Id).HasDefaultValueSql("NEWID()");
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
        public override int SaveChanges()
        {
            foreach(var entry in ChangeTracker.Entries<IAuditable>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.UtcNow;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTime.UtcNow;
                        break;
                }
            }
            return  base.SaveChanges();
        }

        //Dbset
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<UploadFile> UploadFiles { get; set; }
        public DbSet<Sample.Core.Entities.Attribute> Attributes { get; set; }
        public DbSet<AttributeProduct> AttributeProducts { get; set; }
        public DbSet<ProductVariant> ProductVariants { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
    }
}
