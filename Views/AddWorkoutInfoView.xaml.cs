using Fitness_Center.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for AddWorkoutInfoView.xaml
    /// </summary>
    public partial class AddWorkoutInfoView : Window
    {
        WorkoutController workoutController = new WorkoutController();
        WorkoutModel workout = new WorkoutModel();

        public AddWorkoutInfoView()
        {
            InitializeComponent();

            timePickerWorkout.Text = "00:00";
        
            cmbBoxInstructor = workoutController.GetAllInstructorUserName(cmbBoxInstructor);

            cmbBoxLength = workoutController.FillComboBoxLength(cmbBoxLength);
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
            e.Cancel = true;
        }

        private void btnConfirm_Click(object sender, RoutedEventArgs e)
        {
            workout.Time = DateTime.Parse(timePickerWorkout.Value.ToString());

            try
            {
                workout.Time = DateTime.Parse(timePickerWorkout.Value.ToString());
            }
            catch 
            {
                MessageBox.Show("Molimo unesite vreme da bi ste kreirali trening");

                return;
            }

            workout.Date = datePickerWorkout.SelectedDate.Value;
            workout.Length = int.Parse(cmbBoxLength.SelectedItem.ToString());
            workout.Instructor = (string)cmbBoxInstructor.SelectedItem;

            workoutController.AddWorkout(workout);

            this.Close();
        }
    }
}
