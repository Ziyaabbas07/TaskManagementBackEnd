using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class Team
    {
        [Key]
        public int TeamId { get; set; }
        public string? TeamName { get; set; }
        public virtual List<Users> Members { get; set; } = new();
    }
}
