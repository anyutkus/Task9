using UsersDb_Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace UsersDb_Core.Configs
{
    public class RoleConfig : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> entity)
        {
            entity.ToTable(nameof(Role));

            entity.HasKey(x => x.Id);
            entity.Property(x => x.Id).IsRequired().ValueGeneratedNever();
            entity.HasIndex(x => x.Name).IsUnique();
            entity.Property(x => x.Name).IsRequired().IsUnicode().HasMaxLength(32);
        }
    }
}

