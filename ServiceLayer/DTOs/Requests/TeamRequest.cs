using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.DTOs.Requests
{
    public class TeamRequest
    {
        public int TeamId { get; set; }
        public string? TeamName { get; set; }
    }
}
