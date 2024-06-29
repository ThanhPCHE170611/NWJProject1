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
    public  class UserManager
    {
        private static readonly NSJProject1Context context = new NSJProject1Context();



        public static ObservableCollection<UserDTO> Users { get; set; }

        public static ObservableCollection<UserDTO> GetAllUsers()
        {
            var userList = context.Users.Include(u => u.Group).Select( x => new UserDTO
            {
                UserId = x.UserId,
                FullName = x.FullName,
                Gender = (x.Gender.Value? "Male" : "Female"),
                Address = x.Address,
                PhoneNumber = x.PhoneNumber,
                Status = x.Status,
                GroupId = x.GroupId,
                GroupName = x.Group.GroupName
            }).ToList();

            Users = new ObservableCollection<UserDTO>(userList);
            return Users;
        }
        public static void AddUser(UserDTO user)
        {
            try
            {
                User newUser = new User
                {
                    FullName = user.FullName,
                    Gender = (user.Gender.Equals("Male") ? true : false),
                    Address = user.Address,
                    PhoneNumber = user.PhoneNumber,
                    Status = user.Status,
                    GroupId = user.GroupId,
                };
                Users.Add(user);
                context.Users.Add(newUser);
                context.SaveChanges();
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
        public static void DeleteUser(UserDTO user)
        {
            try
            {
                User userInDb = context.Users.FirstOrDefault(x => x.UserId == user.UserId);
                if (userInDb != null)
                {
                    Users.Remove(user);
                    context.Users.Remove(userInDb);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
    }
}
