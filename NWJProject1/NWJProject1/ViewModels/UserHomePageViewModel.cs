using NWJProject1.Commands;
using NWJProject1.DTOs;
using NWJProject1.Models;
using NWJProject1.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace NWJProject1.ViewModels
{
    public class UserHomePageViewModel
    {
        public ObservableCollection<UserDTO> Users {get; set; }
        public ICommand ShowWindowCommand { get; set; }

        public UserHomePageViewModel()
        {
            Users = UserManager.GetAllUsers();
            ShowWindowCommand = new RelayCommand(ShowAddWindow, CanShowWindow);
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
    }
}
