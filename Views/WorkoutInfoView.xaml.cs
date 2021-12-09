using Fitness_Center.Controllers;
using Fitness_Center.Models;
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
    public partial class WorkoutInfoView : Window
    {
        WorkoutController workoutController = new WorkoutController();

        DateTime selectedDateTimeStart;
        DateTime selectedDateTimeEnd;
        WorkoutModel workout = new WorkoutModel();

        String selectedRowWorkoutId;
        public string SelectedRowWorkoutId { get => selectedRowWorkoutId; set => selectedRowWorkoutId = value; }

        public WorkoutInfoView()
        {
            InitializeComponent();

            cmbBoxInstructor = workoutController.GetAllInstructorOrCustomerUserName(cmbBoxInstructor, "SELECT UserName from Users WHERE UserType = 'Instructor';");

            cmbBoxLength = workoutController.FillComboBoxLength(cmbBoxLength);

            if (OperationModeModel.workoutInfoViewMode.Equals(EWorkoutInfoViewOperationMode.Add))
            {
                timePickerWorkout.Text = DateTime.Now.AddMinutes(15).ToString("HH:mm");

            }
            if (OperationModeModel.workoutInfoViewMode.Equals(EWorkoutInfoViewOperationMode.Edit))
            {
                cmbBoxWorkoutStatus = workoutController.FillCmbBoxWorkoutStatus(cmbBoxWorkoutStatus);

                cmbBoxCustomer.Items.Add("");

                cmbBoxCustomer = workoutController.GetAllInstructorOrCustomerUserName(cmbBoxCustomer, "SELECT UserName from Users WHERE UserType = 'Customer';");
            }
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

            if (todayDateTime.AddMinutes(-15).ToString("yyyy-MM-dd") == selectedStartDate.ToString("yyyy-MM-dd") && todayDateTime > selectedStartTime)
            {
                MessageBox.Show("Izabrali ste datum i vreme koji su već prošli ili su jako blizu da prođu u odnosu na trenutno.", "Upozorenje - Fitnes centar",
                    MessageBoxButton.OK, MessageBoxImage.Warning);

                timePickerWorkout.Text = DateTime.Now.AddMinutes(15).ToString("HH:mm");

                return false;
            }

            return true;
        }

        private Boolean CheckForValidCheckBoxInput()
        {
            if ((cmbBoxWorkoutStatus.SelectedItem.Equals("Slobodan") && cmbBoxCustomer.SelectedItem.Equals("")) || (cmbBoxWorkoutStatus.SelectedItem.Equals("Rezervisan") &&
                !cmbBoxCustomer.SelectedItem.Equals("")))
                return true;
            else 
            {
                MessageBox.Show("Izabrali ste nemoguću kombinaciju statusa treninga i izabranog polaznika", "Upozorenje - Fitnes centar",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

        }

        private void btnConfirm_Click(object sender, RoutedEventArgs e)
        {
            if (CheckForValidDateTimeInput() == false)
                return;

            workout.Id = Convert.ToInt32(selectedRowWorkoutId);
            workout.DateTimeStart = selectedDateTimeStart;
            workout.DateTimeEnd = selectedDateTimeEnd;
            workout.Length = int.Parse(cmbBoxLength.SelectedItem.ToString());

            workout.Instructor = (string)cmbBoxInstructor.SelectedItem;

            if (OperationModeModel.workoutInfoViewMode.Equals(EWorkoutInfoViewOperationMode.Add) && workoutController.CheckForDuplicateWorkout(workout).Equals(false))
            {
                workoutController.AddWorkout(workout);
            
                this.Close();
            }

            if (OperationModeModel.workoutInfoViewMode.Equals(EWorkoutInfoViewOperationMode.Edit) && workoutController.CheckForDuplicateWorkout(workout).Equals(false))
            {
                if (CheckForValidCheckBoxInput() == false)
                    return;


                if (cmbBoxWorkoutStatus.SelectedItem.Equals("Rezervisan"))
                    workout.WorkoutStatus = EWorkoutStatus.Reserved;
                else
                    workout.WorkoutStatus = EWorkoutStatus.Available;

                workout.Customer = (string)cmbBoxCustomer.SelectedItem;

                workoutController.EditWorkout(workout);

                this.Close();
            }
        }
    }
}
