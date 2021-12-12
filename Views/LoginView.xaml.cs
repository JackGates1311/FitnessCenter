using Fitness_Center.Models;
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
using System.Windows.Shapes;

namespace Fitness_Center.Views
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : Window
    {
        public LoginView()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e) 
        {
            OperationModeModel.userInfoViewMode = EUserInfoViewOperationMode.Add;

            RegisterNewOrEditUserView registerNewOrEditUserView = new RegisterNewOrEditUserView();

            registerNewOrEditUserView.Show();

            this.Hide();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            LoginController loginController = new LoginController();

            if (loginController.loginToSystem(txtUserName.Text, txtPassword.Password)) 
            { 
                LoggedInUserView loggedInUserView = new LoggedInUserView();

                loggedInUserView.Show();

                this.Hide();
            }
            else
                MessageBox.Show("Korisničko ime ili lozinka nisu ispravni, prijava na sistem neuspešna", "Upozorenje - Fitnes centar", 
                    MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        private void btnLoginAsGuest_Click(object sender, RoutedEventArgs e)
        {
            UnregisteredUserView unregisteredUserView = new UnregisteredUserView();

            unregisteredUserView.Show();

            this.Hide();
        }
    }
}
