using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class TaskNote
    {
        [Key]
        public int TaskNoteId { get; set; }
        public string Note { get; set; } = null!;
        public int TaskId { get; set; }
        public virtual Tasks Task { get; set; } = null!;
    }
}
