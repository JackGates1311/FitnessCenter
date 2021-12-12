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
    /// Interaction logic for LoggedInUserView.xaml
    /// </summary>
    public partial class LoggedInUserView : Window
    {
        public LoggedInUserView()
        {
            OperationModeModel.userInfoViewMode = EUserInfoViewOperationMode.Edit;

            InitializeComponent();

            this.Closed += new EventHandler(MainWindow_Closed);

            lblUserName.Content = "Dobrodošli, prijavljeni ste kao '" + LoggedInUserModel.userName;

            if (LoggedInUserModel.userType.Equals(EUserType.Instructor))
            {
                lblUserName.Content += "' (" + "Insktruktor" + ")";
                ViewInstructorTabItems();
            }
            else if (LoggedInUserModel.userType.Equals(EUserType.Customer))
            {
                lblUserName.Content += "' (" + "Polaznik" + ")";
                ViewCustomerTabItems();
            }
            else
            {
                lblUserName.Content += "' (" + "Administrator" + ")";
                ViewAdministratorTabItems();
            }
        }

        private void ViewAdministratorTabItems()
        {
            workoutViewTabItem.Visibility = Visibility.Visible;
            userViewTabItem.Visibility = Visibility.Visible;
        }

        private void ViewInstructorTabItems()
        {
            instructorsInfoViewTabItem.Visibility = Visibility.Visible;
            userInfoViewTabItem.Visibility = Visibility.Visible;
        }

        private void ViewCustomerTabItems()
        {
            instructorsInfoViewTabItem.Visibility = Visibility.Visible;
            userInfoViewTabItem.Visibility = Visibility.Visible;
        }

        private void MainWindow_Closed(object sender, EventArgs e)
        {
            LoggedInUserModel.userName = "";
            LoggedInUserModel.userType = null;

            LoginView loginView = new LoginView();

            loginView.Show();

            this.Hide();
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
