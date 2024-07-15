using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class TaskAttachment
    {
        [Key]
        public int TaskAttachmentId { get; set; }
        public string FilePath { get; set; } = null!;
        public string FileName { get; set; } = null!;
        public int TaskId { get; set; }
        public virtual Tasks Task { get; set; } = null!;
    }
}
