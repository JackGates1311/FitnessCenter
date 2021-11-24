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
    /// Interaction logic for RegisterNewUserView.xaml
    /// </summary>
    public partial class RegisterNewUserView : Window
    {
        public RegisterNewUserView()
        {
            InitializeComponent();

            this.Closed += new EventHandler(MainWindow_Closed);
        }

        void MainWindow_Closed(object sender, EventArgs e)
        {
            LoginView loginView = new LoginView();

            loginView.Show();
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {

        }

    }
}
