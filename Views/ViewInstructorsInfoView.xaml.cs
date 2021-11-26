using Fitness_Center.Controllers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Fitness_Center.Views
{
    /// <summary>
    /// Interaction logic for ViewInstructorsInfoView.xaml
    /// </summary>
    public partial class ViewInstructorsInfoView : Window
    {
        public ViewInstructorsInfoView()
        {
            InitializeComponent();

            ViewInstructorsInfoController viewInstructorsInfoController = new ViewInstructorsInfoController();

            viewInstructorsInfoController.loadData(tableInstructors);

        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
