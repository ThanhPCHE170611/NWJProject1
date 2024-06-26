﻿using NWJProject1.Models;
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
    /// Interaction logic for GroupHomePage.xaml
    /// </summary>
    public partial class GroupHomePage : Window
    {
        public GroupHomePage()
        {
            InitializeComponent();
            GroupHomePageViewModel viewModel = new GroupHomePageViewModel();
            this.DataContext = viewModel;
        }

        private void FilterTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            GroupList.Items.Filter = FilterMethod;
        }
        private bool FilterMethod(object obj)
        {
            var groups = (UserGroup)obj;

            return groups.GroupName.Contains(FilterTextBox.Text, StringComparison.OrdinalIgnoreCase);
        }
    }
}
