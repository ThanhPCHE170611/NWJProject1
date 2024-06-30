using NWJProject1.Models;
using NWJProject1.ViewModels.GroupViewModels;
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

namespace NWJProject1.Views.GroupViews
{
    /// <summary>
    /// Interaction logic for DeleteGroup.xaml
    /// </summary>
    public partial class DeleteGroup : Window
    {
        public DeleteGroup(UserGroup SelectedGroup)
        {
            InitializeComponent();
            DeleteGroupViewModel deleteGroupViewModel = new DeleteGroupViewModel(SelectedGroup);
            this.DataContext = deleteGroupViewModel;
        }
    }
}
