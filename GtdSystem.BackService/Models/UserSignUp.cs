using GtdSystem.BackService.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GtdSystem.BackService.Models
{
    public class UserSignUp {
        public string username { get; set; }
        public string password { get; set; }
        public string email { get; set; }
    }
}
