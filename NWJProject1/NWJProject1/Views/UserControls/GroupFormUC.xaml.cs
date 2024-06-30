using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NWJProject1.Views.UserControls
{
    /// <summary>
    /// Interaction logic for GroupFormUC.xaml
    /// </summary>
    public partial class GroupFormUC : UserControl
    {
        public static readonly DependencyProperty IsEditModeProperty =
           DependencyProperty.Register("IsEditMode", typeof(bool), typeof(GroupFormUC), new PropertyMetadata(true, OnIsEditModeChanged));
        public static readonly DependencyProperty ButtonContentProperty =
           DependencyProperty.Register("ButtonContent", typeof(string), typeof(GroupFormUC));

        public static readonly DependencyProperty ButtonCommandProperty =
            DependencyProperty.Register("ButtonCommand", typeof(ICommand), typeof(GroupFormUC));

        public static readonly DependencyProperty ButtonCommandParameterProperty =
            DependencyProperty.Register("ButtonCommandParameter", typeof(object), typeof(GroupFormUC));
        public bool IsEditMode
        {
            get { return (bool)GetValue(IsEditModeProperty); }
            set { SetValue(IsEditModeProperty, value); }
        }
        public string ButtonContent
        {
            get { return (string)GetValue(ButtonContentProperty); }
            set { SetValue(ButtonContentProperty, value); }
        }

        public ICommand ButtonCommand
        {
            get { return (ICommand)GetValue(ButtonCommandProperty); }
            set { SetValue(ButtonCommandProperty, value); }
        }

        public object ButtonCommandParameter
        {
            get { return GetValue(ButtonCommandParameterProperty); }
            set { SetValue(ButtonCommandParameterProperty, value); }
        }
        public GroupFormUC()
        {
            InitializeComponent();
        }
        private static void OnIsEditModeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var window = d as GroupFormUC;
            var isEditMode = (bool)e.NewValue;

            window.SetEditMode(isEditMode);
        }
        private void SetEditMode(bool isEditMode)
        {
            txtGroupName.IsEnabled = isEditMode;
            txtGroupDescription.IsEnabled = isEditMode;
            txtStatus.IsEnabled = isEditMode;
        }
    }
}
