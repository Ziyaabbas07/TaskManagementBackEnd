using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.DTOs.Responses
{
    public class TaskNoteResponse
    {
        public int TaskNoteId { get; set; }
        public string Note { get; set; } = null!;
        public int TaskId{ get; set; }
    }
}
