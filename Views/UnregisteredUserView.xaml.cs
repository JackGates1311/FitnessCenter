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
    /// Interaction logic for UnregisteredUserView.xaml
    /// </summary>
    public partial class UnregisteredUserView : Window
    {
        public UnregisteredUserView()
        {
            InitializeComponent();

            this.Closed += new EventHandler(MainWindow_Closed);

        }

        void MainWindow_Closed(object sender, EventArgs e)
        {
            LoginView loginView = new LoginView();

            loginView.Show();
        }

    }
}
