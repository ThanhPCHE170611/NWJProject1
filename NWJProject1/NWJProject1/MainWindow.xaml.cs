using System.Windows;
using NWJProject1.Views;
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
            userHomePage.ShowDialog();
        }
    }
}