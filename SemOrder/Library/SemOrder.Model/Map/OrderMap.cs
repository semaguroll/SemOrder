using Microsoft.EntityFrameworkCore;
using SemOrder.Core.Map;
using SemOrder.Model.Entities;
using SemOrder.Model.Map.Base;
using System;

namespace SemOrder.Model.Map
{
    public class OrderMap : IEntityBuilder
    {
        public void Build(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Order");
                entity.HasExtended();

                entity.Property(x => x.Quantity).HasConversion(typeof(int)).IsRequired(true);
                entity.Property(x => x.TotalPrice).HasConversion(typeof(int)).IsRequired(true);
                entity.Property(x => x.OrderDate).HasConversion(typeof(DateTime)).IsRequired(true);
                entity.Property(x => x.IsActive).IsRequired(true);

                entity
                .HasOne(o => o.User)
                .WithMany(c => c.Orders)
                .HasForeignKey(o => o.UserId);

                entity
                 .HasOne(o => o.Table)
                 .WithMany(t => t.Orders)
                 .HasForeignKey(o => o.TableId);
            });
        }
    }
}
