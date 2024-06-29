using System.Collections;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
using System.Xml.Linq;
using NWJProject1.Commands;
using NWJProject1.DTOs;
using NWJProject1.Models;
using NWJProject1.Views;

namespace NWJProject1.ViewModels
{
    public class AddUserViewModel
    {
        private Boolean addOne = false;
        public ICommand AddUserCommand { get; set; }
        public string? FullName { get; set; }
        public string? Gender { get; set; }
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Status { get; set; }
        public int? GroupId { get; set;}

        public List<string> Genders { get; set; }
        public List<UserGroup> Groups { get; set; }

        public AddUserViewModel()
        {
            Genders = new List<string> { "Male", "Female" };
            Groups = GroupManager.GetAllGroups().ToList();
            AddUserCommand = new RelayCommand(AddUser, CanAddUser);
        }
        private bool CanAddUser(object obj)
        {
            return true;
        }

        private void AddUser(object obj)
        {

            UserManager.AddUser(new UserDTO{
                FullName = FullName, Gender = Gender,
                Address = Address, PhoneNumber = PhoneNumber,
                Status = Status, 
                GroupId = GroupId.Value,
                GroupName = Groups.FirstOrDefault(x => x.GroupId == GroupId.Value).GroupName.ToString(),
            });

            var alertReslut =  MessageBox.Show("Add User success!", "Alert!", MessageBoxButton.OK);
            if(alertReslut == MessageBoxResult.OK)
            {
                var currentWindow = obj as Window;
                currentWindow.Close();
            }
        }
    }
}
