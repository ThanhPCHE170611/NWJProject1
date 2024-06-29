using Microsoft.EntityFrameworkCore;
using NWJProject1.DTOs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NWJProject1.Models
{
    public class GroupManager
    {
        private static readonly NSJProject1Context context = new NSJProject1Context();
        public static ObservableCollection<UserGroup> Groups = new ObservableCollection<UserGroup>(context.UserGroups);
        public static ObservableCollection<UserGroup> GetAllGroups()
        {
            return Groups;
        }
    }
}
