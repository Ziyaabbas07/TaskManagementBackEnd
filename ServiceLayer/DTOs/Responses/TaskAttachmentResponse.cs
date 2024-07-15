using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.DTOs.Responses
{
    public class TaskAttachmentResponse
    {
        public int TaskAttachmentId { get; set; }
        public string FilePath { get; set; } = null!;
        public string FileName { get; set; } = null!;
        public int TaskId { get; set; }
    }
}
