using Domain.Entities.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class DishConfiguration : IEntityTypeConfiguration<Dish>
    {
        public void Configure(EntityTypeBuilder<Dish> builder)
        {
            builder.Property(d => d.Id).IsRequired();
            builder.Property(d => d.Name).IsRequired().HasMaxLength(100);
            builder.Property(d => d.Description).IsRequired().HasMaxLength(400);
            builder.Property(d => d.Price).HasColumnType("decimal(18,2)");
            builder.Property(d => d.PictureUrl).IsRequired();
            builder.HasOne(d => d.Type).WithMany().HasForeignKey(d => d.TypeId);
        }
    }

    public class DishTypeConfiguration : IEntityTypeConfiguration<DishType>
    {
        public void Configure(EntityTypeBuilder<DishType> builder)
        {
            builder.Property(p => p.Id).IsRequired().ValueGeneratedNever();
            builder.Property(p => p.Name).IsRequired().HasMaxLength(20);
        }
    }
}