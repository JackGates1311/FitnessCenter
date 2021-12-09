﻿using Fitness_Center.Models;
using Fitness_Center.Views;
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

        String selectedRowWorkoutId;

        public string SelectedRowWorkoutId { get => selectedRowWorkoutId; set => selectedRowWorkoutId = value; }

        public void LoadWorkouts(DataGrid table)
        {
            var query = "SELECT * from Workouts ORDER BY DateTimeStart;";

            SqlConnectController connection = new SqlConnectController();

            connection.OpenConnection();

            DataTable dt = connection.PerformQuery(query);

            ParseWorkoutStatus(dt);

            table.ItemsSource = dt.DefaultView;

            connection.CloseConnection();

        }
        public ComboBox GetAllInstructorOrCustomerUserName(ComboBox cmbBox, String query)
        {

            SqlConnectController connection = new SqlConnectController();

            connection.OpenConnection();

            DataTable dt = connection.PerformQuery(query);

            for (int i = 0; i < dt.Rows.Count; i++)
                cmbBox.Items.Add(dt.Rows[i]["UserName"]);

            connection.CloseConnection();

            return cmbBox;
        }

        public ComboBox FillComboBoxLength(ComboBox cmbBox)
        {
            for (int i = 30; i <= 300; i += 30)
                cmbBox.Items.Add(i);

            cmbBox.SelectedIndex = 3;

            return cmbBox;
        }

        public ComboBox FillCmbBoxWorkoutStatus(ComboBox cmbBox)
        {

            cmbBox.Items.Add("Slobodan");
            cmbBox.Items.Add("Rezervisan");

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

        public Boolean CheckForDuplicateWorkout(WorkoutModel workout) 
        {
            var query = "SELECT * from Workouts WHERE (Workouts.InstructorUserName LIKE '" + workout.Instructor + "') " +
                "AND WorkoutId != '" + workout.Id + "'AND IsRemoved = '0' AND (DateTimeStart between '" + workout.DateTimeStart.ToString("yyyy-MM-dd HH:mm") + "' " +
                "AND '" + workout.DateTimeEnd.ToString("yyyy-MM-dd HH:mm") + "' OR DateTimeEnd between '" + workout.DateTimeStart.ToString("yyyy-MM-dd HH:mm") +
                "' AND '" + workout.DateTimeEnd.ToString("yyyy-MM-dd HH:mm") + "'); ";

            connection.OpenConnection();

            if (connection.PerformQuery(query).Rows.Count > 0)
            {
                MessageBox.Show("Trening se u navedenom terminu preklapa sa nekim od postojećih treninga za izabranog instruktora", "Upozorenje - Fitnes centar",
                        MessageBoxButton.OK, MessageBoxImage.Warning);

                connection.CloseConnection();

                return true;
            }
            else 
            {
                connection.CloseConnection();

                return false;
            }

        }

        internal void AddWorkout(WorkoutModel workout)
        {
            var query = "INSERT into Workouts VALUES((SELECT MAX(WorkoutId) as WorkoutId FROM Workouts) + 1, " +
                "CONVERT(VARCHAR, '" + workout.DateTimeStart.ToString("yyyy-MM-dd HH:mm") + "')" + ", '" + workout.DateTimeEnd.ToString("yyyy-MM-dd HH:mm") +
                "', '" + workout.Length + "', 'Available', " + "'" + workout.Instructor + "', '', 0)";
            
            connection.OpenConnection();

            DataTable dt = connection.PerformQuery(query);

            MessageBox.Show("Termin za trening je uspešno kreiran!", "Obaveštenje - Fitnes centar", MessageBoxButton.OK, MessageBoxImage.Information);

            connection.CloseConnection();
            
        }

        public Boolean CheckIfRowIsSelected(WorkoutView workoutView)
        {
            if (workoutView.tableWorkouts.SelectedIndex == -1)
            {
                MessageBox.Show("Niste izabrali nijednu vrstu u tabeli", "Upozorenje - Fitnes centar", MessageBoxButton.OK, MessageBoxImage.Warning);

                return false;
            }
            else
                return true;
        }

        public Boolean CheckIfSelectedRowIsRemoved(WorkoutView workoutView)
        {
            foreach (DataRowView row in workoutView.tableWorkouts.SelectedItems)
            {
                DataRow selectedRow = row.Row;

                if (selectedRow[7].ToString() == "False")
                {
                    SelectedRowWorkoutId = selectedRow[0].ToString();

                    return false;
                }
                else
                {
                    MessageBox.Show("Izabrali ste trening koji je obrisan", "Upozorenje - Fitnes centar", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return true;
                }

            }

            return true;
        }

        public Boolean CheckAndConfirmRemoveWorkout(WorkoutView workoutView)
        {
            if (CheckIfRowIsSelected(workoutView).Equals(true))
            {
                if (MessageBox.Show("Da li ste sigurni da želite obrisati izabrani trening?", "Upozorenje - Fitnes centar",
                    MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {

                    if (CheckIfSelectedRowIsRemoved(workoutView).Equals(false))
                        return true;
                    else
                        return false;
                }
                else
                    return false;

            }

            return false;
        }

        public Boolean CheckEditWorkout(WorkoutView workoutView)
        {

            if (CheckIfRowIsSelected(workoutView).Equals(true) && CheckIfSelectedRowIsRemoved(workoutView).Equals(false))
                return true;
            else
                return false;
        
        }

        public void LoadAndFillEditWorkoutData(WorkoutInfoView workoutInfoView)
        {
            var query = "SELECT * from Workouts WHERE WorkoutId=" + SelectedRowWorkoutId + "";

            connection.OpenConnection();

            DataTable dt = connection.PerformQuery(query);

            if (DateTime.Now > DateTime.Parse(dt.Rows[0]["DateTimeEnd"].ToString()))
            {
                MessageBox.Show("Ovaj trening nije moguće izmeniti", "Upozorenje - Fitnes centar", MessageBoxButton.OK, MessageBoxImage.Warning);
                workoutInfoView.Close();
            }
            else 
            {
                workoutInfoView.SelectedRowWorkoutId = SelectedRowWorkoutId;

                workoutInfoView.Title = "Fitnes centar - Izmeni trening";
                workoutInfoView.btnConfirm.Content = "Sačuvaj izmene";
                workoutInfoView.lblTitle.Content = "Izmeni trening";

                workoutInfoView.workoutInfoViewGrid.RowDefinitions[5].Height = new GridLength(30);
                workoutInfoView.workoutInfoViewGrid.RowDefinitions[6].Height = new GridLength(60);
                workoutInfoView.workoutInfoViewWindow.Height = 440;
                workoutInfoView.workoutInfoViewWindow.Width = 700;

                workoutInfoView.lblWorkoutStatus.Visibility = Visibility.Visible;
                workoutInfoView.cmbBoxWorkoutStatus.Visibility = Visibility.Visible;
                workoutInfoView.lblCustomer.Visibility = Visibility.Visible;
                workoutInfoView.cmbBoxCustomer.Visibility = Visibility.Visible;

                workoutInfoView.datePickerWorkout.Text = dt.Rows[0]["DateTimeStart"].ToString();
                workoutInfoView.timePickerWorkout.Text = DateTime.Parse(dt.Rows[0]["DateTimeStart"].ToString()).ToString("HH:mm");
                workoutInfoView.cmbBoxLength.Text = dt.Rows[0]["Length"].ToString();
                workoutInfoView.cmbBoxInstructor.Text = dt.Rows[0]["InstructorUserName"].ToString();

                if (dt.Rows[0]["WorkoutStatus"].ToString().Equals("Reserved"))
                    workoutInfoView.cmbBoxWorkoutStatus.Text = "Rezervisan";
                else
                    workoutInfoView.cmbBoxWorkoutStatus.Text = "Slobodan";

                workoutInfoView.cmbBoxCustomer.Text = dt.Rows[0]["CustomerUserName"].ToString();
            }

            connection.CloseConnection();

        }

        public void EditWorkout(WorkoutModel workout)
        {
            var query = "UPDATE Workouts SET DateTimeStart = CONVERT(VARCHAR, '" + workout.DateTimeStart.ToString("yyyy-MM-dd HH:mm") + "'), " +
                "DateTimeEnd = CONVERT(VARCHAR, '" + workout.DateTimeEnd.ToString("yyyy-MM-dd HH:mm") + "'), Length = '" + workout.Length + "', " +
                "WorkoutStatus = '" + workout.WorkoutStatus + "', InstructorUserName = '" + workout.Instructor + "', CustomerUserName = '" + workout.Customer + 
                "' WHERE WorkoutId = '" + workout.Id + "'; ";

            SqlConnectController connection = new SqlConnectController();

            connection.OpenConnection();

            DataTable dt = connection.PerformQuery(query);

            MessageBox.Show("Trening je uspešno izmenjen " + "\n\n" + SelectedRowWorkoutId, "Obaveštenje - Fitnes centar", MessageBoxButton.OK, MessageBoxImage.Information);

            connection.CloseConnection();
        }

        internal void RemoveWorkout()
        {
            var query = "UPDATE Workouts SET IsRemoved = 1 WHERE WorkoutId = " + SelectedRowWorkoutId + ";";

            SqlConnectController connection = new SqlConnectController();

            connection.OpenConnection();

            DataTable dt = connection.PerformQuery(query);

            MessageBox.Show("Trening je uspešno obrisan", "Obaveštenje - Fitnes centar", MessageBoxButton.OK, MessageBoxImage.Information);

            connection.CloseConnection();
        }
    }
}
