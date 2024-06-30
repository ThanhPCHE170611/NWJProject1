using NWJProject1.ViewModels;
using System.Windows;

namespace NWJProject1.Views
{
    public partial class AddUser : Window
    {
        public AddUser()
        {
            InitializeComponent();
            AddUserViewModel viewModel = new AddUserViewModel();
            this.DataContext = viewModel;
        }
    }
}
