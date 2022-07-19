using Microsoft.EntityFrameworkCore;
using SemOrder.Core.Map;
using SemOrder.Model.Entities;
using SemOrder.Model.Map.Base;
using System;

namespace SemOrder.Model.Map
{
    public class ReservationMap : IEntityBuilder
    {
        public void Build(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Reservation>(entity =>
            {
                entity.ToTable("Reservation");

                entity.HasExtended();

                entity.Property(x => x.Message).HasMaxLength(50).IsRequired(false);
                entity.Property(x => x.ReservationDate).HasConversion(typeof(DateTime)).IsRequired(true);
                entity.Property(x => x.ReservationTime).HasMaxLength(10).IsRequired(true);
                entity.Property(x=>x.NumberOfPerson).IsRequired(true);

                entity
                .HasOne(b => b.User)
                .WithMany(c => c.Reservations)
                .HasForeignKey(b => b.UserId);

                entity
                .HasOne(b => b.Table)
                .WithMany(t => t.Reservations)
                .HasForeignKey(b => b.TableId);
            }
            );
        }
    }
}
