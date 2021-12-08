using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace Fitness_Center.Controllers
{
    class WorkoutController
    {

        SqlConnectController connection = new SqlConnectController();
        public void LoadWorkouts(DataGrid table)
        {
            var query = "SELECT * from Workouts ORDER BY DateTimeStart;";

            SqlConnectController connection = new SqlConnectController();

            connection.openConnection();

            DataTable dt = connection.performQuery(query);

            ParseWorkoutStatus(dt);

            table.ItemsSource = dt.DefaultView;

            connection.closeConnection();

        }
        public ComboBox GetAllInstructorUserName(ComboBox cmbBox)
        {
            var query = "SELECT UserName from Users WHERE UserType='Instructor';";

            SqlConnectController connection = new SqlConnectController();

            connection.openConnection();

            DataTable dt = connection.performQuery(query);

            for (int i = 0; i < dt.Rows.Count; i++)
                cmbBox.Items.Add(dt.Rows[i]["UserName"]);

            return cmbBox;
        }

        public ComboBox FillComboBoxLength(ComboBox cmbBox)
        {
            for (int i = 30; i <= 300; i += 30)
                cmbBox.Items.Add(i);

            cmbBox.SelectedIndex = 3;

            return cmbBox;
        }

        private static void ParseWorkoutStatus(DataTable dt)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["WorkoutStatus"].Equals("Available"))
                    dt.Rows[i]["WorkoutStatus"] = "Slobodan";
                else
                    dt.Rows[i]["WorkoutStatus"] = "Rezervisan";
            }
        }

        public Boolean CheckForDuplicate(WorkoutModel workout) 
        {
            var queryCheckForDuplicates = "SELECT * from Workouts WHERE (Workouts.InstructorUserName LIKE '" + workout.Instructor + "') " +
                "AND (DateTimeStart between '" + workout.DateTimeStart.ToString("yyyy-MM-dd HH:mm") + "' " +
                "AND '" + workout.DateTimeEnd.ToString("yyyy-MM-dd HH:mm") + "' OR DateTimeEnd between '" + workout.DateTimeStart.ToString("yyyy-MM-dd HH:mm") +
                "' AND '" + workout.DateTimeEnd.ToString("yyyy-MM-dd HH:mm") + "'); ";

            connection.openConnection();

            if (connection.performQuery(queryCheckForDuplicates).Rows.Count > 0)
            {
                    MessageBox.Show("Trening se u navedenom terminu preklapa sa nekim od postojećih treninga za izabranog instruktora", "Upozorenje - Fitnes centar",
                        MessageBoxButton.OK, MessageBoxImage.Warning);

                    return true;
            }
            else
                    return false;

        }

        internal void AddWorkout(WorkoutModel workout)
        {
            var query = "INSERT into Workouts VALUES((SELECT MAX(WorkoutId) as WorkoutId FROM Workouts) + 1, " +
                "CONVERT(VARCHAR, '" + workout.DateTimeStart.ToString("yyyy-MM-dd HH:mm") + "')" + ", '" + workout.DateTimeEnd.ToString("yyyy-MM-dd HH:mm") +
                "', '" + workout.Length + "', 'Available', " + "'" + workout.Instructor + "', '', 0)";
            
            connection.openConnection();

            DataTable dt = connection.performQuery(query);

            MessageBox.Show("Termin za trening je uspešno kreiran!", "Obaveštenje - Fitnes centar", MessageBoxButton.OK, MessageBoxImage.Information);
            
        }
    }
}
