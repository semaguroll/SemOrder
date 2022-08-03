using Microsoft.EntityFrameworkCore;
using SemOrder.Core.Map;
using SemOrder.Model.Entities;
using SemOrder.Model.Map.Base;
using System;

namespace SemOrder.Model.Map
{
    public class FoodMap : IEntityBuilder
    {
        public void Build(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Food>(entity =>
            {
                entity.ToTable("Food");
                entity.HasExtended();

                entity.Property(x => x.Name).HasMaxLength(50).IsRequired(true);
                entity.Property(x => x.Description).HasMaxLength(300).IsRequired(false);
                entity.Property(x => x.Price).IsRequired(true);
                entity.Property(x => x.ImageUrl).HasMaxLength(200).IsRequired(false);

                entity
                .HasOne(f => f.Category)
                .WithMany(c => c.Foods)
                .HasForeignKey(f => f.CategoryId);

           

            });
        }
    }
}
