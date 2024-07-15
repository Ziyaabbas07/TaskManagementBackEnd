using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.DTOs.Responses
{
    public class UserResponse
    {
        public int UserId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string RoleMaster { get; set; }
        public string Email { get; set; } = null!;
        public string? PhoneNumber { get; set; }
        public int TeamId { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public bool Status { get; set; } = true;
    }
}
