﻿using GtdSystem.BackService.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GtdSystem.BackService.Data
{
    public class UserTaskContext : IdentityDbContext<AplicationUser>
    {
        public DbSet<UserTask> UserTasks { get; set; }

        public UserTaskContext(DbContextOptions<UserTaskContext> options) : base(options)
        { }

        public UserTaskContext() { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
        }

        public static void SeedData(IServiceProvider serviceProvider)
        {
            using (var serviceScope = serviceProvider
                .GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.
                    ServiceProvider.GetService<UserTaskContext>();

                if (context.UserTasks.Any()) return;

                context.Database.EnsureCreated();

                context.UserTasks.AddRange(new UserTask[]
                {
                    new UserTask
                    {
                        Id = 1,
                        Title = "Do Something",
                        StartDate = DateTime.Now,
                        Done = false
                    }
                });
            }
        }
    }
}
