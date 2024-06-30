using System.Windows;
using NWJProject1.ViewModels;
using NWJProject1.Views;
using NWJProject1.Views.GroupViews;
namespace NWJProject1
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainWindowViewModel mainWindowViewModel = new MainWindowViewModel();
            DataContext = mainWindowViewModel;
        }

    }
}