using Fitness_Center.Controllers;
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
    /// Interaction logic for RegisterNewOrEditUserView.xaml
    /// </summary>
    public partial class RegisterNewOrEditUserView : Window
    {

        public RegisterNewOrEditUserView()
        {
            InitializeComponent();

            if(LoggedInUserModel.userType.Equals(null))
                this.Closed += new EventHandler(MainWindow_Closed);
        }

        void MainWindow_Closed(object sender, EventArgs e)
        {
            LoginView loginView = new LoginView();

            loginView.Show();
        }
    }
}
