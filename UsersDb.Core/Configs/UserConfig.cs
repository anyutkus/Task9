using UsersDb_Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace UsersDb_Core.Configs
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> entity)
        {
            entity.ToTable(nameof(User));

            entity.HasKey(x => x.Id);
            entity.HasIndex(x => x.Email).IsUnique();
            entity.Property(x => x.Email).IsRequired().IsUnicode().HasMaxLength(128);
            entity.Property(x => x.PasswordHash).IsRequired().IsUnicode().HasMaxLength(128);
            entity.Property(x => x.FirstName).IsRequired().IsUnicode().HasMaxLength(128);
            entity.Property(x => x.LastName).IsRequired().IsUnicode().HasMaxLength(128);
            entity.Property(x => x.Status).IsRequired();

            entity.HasMany(r => r.Roles)
                .WithMany(u => u.Users)
                .UsingEntity<UserRole>(
                    right => right.HasOne<Role>().WithMany().HasForeignKey(x => x.RoleId),
                    left => left.HasOne<User>().WithMany().HasForeignKey(x => x.UserId),
                    join => join.ToTable("UserRole"));
        }
    }
}

