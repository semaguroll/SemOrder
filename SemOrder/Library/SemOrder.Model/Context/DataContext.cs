﻿using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using SemOrder.Core.Entity;
using SemOrder.Core.Map;
using SemOrder.Model.Entities;
using SemOrder.Model.SeedData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SemOrder.Model.Context
{
    public class DataContext : DbContext
    {
        //Microsoft.AspNetCore.Http.Abstractions 2.2.0
        private readonly IHttpContextAccessor _httpContextAccessor;
        public DataContext(DbContextOptions<DataContext> options, IHttpContextAccessor httpContextAccessor)
            : base(options)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Table> Tables { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            RegisterMapping(modelBuilder);

            modelBuilder.ApplyConfiguration(new UserSeedData());
        }

        private void RegisterMapping(ModelBuilder modelBuilder)
        {
            var typeToRegister = new List<Type>();
            var dataAssembly = Assembly.GetExecutingAssembly();

            typeToRegister.AddRange(dataAssembly.DefinedTypes.Select(x => x.AsType()));
            foreach (var builderType in typeToRegister.Where(x => typeof(IEntityBuilder).IsAssignableFrom(x)))
            {
                if (builderType != null && builderType != typeof(IEntityBuilder))
                {
                    var builder = (IEntityBuilder)Activator.CreateInstance(builderType);
                    builder.Build(modelBuilder);
                }
            }
        }
        private Guid? GetUserId()
        {
            string userId = "";
            if (_httpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
            {
                var claims = _httpContextAccessor.HttpContext.User.Claims.ToList();
                userId = claims?.FirstOrDefault(x => x.Type.Equals("jti", StringComparison.OrdinalIgnoreCase))?.Value;
            }

            if (userId != null)
                return Guid.Parse(userId);
            else
                return Guid.Empty;
        }


    }
}
