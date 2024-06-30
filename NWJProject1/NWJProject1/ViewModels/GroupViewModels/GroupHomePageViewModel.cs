using NWJProject1.Commands;
using NWJProject1.Models;
using NWJProject1.Views;
using NWJProject1.Views.GroupViews;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace NWJProject1.ViewModels.GroupViewModels
{
    class GroupHomePageViewModel
    {
        public ObservableCollection<UserGroup> Groups { get; set; }
        public UserGroup SelectedGroup { get; set; }
        public ICommand ShowWindowCommand { get; set; }
        public ICommand ShowDeleteWCommand { get; set; }
        public ICommand ShowUpdateWCommand { get; set; }
        public GroupHomePageViewModel()
        {
            Groups = GroupManager.GetAllGroups();
            ShowWindowCommand = new RelayCommand(ShowAddWindow, CanShowWindow);
            ShowDeleteWCommand = new RelayCommand(ShowDeleteWindow, CanShowWindow);
            ShowUpdateWCommand = new RelayCommand(ShowUpdateWindow, CanShowWindow);
        }

        private void ShowUpdateWindow(object obj)
        {
            if (SelectedGroup != null)
            {
                //yse => redirect to delete window and show realte information 
                var parrentWindow = obj as Window;

                UpdateGroup updateGroup = new UpdateGroup(SelectedGroup);
                updateGroup.Owner = parrentWindow;
                updateGroup.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                parrentWindow.Opacity = 0.4;
                updateGroup.ShowDialog();
                parrentWindow.Opacity = 1;
            }
            else
            {
                //no => Show message box that must selected one User
                MessageBox.Show("Must selected User to use this future", "Alert!", MessageBoxButton.OK);
            }
        }

        private void ShowDeleteWindow(object obj)
        {
            if (SelectedGroup != null)
            {
                var parrentWindow = obj as Window;

                DeleteGroup deleteGroup = new DeleteGroup(SelectedGroup);
                deleteGroup.Owner = parrentWindow;
                deleteGroup.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                parrentWindow.Opacity = 0.4;
                deleteGroup.ShowDialog();
                parrentWindow.Opacity = 1;
            } else
            {
                MessageBox.Show("Must selected Group to use this future", "Alert!", MessageBoxButton.OK);
            }
                
        }

        private void ShowAddWindow(object obj)
        {
            var parrentWindow = obj as Window;

            AddGroup addGroup = new AddGroup();
            addGroup.Owner = parrentWindow;
            addGroup.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            parrentWindow.Opacity = 0.4;
            addGroup.ShowDialog();
            parrentWindow.Opacity = 1;
        }

        private bool CanShowWindow(object obj)
        {
            return true;
        }
    }
}
