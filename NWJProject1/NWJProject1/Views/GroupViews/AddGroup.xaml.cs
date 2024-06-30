using NWJProject1.ViewModels;
using NWJProject1.ViewModels.GroupViewModels;
using System.Windows;

namespace NWJProject1.Views.GroupViews
{
    public partial class AddGroup : Window
    {
        public AddGroup()
        {
            InitializeComponent();
            AddGroupViewModel addGroupViewModel = new AddGroupViewModel();  
            this.DataContext = addGroupViewModel;
        }
    }
}
