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
    /// Interaction logic for UserInfoView.xaml
    /// </summary>
    public partial class UserInfoView : UserControl
    {
        RegisteredUserController registeredUserController = new RegisteredUserController();

        UnregisteredUserController unregistredUserController = new UnregisteredUserController();

        RegisteredUserModel registeredUserModel = new RegisteredUserModel();

        AddressModel addressModel = new AddressModel();

        public UserInfoView()
        {
            InitializeComponent();

            if (UserViewModel.userInfoViewMode.Equals(EUserInfoViewMode.Add))
            {
                LoadUserInfoViewAddMode();

                SetRegisteredUserType();
            }

            if (UserViewModel.userInfoViewMode.Equals(EUserInfoViewMode.Edit))
            {
                LoadUserInfoViewEditMode();

                registeredUserController.getRegisteredUserInfo(registeredUserModel, addressModel);

                DetectRegisteredUserGender();
            }

            this.DataContext = new {registeredUserModel, addressModel};
        }

        public void CloseParentWindow()
        {
            var myWindow = Window.GetWindow(this);

            myWindow.Close();
        }

        private void LoadUserInfoViewAddMode()
        {
            this.lblTitle.Content = "Registracija novog korisnika:";
            this.btnConfirm.Content = "Registruj se";
        }

        private void LoadUserInfoViewEditMode()
        {
            this.lblTitle.Content = "Moj profil:";
            this.btnConfirm.Content = "Sačuvaj izmene";

            this.txtUserName.IsReadOnly = true;
            this.txtIDNum.IsReadOnly = true;
        }

        private void DetectRegisteredUserGender()
        {
            if (registeredUserModel.Gender.Equals(EGender.Male))
                cmbBoxGender.SelectedIndex = 0;
            if (registeredUserModel.Gender.Equals(EGender.Female))
                cmbBoxGender.SelectedIndex = 1;
        }

        private void SetRegisteredUserGender()
        {
            if (cmbBoxGender.SelectedIndex == 0)
                registeredUserModel.Gender = EGender.Male;
            if (cmbBoxGender.SelectedIndex == 1)
                registeredUserModel.Gender = EGender.Female;
        }

        private void SetRegisteredUserType()
        {
            if (LoggedInUserModel.userType.Equals(null))
                registeredUserModel.UserType = EUserType.Customer;
            else
                registeredUserModel.UserType = EUserType.Instructor;
        }

        public void btnConfirm_Click(object sender, RoutedEventArgs e)
        {
            SetRegisteredUserGender();

            if (UserViewModel.userInfoViewMode.Equals(EUserInfoViewMode.Add))
                unregistredUserController.registerNewUser(registeredUserModel, addressModel, this);

            if (UserViewModel.userInfoViewMode.Equals(EUserInfoViewMode.Edit))
                registeredUserController.changeRegisteredUserInfo(registeredUserModel, addressModel);
        }

    }
}
