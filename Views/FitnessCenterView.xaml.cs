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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Fitness_Center.Views
{
    /// <summary>
    /// Interaction logic for FitnessCenterView.xaml
    /// </summary>
    public partial class FitnessCenterView : UserControl
    {

        FitnessCenterModel fitnessCenterModel = new FitnessCenterModel();

        AddressModel addressModel = new AddressModel();

        FitnessCenterController fitnessCenterController = new FitnessCenterController();

        public FitnessCenterView()
        {
            InitializeComponent();

            if (LoggedInUserModel.userName != "")
            {
                LoadFintessCenterViewRegisteredUserMode();
            }
            else
            {
                LoadFitnessCenterViewGuestMode();
            }

            fitnessCenterController.FetchFitnessCenterInfo(fitnessCenterModel, addressModel);

            this.DataContext = new {fitnessCenterModel, addressModel};
        }

        private void LoadFitnessCenterViewGuestMode()
        {
            btnViewInstructorsInfo.Visibility = Visibility.Visible;
        }

        private void LoadFintessCenterViewRegisteredUserMode()
        {
            if (LoggedInUserModel.userType.Equals(EUserType.Administrator))
            {
                txtFitnessCenterPassword.IsReadOnly = false;
                txtFitnessCenterName.IsReadOnly = false;

                btnEditFitnessCenterAddressInfo.Visibility = Visibility.Visible;
                btnSaveFitnessCenterInfo.Visibility = Visibility.Visible;
            }
        }

        private void btnViewInstructorsInfo_Click(object sender, RoutedEventArgs e)
        {
            ViewInstructorsInfoView viewInstructorsInfoView = new ViewInstructorsInfoView();

            viewInstructorsInfoView.ShowDialog();
        }
        private void btnSaveFitnessCenterInfo_Click(object sender, RoutedEventArgs e)
        {
            fitnessCenterController.ChangeFitnessCenterInfo(fitnessCenterModel, addressModel);
        }

        private void btnEditFitnessCenterAddressInfo_Click(object sender, RoutedEventArgs e)
        {
            fitnessCenterGrid.RowDefinitions[6].Height = new GridLength(275);

            this.txtFitnessCenterAddress.Visibility = Visibility.Collapsed;

            this.editAddressCenterInfo.Visibility = Visibility.Visible;

            this.btnEditFitnessCenterAddressInfo.IsEnabled = false;
        }
    }
}
