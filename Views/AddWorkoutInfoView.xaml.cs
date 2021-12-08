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

        DateTime selectedDateTimeStart;
        DateTime selectedDateTimeEnd;
        WorkoutModel workout = new WorkoutModel();

        public AddWorkoutInfoView()
        {
            InitializeComponent();

            timePickerWorkout.Text = DateTime.Now.AddMinutes(15).ToString("HH:mm");

            cmbBoxInstructor = workoutController.GetAllInstructorUserName(cmbBoxInstructor);

            cmbBoxLength = workoutController.FillComboBoxLength(cmbBoxLength);
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
            e.Cancel = true;
        }

        private Boolean CheckForValidDateTimeInput()
        {
            DateTime todayDateTime = DateTime.Now.AddMinutes(15);
            DateTime selectedStartDate = datePickerWorkout.SelectedDate.Value;
            DateTime selectedStartTime = DateTime.Parse(timePickerWorkout.Value.ToString());

            selectedDateTimeStart = DateTime.Parse(selectedStartDate.ToString("yyyy-MM-dd") + selectedStartTime.ToString(" HH:mm:ss"));
            selectedDateTimeEnd = selectedDateTimeStart.AddMinutes(int.Parse(cmbBoxLength.SelectedItem.ToString()));

            if (todayDateTime.ToString("yyyy-MM-dd") == selectedStartDate.ToString("yyyy-MM-dd") && todayDateTime > selectedStartTime)
            {
                MessageBox.Show("Izabrali ste datum i vreme koji su već prošli ili su jako blizu da prođu u odnosu na trenutno.", "Upozorenje - Fitnes centar",
                    MessageBoxButton.OK, MessageBoxImage.Warning);

                timePickerWorkout.Text = DateTime.Now.AddMinutes(15).ToString("HH:mm");

                return false;
            }

            return true;
        }

        private void btnConfirm_Click(object sender, RoutedEventArgs e)
        {
            if (CheckForValidDateTimeInput() == false)
                return;

            workout.DateTimeStart = selectedDateTimeStart;
            workout.DateTimeEnd = selectedDateTimeEnd;
            workout.Length = int.Parse(cmbBoxLength.SelectedItem.ToString());
            workout.Instructor = (string)cmbBoxInstructor.SelectedItem;

            if (workoutController.CheckForDuplicate(workout).Equals(false))
            {
                workoutController.AddWorkout(workout);

                this.Close();
            }

        }
    }
}
