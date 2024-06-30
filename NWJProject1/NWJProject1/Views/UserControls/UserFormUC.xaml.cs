using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace NWJProject1.Views.UserControls
{

    public partial class UserFormUC : UserControl
    {
        public static readonly DependencyProperty IsEditModeProperty =
            DependencyProperty.Register("IsEditMode", typeof(bool), typeof(UserFormUC), new PropertyMetadata(true, OnIsEditModeChanged));
        public static readonly DependencyProperty ButtonContentProperty =
           DependencyProperty.Register("ButtonContent", typeof(string), typeof(UserFormUC));

        public static readonly DependencyProperty ButtonCommandProperty =
            DependencyProperty.Register("ButtonCommand", typeof(ICommand), typeof(UserFormUC));

        public static readonly DependencyProperty ButtonCommandParameterProperty =
            DependencyProperty.Register("ButtonCommandParameter", typeof(object), typeof(UserFormUC));
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
        public UserFormUC()
        {
            InitializeComponent();
        }
        private static void OnIsEditModeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var window = d as UserFormUC;
            var isEditMode = (bool)e.NewValue;

            window.SetEditMode(isEditMode);
        }
        private void SetEditMode(bool isEditMode)
        {
            txtFullName.IsEnabled = isEditMode;
            cbGender.IsEnabled = isEditMode;
            txtAddress.IsEnabled = isEditMode;
            txtPhone.IsEnabled = isEditMode;
            txtStatus.IsEnabled = isEditMode;
            cbGroup.IsEnabled = isEditMode;
        }
    }
}
