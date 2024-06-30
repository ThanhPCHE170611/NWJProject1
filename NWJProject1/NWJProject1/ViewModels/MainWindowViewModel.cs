using NWJProject1.Commands;
using NWJProject1.Views;
using NWJProject1.Views.GroupViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NWJProject1.ViewModels
{
    public class MainWindowViewModel
    {
        public ICommand ShowUserHomePage {  get; set; }
        public ICommand ShowGroupHomePage { get; set; }

        public MainWindowViewModel()
        {
            ShowUserHomePage = new RelayCommand(ShowUserHomeWindow, CanShow);
            ShowGroupHomePage = new RelayCommand(ShowGroupHomwWindow, CanShow);
        }

        private void ShowGroupHomwWindow(object obj)
        {
            GroupHomePage groupHomePage = new GroupHomePage();
            groupHomePage.Show();
        }

        private void ShowUserHomeWindow(object obj)
        {
            UserHomePage userHomePage = new UserHomePage();
            userHomePage.Show();
        }

        private bool CanShow(object obj)
        {
            return true;
        }
    }
}
