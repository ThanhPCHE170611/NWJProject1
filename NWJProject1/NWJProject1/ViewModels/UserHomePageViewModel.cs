using NWJProject1.Commands;
using NWJProject1.DTOs;
using NWJProject1.Models;
using NWJProject1.Views;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace NWJProject1.ViewModels
{
    public class UserHomePageViewModel
    {
        public ObservableCollection<UserDTO> Users {get; set; }

        public UserDTO SelectedUser { get; set; }
        public ICommand ShowWindowCommand { get; set; }
        public ICommand ShowDeleteWCommand { get; set; }
        public ICommand ShowUpdateWCommand { get; set; }

        public UserHomePageViewModel()
        {
            Users = UserManager.GetAllUsers();
            ShowWindowCommand = new RelayCommand(ShowAddWindow, CanShowWindow);
            ShowDeleteWCommand = new RelayCommand(ShowDeleteWindow, CanShowWindow);
            ShowUpdateWCommand = new RelayCommand(ShowUpdateWindow, CanShowWindow);
        }

        private void ShowDeleteWindow(object obj)
        {
            //check if selected any User?
            if(SelectedUser != null)
            {
                //yse => redirect to delete window and show realte information 
                var parrentWindow = obj as Window;

                DeleteUser deleteUserWin = new DeleteUser(SelectedUser);
                deleteUserWin.Owner = parrentWindow;
                deleteUserWin.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                parrentWindow.Opacity = 0.4;
                deleteUserWin.ShowDialog();
                parrentWindow.Opacity = 1;
            }
            else
            {
                //no => Show message box that must selected one User
                MessageBox.Show("Must selected User to use this future","Alert!", MessageBoxButton.OK);
            }
        }

        private bool CanShowWindow(object obj)
        {
            return true;
        }

        private void ShowAddWindow(object obj)
        {
            var parrentWindow = obj as Window;
            
            AddUser addUserWin = new AddUser();
            addUserWin.Owner = parrentWindow;
            addUserWin.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            parrentWindow.Opacity = 0.4;
            addUserWin.ShowDialog();
            parrentWindow.Opacity = 1;
        }
        private void ShowUpdateWindow(object obj)
        {
            //check if selected any User?
            if (SelectedUser != null)
            {
                //yse => redirect to delete window and show realte information 
                var parrentWindow = obj as Window;

                UpdateUser updateUserWin = new UpdateUser(SelectedUser);
                updateUserWin.Owner = parrentWindow;
                updateUserWin.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                parrentWindow.Opacity = 0.4;
                updateUserWin.ShowDialog();
                parrentWindow.Opacity = 1;
            }
            else
            {
                //no => Show message box that must selected one User
                MessageBox.Show("Must selected User to use this future", "Alert!", MessageBoxButton.OK);
            }
        }
    }
}
