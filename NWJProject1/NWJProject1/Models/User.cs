using System;
using System.Collections.Generic;

namespace NWJProject1.Models
{
    public partial class User
    {
        public int UserId { get; set; }
        public string FullName { get; set; } = null!;
        public bool? Gender { get; set; }
        public string Address { get; set; } = null!;
        public string? PhoneNumber { get; set; }
        public string? Status { get; set; }
        public int GroupId { get; set; }

        public virtual UserGroup Group { get; set; } = null!;
    }
}
