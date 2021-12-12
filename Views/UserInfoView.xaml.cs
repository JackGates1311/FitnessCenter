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

            if (OperationModeModel.userInfoViewMode.Equals(EUserInfoViewOperationMode.Add))
            {
                LoadUserInfoViewAddMode();

                SetRegisteredUserType();
            }

            if (OperationModeModel.userInfoViewMode.Equals(EUserInfoViewOperationMode.Edit))
            {
                LoadUserInfoViewEditMode();

                registeredUserController.GetRegisteredUserInfo(registeredUserModel, addressModel, "Users.UserName LIKE '" + LoggedInUserModel.userName + "'");

                DetectRegisteredUserGender();
            }

            if (OperationModeModel.userInfoViewMode.Equals(EUserInfoViewOperationMode.EditTable))
            {
                LoadUserInfoViewEditMode();

                registeredUserController.GetRegisteredUserInfo(registeredUserModel, addressModel, 
                    "Users.AddressId LIKE '" + RemoveOrEditSelectedRowController.selectedRowId + "'");

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
            this.btnConfirm.Content = "Kliknite ovde da bi ste izvršili registraciju";
        }

        private void LoadUserInfoViewEditMode()
        {
            this.lblTitle.Content = "Podaci o korisniku:";
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

            if (OperationModeModel.userInfoViewMode.Equals(EUserInfoViewOperationMode.Add))
                unregistredUserController.RegisterNewUser(registeredUserModel, addressModel, this);

            if (OperationModeModel.userInfoViewMode.Equals(EUserInfoViewOperationMode.Edit))
                registeredUserController.ChangeRegisteredUserInfo(registeredUserModel, addressModel, "UserName LIKE '" + LoggedInUserModel.userName + "'",
                    "UserName LIKE '" + LoggedInUserModel.userName + "' WHERE u.UserName LIKE '" + LoggedInUserModel.userName + "'");

            if (OperationModeModel.userInfoViewMode.Equals(EUserInfoViewOperationMode.EditTable))
            {
                registeredUserController.ChangeRegisteredUserInfo(registeredUserModel, addressModel,
                    "AddressId LIKE '" + RemoveOrEditSelectedRowController.selectedRowId + "'", "u.AddressId LIKE '" +
                    RemoveOrEditSelectedRowController.selectedRowId + "' WHERE u.AddressId LIKE '" + RemoveOrEditSelectedRowController.selectedRowId + "'");

                CloseParentWindow();

            }

        }

    }
}
