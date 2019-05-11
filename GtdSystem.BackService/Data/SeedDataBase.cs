using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GtdSystem.BackService.Data
{
    public class SeedDatabase
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<UserTaskContext>();
            var userManager = serviceProvider.GetRequiredService<UserManager<AplicationUser>>();
            context.Database.EnsureCreated();

            if(!context.Users.Any())
            {
                AplicationUser user = new AplicationUser()
                {
                    Email = "a@b.com",
                    SecurityStamp = Guid.NewGuid().ToString(),
                    UserName = "teste"
                };

                userManager.CreateAsync(user, "Password@123");
            }
        }
    }
}
