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
    public class DeleteGroupViewModel
    {
        public UserGroup selectedGroup { get; set; }
        public ICommand DeleteGroupCommand { get; set; }
        public string? GroupName { get; set; }
        public string? GroupDescription { get; set; }
        public string? Status { get; set; }
        public DeleteGroupViewModel(UserGroup SelectedGroup)
        {
            GroupName = SelectedGroup.GroupName;
            GroupDescription = SelectedGroup.GroupDescription;
            Status = SelectedGroup.Status;
            this.selectedGroup = SelectedGroup;
            DeleteGroupCommand = new RelayCommand(DeleteGroup, CanDelete);
        }

        private void DeleteGroup(object obj)
        {
            bool deleteAction = GroupManager.DeleteUserGroup(selectedGroup);
            if(deleteAction)
            {
                var alertReslut = MessageBox.Show("Delete Group success!", "Alert!", MessageBoxButton.OK);
                if (alertReslut == MessageBoxResult.OK)
                {
                    var currentWindow = obj as Window;
                    currentWindow.Close();
                }
            }
            
        }

        private bool CanDelete(object obj)
        {
            return true;
        }
    }
}
