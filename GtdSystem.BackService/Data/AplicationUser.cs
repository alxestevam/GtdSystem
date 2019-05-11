using GtdSystem.BackService.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GtdSystem.BackService.Data
{
    public class AplicationUser : IdentityUser
    {
        public virtual List<UserTask> UserTasks { get; set; }

    }
}
