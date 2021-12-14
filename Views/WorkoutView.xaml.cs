using Fitness_Center.Controllers;
using Fitness_Center.Models;
using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for WorkoutView.xaml
    /// </summary>
    public partial class WorkoutView : UserControl
    {
        WorkoutController workoutController = new WorkoutController();

        RemoveOrEditSelectedRowController removeOrEditSelectedRowController = new RemoveOrEditSelectedRowController();

        String hideReservedWorkouts = "";
        String showOnlyMyWorkouts = "";

        public WorkoutView()
        {
            InitializeComponent();

            if (LoggedInUserModel.userType.Equals(EUserType.Customer))
            {
                btnAddWorkout.Visibility = Visibility.Collapsed;
                btnEditWorkout.Visibility = Visibility.Collapsed;
                btnDeleteWorkout.Visibility = Visibility.Collapsed;

                btnReserveWorkout.Visibility = Visibility.Visible;
                btnCancelWorkout.Visibility = Visibility.Visible;
                chkBoxShowOnlyMyWorkouts.Visibility = Visibility.Visible;
            }

            cmbBoxInstructor.Items.Add("");

            cmbBoxInstructor = workoutController.GetAllInstructorOrCustomerUserName(cmbBoxInstructor, "SELECT UserName from Users WHERE UserType = 'Instructor' AND IsRemoved='0';");


            if (LoggedInUserModel.userType.Equals(EUserType.Instructor))
                cmbBoxInstructor.IsEnabled = false;
            
            cmbBoxInstructor.SelectedIndex = 0;

        }

        private void GetCheckBoxValues()
        {
            if (chkBoxHideReservedWorkouts.IsChecked == true)
                hideReservedWorkouts = "AND WorkoutStatus = 'Available' ";
            else
                hideReservedWorkouts = "";

            if (chkBoxShowOnlyMyWorkouts.IsChecked == true)
                showOnlyMyWorkouts = "AND CustomeruserName = '" + LoggedInUserModel.userName + "' ";
            else
                showOnlyMyWorkouts = "";
        }

        private void LoadWorkoutsForSelectedDate()
        {
            GetCheckBoxValues();

            if (LoggedInUserModel.userType.Equals(EUserType.Administrator))
                workoutController.LoadWorkouts(tableWorkouts, "", " AND CONVERT(DATETIME, FLOOR(CONVERT(FLOAT, DateTimeStart))) =  " +
                    "CONVERT(DATE, '" + datePickerWorkout.SelectedDate.Value.ToString("yyyy-MM-dd") + "')", cmbBoxInstructor.SelectedItem.ToString(), 
                    hideReservedWorkouts, showOnlyMyWorkouts);
            if (LoggedInUserModel.userType.Equals(EUserType.Instructor))
                workoutController.LoadWorkouts(tableWorkouts, "AND InstructorUserName LIKE '" + LoggedInUserModel.userName + "' ", 
                    " AND CONVERT(DATETIME, FLOOR(CONVERT(FLOAT, DateTimeStart))) =  " + 
                    "CONVERT(DATE, '" + datePickerWorkout.SelectedDate.Value.ToString("yyyy-MM-dd") + "')", cmbBoxInstructor.SelectedItem.ToString(),
                    hideReservedWorkouts, showOnlyMyWorkouts);
            if(LoggedInUserModel.userType.Equals(EUserType.Customer))
                workoutController.LoadWorkouts(tableWorkouts, "", " AND CONVERT(DATETIME, FLOOR(CONVERT(FLOAT, DateTimeStart))) =  " +
                    "CONVERT(DATE, '" + datePickerWorkout.SelectedDate.Value.ToString("yyyy-MM-dd") + "')", cmbBoxInstructor.SelectedItem.ToString(),
                    hideReservedWorkouts, showOnlyMyWorkouts);
        }

        private void LoadAllWorkouts()
        {
            GetCheckBoxValues();

            if (LoggedInUserModel.userType.Equals(EUserType.Administrator))
                workoutController.LoadWorkouts(tableWorkouts, "", "", cmbBoxInstructor.SelectedItem.ToString(), hideReservedWorkouts, showOnlyMyWorkouts);
            if (LoggedInUserModel.userType.Equals(EUserType.Instructor))
                workoutController.LoadWorkouts(tableWorkouts, "AND InstructorUserName LIKE '" + LoggedInUserModel.userName + "' ", "",
                    cmbBoxInstructor.SelectedItem.ToString(), hideReservedWorkouts, showOnlyMyWorkouts);
            if (LoggedInUserModel.userType.Equals(EUserType.Customer))
                workoutController.LoadWorkouts(tableWorkouts, "", "", cmbBoxInstructor.SelectedItem.ToString(), hideReservedWorkouts, showOnlyMyWorkouts);
        }

        private void btnAddWorkout_Click(object sender, RoutedEventArgs e)
        {
            OperationModeModel.workoutInfoViewMode = EWorkoutInfoViewOperationMode.Add;

            WorkoutInfoView workoutInfoView = new WorkoutInfoView();

            workoutInfoView.ShowDialog();

            LoadAllWorkouts();
        }

        private void btnEditWorkout_Click(object sender, RoutedEventArgs e)
        {
            OperationModeModel.workoutInfoViewMode = EWorkoutInfoViewOperationMode.Edit;

            if (removeOrEditSelectedRowController.CheckIfRowIsSelected(tableWorkouts).Equals(true) &&
                removeOrEditSelectedRowController.CheckIfSelectedRowIsPossibleToRemoveOrEdit(tableWorkouts, "Workouts").Equals(false))
            {
                WorkoutInfoView workoutInfoView = new WorkoutInfoView();

                workoutController.LoadAndFillEditWorkoutData(workoutInfoView);

                workoutInfoView.ShowDialog();

                LoadAllWorkouts();
            }
            else
                return;
        }

        private void btnDeleteWorkout_Click(object sender, RoutedEventArgs e)
        {
            OperationModeModel.workoutInfoViewMode = EWorkoutInfoViewOperationMode.Remove;

            removeOrEditSelectedRowController.CheckAndPerformDelete(tableWorkouts, "Workouts", "WorkoutId");

            LoadAllWorkouts();
        }

        private void btnViewWorkoutsForSelectedDate_Click(object sender, RoutedEventArgs e)
        {
            LoadWorkoutsForSelectedDate();
        }

        private void btnViewAllWorkouts_Click(object sender, RoutedEventArgs e)
        {
            cmbBoxInstructor.SelectedIndex = 0;
            LoadAllWorkouts();
        }

        private void cmbBoxInstructor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LoadAllWorkouts();
        }

        private void btnReserveWorkout_Click(object sender, RoutedEventArgs e)
        {
            OperationModeModel.workoutInfoViewMode = EWorkoutInfoViewOperationMode.Reserve;

            if (removeOrEditSelectedRowController.CheckIfRowIsSelected(tableWorkouts).Equals(true) &&
                removeOrEditSelectedRowController.CheckIfSelectedRowIsPossibleToRemoveOrEdit(tableWorkouts, "Workouts").Equals(false))
            {

                workoutController.SetWorkoutStatus("Reserved", LoggedInUserModel.userName);

                MessageBox.Show("Uspešno ste rezervisali trening", "Obaveštenje - Fitnes centar", MessageBoxButton.OK, MessageBoxImage.Information);
                
                LoadAllWorkouts();

                chkBoxHideReservedWorkouts.IsChecked = false;
            }
            else
                return;

        }

        private void btnCancelWorkout_Click(object sender, RoutedEventArgs e)
        {
            OperationModeModel.workoutInfoViewMode = EWorkoutInfoViewOperationMode.Cancel;

            if (removeOrEditSelectedRowController.CheckIfRowIsSelected(tableWorkouts).Equals(true) &&
                removeOrEditSelectedRowController.CheckIfSelectedRowIsPossibleToRemoveOrEdit(tableWorkouts, "Workouts").Equals(false))
            {
                workoutController.SetWorkoutStatus("Available", "");

                MessageBox.Show("Uspešno ste otkazali trening", "Obaveštenje - Fitnes centar", MessageBoxButton.OK, MessageBoxImage.Information);

                LoadAllWorkouts();

                chkBoxShowOnlyMyWorkouts.IsChecked = false;
            }
            else
                return;
        }

        private void chkBoxHideReservedWorkouts_Checked(object sender, RoutedEventArgs e)
        {
            LoadAllWorkouts();
        }

        private void chkBoxShowOnlyMyWorkouts_Checked(object sender, RoutedEventArgs e)
        {
            chkBoxHideReservedWorkouts.IsChecked = false;
            chkBoxHideReservedWorkouts.IsEnabled = false;

            LoadAllWorkouts();
        }

        private void chkBoxShowOnlyMyWorkouts_Unchecked(object sender, RoutedEventArgs e)
        {
            chkBoxHideReservedWorkouts.IsEnabled = true;

            LoadAllWorkouts();
        }
    }
}
