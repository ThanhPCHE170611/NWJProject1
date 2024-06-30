using NWJProject1.Models;
using NWJProject1.ViewModels.GroupViewModels;
using System.Windows;

namespace NWJProject1.Views.GroupViews
{
    public partial class UpdateGroup : Window
    {
        public UpdateGroup(UserGroup SelectedGroup)
        {
            InitializeComponent();
            UpdateGroupViewModel updateGroupViewModel = new UpdateGroupViewModel(SelectedGroup);
            DataContext = updateGroupViewModel;
        }
    }
}
