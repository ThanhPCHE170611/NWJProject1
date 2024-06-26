using System;
using System.Collections.Generic;

namespace NWJProject1.Models
{
    public partial class UserGroup
    {
        public UserGroup()
        {
            Users = new HashSet<User>();
        }

        public int GroupId { get; set; }
        public string GroupName { get; set; } = null!;
        public string GroupDescription { get; set; } = null!;
        public string? Status { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
