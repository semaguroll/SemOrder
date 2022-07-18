using Microsoft.EntityFrameworkCore;
using SemOrder.Core.Map;
using SemOrder.Model.Entities;
using SemOrder.Model.Map.Base;
using System;

namespace SemOrder.Model.Map
{
    public class BookingMap : IEntityBuilder
    {
        public void Build(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Booking>(entity =>
            {
                entity.ToTable("Booking");

                entity.HasExtended();

                entity.Property(x => x.BookingDescription).HasMaxLength(50).IsRequired(false);
                entity.Property(x => x.BookingDate).HasConversion(typeof(DateTime)).IsRequired(true);
                entity.Property(x => x.BookingTime).HasMaxLength(10).IsRequired(true);
                entity.Property(x => x.IsActive).IsRequired(true);

                entity
                .HasOne(b => b.User)
                .WithMany(c => c.Bookings)
                .HasForeignKey(b => b.UserId);

                entity
                .HasOne(b => b.Table)
                .WithMany(t => t.Bookings)
                .HasForeignKey(b => b.TableId);
            }
            );
        }
    }
}
