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
    class UpdateGroupViewModel
    {
        public UserGroup selectedGroup { get; set; }
        public ICommand UpdateGroupCommand { get; set; }
        public string? GroupName { get; set; }
        public string? GroupDescription { get; set; }
        public string? Status { get; set; }
        public UpdateGroupViewModel(UserGroup SelectedGroup)
        {
            GroupName = SelectedGroup.GroupName;
            GroupDescription = SelectedGroup.GroupDescription;
            Status = SelectedGroup.Status;
            this.selectedGroup = SelectedGroup;
            UpdateGroupCommand = new RelayCommand(UpdateGroup, CanUpdateGroup);
        }

        private void UpdateGroup(object obj)
        {
            selectedGroup.GroupName = GroupName;
            selectedGroup.GroupDescription = GroupDescription;
            selectedGroup.Status = Status;
            GroupManager.UpdateGroup(selectedGroup);
            var alertReslut = MessageBox.Show("Update Group success!", "Alert!", MessageBoxButton.OK);
            if (alertReslut == MessageBoxResult.OK)
            {
                var currentWindow = obj as Window;
                currentWindow.Close();
            }
        }

        private bool CanUpdateGroup(object obj)
        {
            return true;
        }
    }
}
