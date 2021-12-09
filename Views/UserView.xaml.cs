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
    /// Interaction logic for UserView.xaml
    /// </summary>
    public partial class UserView : UserControl
    {
        RegisteredUserController registeredUserController = new RegisteredUserController();

        public UserView()
        {
            InitializeComponent();
            FillTableUsers();
        }

        private void FillTableUsers()
        {
            registeredUserController.LoadUserData(tableUsers);
        }

        private void btnAddInstructor_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnEditUser_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDeleteUser_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
