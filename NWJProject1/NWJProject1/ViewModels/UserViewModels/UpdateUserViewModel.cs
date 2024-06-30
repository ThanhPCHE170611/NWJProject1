using NWJProject1.Commands;
using NWJProject1.DTOs;
using NWJProject1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace NWJProject1.ViewModels
{
    public class UpdateUserViewModel
    {
        public UserDTO selectedUser { get; set; }
        public ICommand UpdateUserCommand { get; set; }
        public string? FullName { get; set; }
        public string? Gender { get; set; }
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Status { get; set; }
        public int? GroupId { get; set; }
        public List<string> Genders { get; set; }
        public List<UserGroup> Groups { get; set; }

        public UpdateUserViewModel(UserDTO SelectedUser)
        {
            FullName = SelectedUser.FullName;
            Gender = SelectedUser.Gender;
            Address = SelectedUser.Address;
            PhoneNumber = SelectedUser.PhoneNumber;
            Status = SelectedUser.Status;
            GroupId = SelectedUser.GroupId;
            this.selectedUser = SelectedUser;
            Genders = new List<string> { "Male", "Female" };
            Groups = GroupManager.GetAllGroups().ToList();
            UpdateUserCommand = new RelayCommand(UpdateUser, CanDeleteUser);
        }

        private void UpdateUser(object obj)
        {
            //update the selectedUserInfor:
            selectedUser.FullName = FullName;
            selectedUser.Gender = Gender;
            selectedUser.Address = Address;
            selectedUser.PhoneNumber = PhoneNumber;
            selectedUser.Status = Status;
            selectedUser.GroupId = GroupId.Value;
            selectedUser.GroupName = Groups.FirstOrDefault(x => x.GroupId == GroupId.Value).GroupName;
            UserManager.UpdateUser(selectedUser);
            var alertReslut = MessageBox.Show("Update User success!", "Alert!", MessageBoxButton.OK);
            if (alertReslut == MessageBoxResult.OK)
            {
                var currentWindow = obj as Window;
                currentWindow.Close();
            }
        }

        private bool CanDeleteUser(object obj)
        {
            return true;
        }
    }
}
