using NWJProject1.DTOs;
using NWJProject1.Models;
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
    /// Interaction logic for UserHomePage.xaml
    /// </summary>
    public partial class UserHomePage : Window
    {
        public UserHomePage()
        {
            InitializeComponent();
            UserHomePageViewModel userHomePageViewModel = new UserHomePageViewModel();
            this.DataContext = userHomePageViewModel;
        }

        private void FilterTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            UserList.Items.Filter = FilterMethod;
        }
        private bool FilterMethod(object obj)
        {
            var user = (UserDTO)obj;

            return user.FullName.Contains(FilterTextBox.Text, StringComparison.OrdinalIgnoreCase);


        }
    }
}
