using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NWJProject1.DTOs
{
    public class UserDTO
    {
        public int? UserId { get; set; }
        public string? FullName { get; set; } = null!;
        public string? Gender { get; set; }
        public string Address { get; set; } = null!;
        public string? PhoneNumber { get; set; }
        public string? Status { get; set; }
        public int GroupId { get; set; }
        public string GroupName { get; set; }
    }
}
