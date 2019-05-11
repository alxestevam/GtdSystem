using GtdSystem.BackService.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GtdSystem.BackService.Models
{
    public enum Type { inbox, next, someday, references };

    public class UserTask
    {
        public virtual AplicationUser AplicationUser { get; set; }

        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime Deadline { get; set; }

        [Required]
        public Type Type { get; set; }

        public int NecessaryTime { get; set; }

        public int Priority { get; set; }

        public bool Done { get; set; }

        public List<Subtask> Subtasks { get; set; }

        public Context TaskContext { get; set; }
    }
}
