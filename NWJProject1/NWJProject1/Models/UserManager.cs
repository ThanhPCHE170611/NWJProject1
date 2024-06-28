using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NWJProject1.Models
{
    public  class UserManager
    {
        private static readonly NSJProject1Context context = new NSJProject1Context();



        public static ObservableCollection<User> Users { get; set; }

        public static ObservableCollection<User> GetAllUsers()
        {
            var userList = context.Users.ToList();

            Users = new ObservableCollection<User>(userList);
            return Users;
        }
        public static void AddUser(User user)
        {
            Users.Add(user);
            context.Users.Add(user);
            context.SaveChanges();
        }
    }
}
