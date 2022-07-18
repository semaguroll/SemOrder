using Microsoft.EntityFrameworkCore;
using SemOrder.Core.Map;
using SemOrder.Model.Entities;
using SemOrder.Model.Map.Base;
using System;

namespace SemOrder.Model.Map
{
    public class CategoryMap : IEntityBuilder
    {
        public void Build(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");
                entity.HasExtended();

                entity.Property(x => x.Name).HasMaxLength(50).IsRequired(true);
                entity.Property(x => x.Description).HasMaxLength(300).IsRequired(false);
                entity.Property(x => x.ImageUrl).HasMaxLength(200).IsRequired(false);

            });
        }
    }
}
