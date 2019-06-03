using GtdSystem.BackService.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GtdSystem.BackService.Models
{
    public class TaskFront
    {
        public string Title { get; set; }

        public DateTime Deadline { get; set; }
    }
}
