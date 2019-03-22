using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GtdSystem.BackService.Models
{
    public class Subtask
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public bool Done { get; set; }
    }
}
