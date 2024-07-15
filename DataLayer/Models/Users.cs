using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class Users
    {
        [Key]
        public int UserId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public RoleMaster RoleMaster { get; set; }
        public string Email { get; set; } = null!;
        public string? PasswordHash { get; set; }
        public string? SecurityStamp { get; set; }
        public string? PhoneNumber { get; set; }
        public int TeamId { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public bool Status { get; set; } = true;
        public virtual Team Team { get; set; } = null!;
        public virtual List<Tasks> Tasks { get; set; } = null!;

    }
    public enum RoleMaster
    {
        Employee,
        Manager,
        TL
    }
}
