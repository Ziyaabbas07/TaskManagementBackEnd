using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class Tasks
    {
        [Key]
        public int TaskId { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int AssignedTo { get; set; }
        public virtual Users AssignedUser { get; set; } = null!;
        public DateTime DueDate { get; set; }
        public TaskStatus Status { get; set; }
        public List<TaskAttachment> Attachments { get; set; } = new();
        public List<TaskNote> Notes { get; set; } = new();
    }
    public enum TaskStatus
    {
        Open,
        InProgress,
        Completed
    }

}
