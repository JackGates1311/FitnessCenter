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
        public void LoadWorkouts(DataGrid table)
        {
            var query = "SELECT * from Workouts;";

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

        internal void AddWorkout(WorkoutModel workout)
        {
            var query = "INSERT into Workouts VALUES((SELECT MAX(WorkoutId) as WorkoutId FROM Workouts) + 1, " +
                "CONVERT(VARCHAR, '" + workout.Date.ToString("yyyy-MM-dd") + "')" + ", '" + workout.Time.ToString("HH:mm") + "', '" + 
                workout.Length + "', 'Available', " + "'" + workout.Instructor + "', '', 0)";

            SqlConnectController connection = new SqlConnectController();
            
            connection.openConnection();

            DataTable dt = connection.performQuery(query);

            MessageBox.Show("Termin za trening je uspešno kreiran!");

        }
    }
}
