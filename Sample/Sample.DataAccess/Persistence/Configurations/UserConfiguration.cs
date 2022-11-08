using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sample.Shared.Entities;

namespace Sample.DataAccess.Persistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(p => p.DisplayName)
                .HasMaxLength(50);

            builder.Property(p => p.UserName)
                .HasMaxLength(50);

            builder.Property(p => p.Email)
                .HasMaxLength(50);

            builder.Property(p => p.Password)
                .HasMaxLength(50);
            
        }
    }
}
