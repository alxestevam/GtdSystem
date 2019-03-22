using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GtdSystem.BackService.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        [RegularExpression("[a-zA-Z]")]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public List<UserTask> Tasks { get; set; }
    }
}
