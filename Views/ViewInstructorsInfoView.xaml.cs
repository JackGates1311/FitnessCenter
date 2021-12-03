using Fitness_Center.Controllers;
using Fitness_Center.Models;
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

        ViewInstructorsInfoController viewInstructorsInfoController = new ViewInstructorsInfoController();

        public ViewInstructorsInfoView()
        {
            InitializeComponent();

            fillTableInstructors();
        }

        private void fillTableInstructors() 
        {
            viewInstructorsInfoController.loadInstructorData(tableInstructors, "", "", "", "");
        }
        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            viewInstructorsInfoController.loadInstructorData(tableInstructors, txtName.Text, txtSurname.Text, 
                txtEmail.Text, txtStreet.Text);
        }

        private void btnClearSearch_Click(object sender, RoutedEventArgs e)
        {
            txtName.Clear();
            txtSurname.Clear();
            txtStreet.Clear();
            txtEmail.Clear();

            fillTableInstructors();
        }
    }
}
