using NWJProject1.Models;
using System.Windows.Input;
using NWJProject1.DTOs;
using NWJProject1.Commands;
using NWJProject1.Views;
using System.Windows;

namespace NWJProject1.ViewModels
{
    class DeleteUserViewModel
    {
        public UserDTO selectedUser { get; set; }
        public ICommand DeleteUserCommand { get; set; }
        public string? FullName { get; set; }
        public string? Gender { get; set; }
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Status { get; set; }
        public int? GroupId { get; set; }
        public List<string> Genders { get; set; }
        public List<UserGroup> Groups { get; set; }

        public DeleteUserViewModel(UserDTO SelectedUser)
        {
            FullName = SelectedUser.FullName;
            Gender = SelectedUser.Gender;
            Address = SelectedUser.Address;
            PhoneNumber = SelectedUser.PhoneNumber;
            Status = SelectedUser.Status;
            GroupId = SelectedUser.GroupId;
            this.selectedUser = SelectedUser;
            Genders = new List<string> { Gender };
            Groups = new List<UserGroup> { new UserGroup(){
                GroupId = SelectedUser.GroupId,
                GroupName = SelectedUser.GroupName,
            } };
            DeleteUserCommand = new RelayCommand(DeleteUser, CanDeleteUser);
        }

        private bool CanDeleteUser(object obj)
        {
            return true;
        }
        private void DeleteUser(object obj)
        {
            UserManager.DeleteUser(selectedUser);
            var alertReslut = MessageBox.Show("Delete User success!", "Alert!", MessageBoxButton.OK);
            if (alertReslut == MessageBoxResult.OK)
            {
                var currentWindow = obj as Window;
                currentWindow.Close();
            }
        }
    }
}
