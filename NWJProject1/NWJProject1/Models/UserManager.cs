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



        public static ObservableCollection<UserDTO> Users = new ObservableCollection<UserDTO>(context.Users.Include(u => u.Group).Select(x => new UserDTO
        {
            UserId = x.UserId,
            FullName = x.FullName,
            Gender = (x.Gender.Value ? "Male" : "Female"),
            Address = x.Address,
            PhoneNumber = x.PhoneNumber,
            Status = x.Status,
            GroupId = x.GroupId,
            GroupName = x.Group.GroupName
        }).ToList());

        public static ObservableCollection<UserDTO> GetAllUsers()
        {
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
                } else
                {
                    userInDb = context.Users.OrderBy(x => x.UserId).LastOrDefault();
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
        public static void UpdateUser(UserDTO user)
        {
            try
            {
                User userInDb = context.Users.FirstOrDefault(x => x.UserId == user.UserId);

                //Update list
                UserDTO userInList = Users.FirstOrDefault(x => x.UserId == user.UserId);
                if (userInList != null)
                {
                    userInList.FullName = user.FullName;
                    userInList.Gender = user.Gender;
                    userInList.Address = user.Address;
                    userInList.PhoneNumber = user.PhoneNumber;
                    userInList.Status = user.Status;
                    userInList.GroupId = user.GroupId;
                    userInList.GroupName = user.GroupName;
                }
                if (userInDb != null)
                {
                    // update In Db:
                    userInDb.FullName = user.FullName;
                    userInDb.Gender = (user.Gender.Equals("Male") ? true : false);
                    userInDb.Address = user.Address;
                    userInDb.PhoneNumber = user.PhoneNumber;
                    userInDb.Status = user.Status;
                    userInDb.GroupId = user.GroupId;
                    context.SaveChanges();
                }
                else
                {
                    userInDb = context.Users.OrderBy(x => x.UserId).LastOrDefault();
                    userInDb.FullName = user.FullName;
                    userInDb.Gender = (user.Gender.Equals("Male") ? true : false);
                    userInDb.Address = user.Address;
                    userInDb.PhoneNumber = user.PhoneNumber;
                    userInDb.Status = user.Status;
                    userInDb.GroupId = user.GroupId;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
    }
}
