using NWJProject1.Commands;
using NWJProject1.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NWJProject1.ViewModels
{
    public class UserHomePageViewModel
    {
        public ObservableCollection<User> Users {get; set; }
        public ICommand ShowWindowCommand { get; set; }

        public UserHomePageViewModel()
        {
            Users = UserManager.GetAllUsers();
            ShowWindowCommand = new RelayCommand(ShowWindow, CanShowWindow);
        }

        private bool CanShowWindow(object obj)
        {
            return true;
        }

        private void ShowWindow(object obj)
        {
            throw new NotImplementedException();
        }
    }
}
