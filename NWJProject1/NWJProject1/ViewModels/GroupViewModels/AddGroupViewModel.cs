using NWJProject1.Commands;
using NWJProject1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace NWJProject1.ViewModels.GroupViewModels
{
    class AddGroupViewModel
    {
        public ICommand AddGroupCommand { get; set; }
        public string? GroupName { get; set; }
        public string? GroupDescription { get; set; }
        public string? Status { get; set; }
        public AddGroupViewModel()
        {
            AddGroupCommand = new RelayCommand(AddGroup, CanAddGroup);
        }

        private void AddGroup(object obj)
        {
            GroupManager.AddUserGroup(new UserGroup
            {
                GroupName = GroupName,
                Status = Status,
                GroupDescription = GroupDescription
            });
            var alertReslut = MessageBox.Show("Add Group success!", "Alert!", MessageBoxButton.OK);
            if (alertReslut == MessageBoxResult.OK)
            {
                var currentWindow = obj as Window;
                currentWindow.Close();
            }
        }

        private bool CanAddGroup(object obj)
        {
            return true;
        }
    }
    
}
