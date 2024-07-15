using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.DTOs.Requests
{
    public class TasksRequest
    {
        public int TaskId { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int AssignedTo { get; set; }
        public DateTime DueDate { get; set; }
        public DataLayer.Models.TaskStatus Status { get; set; }
    }
    public class TaskNotesRequest
    {
        public int TaskNoteId { get; set; }
        public string Note { get; set; } = null!;
        public int TaskId { get; set; }
    }
    public class TaskAttachmentsRequest
    {
        public int TaskAttachmentId { get; set; }
        public string? FilePath { get; set; } = null!;
        public int TaskId { get; set; }
    }
}
