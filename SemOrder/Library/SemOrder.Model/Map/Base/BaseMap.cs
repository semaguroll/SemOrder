using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SemOrder.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace SemOrder.Model.Map.Base
{
    public static class BaseMap
    {
        public static void HasExtended<T>(this EntityTypeBuilder<T> entity) where T : CoreEntity
        {
            entity.HasKey(x => x.ID);
            entity.Property(x => x.ID).ValueGeneratedOnAdd();

            entity.Property(x => x.Status).IsRequired(true);
        }
    }
}
