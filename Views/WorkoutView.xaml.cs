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

        public WorkoutView()
        {
            InitializeComponent();

            LoadAllWorkouts();
        }

        private void LoadWorkoutsForSelectedDate()
        {
            if (LoggedInUserModel.userType.Equals(EUserType.Administrator))
                workoutController.LoadWorkouts(tableWorkouts, "", " AND CONVERT(DATETIME, FLOOR(CONVERT(FLOAT, DateTimeStart))) =  " +
                    "CONVERT(DATE, '" + datePickerWorkout.SelectedDate.Value.ToString("yyyy-MM-dd") + "')");
            if (LoggedInUserModel.userType.Equals(EUserType.Instructor))
                workoutController.LoadWorkouts(tableWorkouts, "AND InstructorUserName LIKE '" + LoggedInUserModel.userName + "' ", " AND CONVERT(DATETIME, FLOOR(CONVERT(FLOAT, DateTimeStart))) =  " +
                    "CONVERT(DATE, '" + datePickerWorkout.SelectedDate.Value.ToString("yyyy-MM-dd") + "')");

        }

        private void LoadAllWorkouts()
        {
            if (LoggedInUserModel.userType.Equals(EUserType.Administrator))
                workoutController.LoadWorkouts(tableWorkouts, "", "");
            if (LoggedInUserModel.userType.Equals(EUserType.Instructor))
                workoutController.LoadWorkouts(tableWorkouts, "AND InstructorUserName LIKE '" + LoggedInUserModel.userName + "' ", "");
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
                removeOrEditSelectedRowController.CheckIfSelectedRowIsPossibleToRemove(tableWorkouts, "Workouts").Equals(false))
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
            LoadAllWorkouts();
        }
    }
}
