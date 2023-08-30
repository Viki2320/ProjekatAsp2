using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjekatASP.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatASP.DataAccess.Configurations
{
    public class DishConfiguration : IEntityTypeConfiguration<Dish>
    {
        public void Configure(EntityTypeBuilder<Dish> builder)
        {
            //builder.Property(x => x.UpdatedBy).HasMaxLength(50);
            //builder.Property(x => x.DeletedBy).HasMaxLength(50);

            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
            builder.HasIndex(a => a.Name).IsUnique();
            builder.Property(a => a.IsOnSale).HasDefaultValue(false);

            builder.HasMany(x => x.OrderLines).WithOne(x => x.Dish).HasForeignKey(x => x.DishId).OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.CartLines).WithOne(x => x.Dish).HasForeignKey(x => x.DishId).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(x => x.DishIngredients).WithOne(x => x.Dish).HasForeignKey(x => x.DishId).OnDelete(DeleteBehavior.Cascade);

            //builder.HasOne(x => x.Price).WithOne().
        }
    }
}
