using NWJProject1.DTOs;
using NWJProject1.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace NWJProject1.Views
{
    /// <summary>
    /// Interaction logic for UpdateUser.xaml
    /// </summary>
    public partial class UpdateUser : Window
    {
        public UpdateUser(UserDTO SelectedUser)
        {
            InitializeComponent();
            UpdateUserViewModel updateUserViewModel = new UpdateUserViewModel(SelectedUser);
            DataContext = updateUserViewModel;
        }
    }
}
