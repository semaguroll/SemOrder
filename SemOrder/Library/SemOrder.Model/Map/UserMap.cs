using Microsoft.EntityFrameworkCore;
using SemOrder.Core.Map;
using SemOrder.Model.Entities;
using SemOrder.Model.Map.Base;
using System;

namespace SemOrder.Model.Map
{
    public class UserMap : IEntityBuilder
    {
        public void Build(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");
                entity.HasExtended();

                entity.Property(x => x.FirstName).HasMaxLength(50).IsRequired(true);
                entity.Property(x => x.LastName).HasMaxLength(50).IsRequired(true);
                entity.Property(x => x.ImageUrl).HasMaxLength(200).IsRequired(false);
                entity.Property(x => x.Email).HasMaxLength(150).IsRequired(true);
                entity.Property(x => x.Password).HasMaxLength(20).IsRequired(true);
                entity.Property(x => x.IsActive).IsRequired(true);
            });
        }
    }
}
