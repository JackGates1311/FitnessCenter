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
    /// Interaction logic for UserView.xaml
    /// </summary>
    public partial class UserView : UserControl
    {
        RegisteredUserController registeredUserController = new RegisteredUserController();

        RemoveOrEditSelectedRowController removeOrEditSelectedRowController = new RemoveOrEditSelectedRowController();

        public UserView()
        {
            InitializeComponent();

            cmbBoxUserType.SelectedIndex = 0; // This automatically calls SelectionChanged event 
        }

        private void btnAddInstructor_Click(object sender, RoutedEventArgs e)
        {
            OperationModeModel.userInfoViewMode = EUserInfoViewOperationMode.Add;

            RegisterNewOrEditUserView registerNewOrEditUserView = new RegisterNewOrEditUserView();

            registerNewOrEditUserView.ShowDialog();

            FilterUserTable();
        }

        private void btnEditUser_Click(object sender, RoutedEventArgs e)
        {
            OperationModeModel.userInfoViewMode = EUserInfoViewOperationMode.EditTable;

            if (removeOrEditSelectedRowController.CheckIfRowIsSelected(tableUsers).Equals(true) &&
                removeOrEditSelectedRowController.CheckIfSelectedRowIsPossibleToRemoveOrEdit(tableUsers, "Users").Equals(false))
            {

                RegisterNewOrEditUserView registerNewOrEditUserView = new RegisterNewOrEditUserView();

                registerNewOrEditUserView.ShowDialog();

                FilterUserTable();

            }
            else
                return;
        }

        private void btnDeleteUser_Click(object sender, RoutedEventArgs e)
        {
            OperationModeModel.userInfoViewMode = EUserInfoViewOperationMode.Remove;

            removeOrEditSelectedRowController.CheckAndPerformDelete(tableUsers, "Users", "AddressId");

            FilterUserTable();

        }
        private void cmbBoxUserType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FilterUserTable();
        }

        private void FilterUserTable()
        {
            String queryHideDeletedUsersProperty = "";

            if (chkBoxHideDeletedUsers.IsChecked.Equals(true))
                queryHideDeletedUsersProperty = "AND IsRemoved='0'";

            if (cmbBoxUserType.SelectedIndex == 0)
                registeredUserController.LoadUserData(tableUsers, "", queryHideDeletedUsersProperty, txtName.Text, txtSurname.Text,
                txtEmail.Text, txtStreet.Text);
            if (cmbBoxUserType.SelectedIndex == 1)
                registeredUserController.LoadUserData(tableUsers, "WHERE UserType = 'Administrator'", queryHideDeletedUsersProperty, 
                    txtName.Text, txtSurname.Text, txtEmail.Text, txtStreet.Text);
            if (cmbBoxUserType.SelectedIndex == 2)
                registeredUserController.LoadUserData(tableUsers, "WHERE UserType = 'Instructor'", queryHideDeletedUsersProperty, 
                    txtName.Text, txtSurname.Text, txtEmail.Text, txtStreet.Text);
            if (cmbBoxUserType.SelectedIndex == 3)
                registeredUserController.LoadUserData(tableUsers, "WHERE UserType = 'Customer'", queryHideDeletedUsersProperty, 
                    txtName.Text, txtSurname.Text, txtEmail.Text, txtStreet.Text);
        }

        private void chkBoxHideDeletedUsers_Checked(object sender, RoutedEventArgs e)
        {
            FilterUserTable();
        }

        private void chkBoxHideDeletedUsers_Unchecked(object sender, RoutedEventArgs e)
        {
            FilterUserTable();
        }

        private void btnClearSearch_Click(object sender, RoutedEventArgs e)
        {
            txtName.Clear();
            txtSurname.Clear();
            txtStreet.Clear();
            txtEmail.Clear();

            FilterUserTable();
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            FilterUserTable();
        }
    }
}
