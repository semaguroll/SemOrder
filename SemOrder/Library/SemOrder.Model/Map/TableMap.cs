using Microsoft.EntityFrameworkCore;
using SemOrder.Core.Map;
using SemOrder.Model.Entities;
using SemOrder.Model.Map.Base;
using System;

namespace SemOrder.Model.Map
{
    public class TableMap : IEntityBuilder
    {
        public void Build(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Table>(entity =>
            {
                entity.ToTable("Table");

                entity.HasExtended();

                entity.Property(x => x.TableNum).HasMaxLength(10).IsRequired(false);
            });
        }
    }
}
