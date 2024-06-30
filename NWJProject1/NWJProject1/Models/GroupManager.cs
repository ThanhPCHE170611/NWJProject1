using Microsoft.EntityFrameworkCore;
using NWJProject1.DTOs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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

        public static void AddUserGroup(UserGroup group)
        {
            try
            {
                Groups.Add(group);
                context.UserGroups.Add(group);
                context.SaveChanges();
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
        public static bool DeleteUserGroup(UserGroup group)
        {
            try
            {
                UserGroup groupInDb = context.UserGroups.Include(x => x.Users).FirstOrDefault(x => x.GroupId == group.GroupId);
                if(groupInDb == null) {
                    groupInDb = context.UserGroups.Include(x => x.Users).OrderBy(x => x.GroupId).LastOrDefault();
                }
                // show up the number of user relate with group:
                var alertResult = MessageBox.Show($"Number of user relate: {groupInDb.Users.Count()}", "Important Lert", MessageBoxButton.OKCancel);
                if(alertResult == MessageBoxResult.OK)
                {
                    foreach (var user in groupInDb.Users.Select(user => new UserDTO
                    {
                        FullName = user.FullName,
                        Gender = (user.Gender == true ? "Male" : "Female"),
                        Address = user.Address,
                        PhoneNumber = user.PhoneNumber,
                        Status = user.Status,
                        GroupId = user.GroupId,
                    }))
                    {
                        UserManager.Users.Remove(user);
                    }
                    context.RemoveRange(groupInDb.Users);
                    groupInDb.Users = null;
                    context.Remove(groupInDb);
                    context.SaveChanges();
                    Groups.Remove(group);
                    return true;
                }
                else
                {
                    return false;
                }
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
                return false; 
            }
        }
    }
}
