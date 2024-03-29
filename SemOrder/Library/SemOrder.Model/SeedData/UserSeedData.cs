﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SemOrder.Common.Enums;
using SemOrder.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SemOrder.Model.SeedData
{
      public class UserSeedData : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(
                new User
                {
                    ID = Guid.NewGuid(),
                    Status = Status.Active,
                    Email = "admin@admin.com",
                    Password = "123",
                    FirstName = "Admin",
                    LastName = "ADMIN",
                    ImageUrl = "/",
                });
        }
    }
}
