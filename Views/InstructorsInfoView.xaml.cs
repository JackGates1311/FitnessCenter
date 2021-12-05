using Fitness_Center.Controllers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Fitness_Center.Views
{
    /// <summary>
    /// Interaction logic for InstructorsInfoView.xaml
    /// </summary>
    public partial class InstructorsInfoView : UserControl
    {

        InstructorsInfoController instructorsInfoController = new InstructorsInfoController();

        public InstructorsInfoView()
        {
            InitializeComponent();

            fillTableInstructors();
        }

        private void fillTableInstructors()
        {
            instructorsInfoController.loadInstructorData(tableInstructors, "", "", "", "");
        }
        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            instructorsInfoController.loadInstructorData(tableInstructors, txtName.Text, txtSurname.Text,
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
