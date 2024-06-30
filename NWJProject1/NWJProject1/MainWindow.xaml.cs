using System.Windows;
using NWJProject1.Views;
using NWJProject1.Views.GroupViews;
namespace NWJProject1
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnUser_Click(object sender, RoutedEventArgs e)
        {
            UserHomePage userHomePage = new UserHomePage();
            userHomePage.Show();
        }

        private void btnGroup_Click(object sender, RoutedEventArgs e)
        {
            GroupHomePage groupHomePage = new GroupHomePage();
            groupHomePage.Show();
        }

    }
}