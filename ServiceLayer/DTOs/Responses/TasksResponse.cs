using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.DTOs.Responses
{
    public class TasksResponse
    {
        public int TaskId { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int AssignedTo { get; set; }
        public virtual Users AssignedUser { get; set; } = null!;
        public DateTime DueDate { get; set; }
        public DataLayer.Models.TaskStatus Status { get; set; }
    }
}
