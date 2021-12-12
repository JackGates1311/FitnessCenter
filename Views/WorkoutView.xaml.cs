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

            workoutController.LoadWorkouts(tableWorkouts);
        }

        private void btnAddWorkout_Click(object sender, RoutedEventArgs e)
        {
            OperationModeModel.workoutInfoViewMode = EWorkoutInfoViewOperationMode.Add;

            WorkoutInfoView workoutInfoView = new WorkoutInfoView();

            workoutInfoView.ShowDialog();

            workoutController.LoadWorkouts(tableWorkouts);
        }

        private void btnEditWorkout_Click(object sender, RoutedEventArgs e)
        {
            OperationModeModel.workoutInfoViewMode = EWorkoutInfoViewOperationMode.Edit;

            if (removeOrEditSelectedRowController.CheckIfRowIsSelected(tableWorkouts).Equals(true) &&
                removeOrEditSelectedRowController.CheckIfSelectedRowIsRemoved(tableWorkouts, "Workouts").Equals(false))
            {
                WorkoutInfoView workoutInfoView = new WorkoutInfoView();

                workoutController.LoadAndFillEditWorkoutData(workoutInfoView);

                workoutInfoView.ShowDialog();

                workoutController.LoadWorkouts(tableWorkouts);
            }
            else
                return;
        }

        private void btnDeleteWorkout_Click(object sender, RoutedEventArgs e)
        {
            removeOrEditSelectedRowController.CheckAndPerformDelete(tableWorkouts, "Workouts", "WorkoutId");

            workoutController.LoadWorkouts(tableWorkouts);
        }
    }
}
