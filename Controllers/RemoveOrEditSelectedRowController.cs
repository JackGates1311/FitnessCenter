using Fitness_Center.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace Fitness_Center.Controllers
{
    class RemoveOrEditSelectedRowController
    {
        public static String selectedRowId;

        public Boolean CheckIfRowIsSelected(DataGrid table)
        {
            if (table.SelectedIndex == -1)
            {
                MessageBox.Show("Niste izabrali nijednu vrstu u tabeli", "Upozorenje - Fitnes centar", MessageBoxButton.OK, MessageBoxImage.Warning);

                return false;
            }
            else
                return true;
        }

        public Boolean CheckIfSelectedRowIsPossibleToRemove(DataGrid table, String queryTableProperty)
        {
            foreach (DataRowView row in table.SelectedItems)
            {
                DataRow selectedRow = row.Row;

                try
                {
                    if (selectedRow[13].ToString() == "False" && queryTableProperty.Equals("Users"))
                    {
                        selectedRowId = selectedRow[0].ToString();

                        return false;
                    }
                    else
                    {
                        MessageBox.Show("Izabrali ste korisnika koji je već obrisan", "Upozorenje - Fitnes centar", MessageBoxButton.OK, MessageBoxImage.Warning);

                        return true;
                    }
                }
                catch
                {
                    if (selectedRow[7].ToString() == "False" && queryTableProperty.Equals("Workouts"))
                    {

                        if (LoggedInUserModel.userType.Equals(EUserType.Instructor) && selectedRow[4].ToString().Equals("Rezervisan") && OperationModeModel.workoutInfoViewMode == EWorkoutInfoViewOperationMode.Remove)
                        {
                            MessageBox.Show("Izabrali ste trening koji je rezervisan", "Upozorenje - Fitnes centar", MessageBoxButton.OK, MessageBoxImage.Warning);

                            return true;
                        }
                        else 
                        {
                            selectedRowId = selectedRow[0].ToString();

                            return false;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Izabrali ste trening koji je već obrisan", "Upozorenje - Fitnes centar", MessageBoxButton.OK, MessageBoxImage.Warning);

                        return true;
                    }
                }



            }

            return true;
        }

        public void RemoveSelectedRow(String queryTableProperty, String queryColumnProperty)
        {
            var query = "UPDATE " + queryTableProperty + " SET IsRemoved = 1 WHERE " + queryColumnProperty + " = " + selectedRowId + ";";

            SqlConnectController connection = new SqlConnectController();

            connection.OpenConnection();

            DataTable dt = connection.PerformQuery(query);

            MessageBox.Show("Izabrana vrsta je uspešno obrisana", "Obaveštenje - Fitnes centar", MessageBoxButton.OK, MessageBoxImage.Information);

            connection.CloseConnection();
        }

        public void CheckAndPerformDelete(DataGrid table, String queryTableProperty, String queryColumnProperty)
        {
            if (CheckIfRowIsSelected(table).Equals(true))
            {
                if (MessageBox.Show("Da li ste sigurni da želite obrisati izabranu vrstu?", "Upozorenje - Fitnes centar",
                    MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {

                    if (CheckIfSelectedRowIsPossibleToRemove(table, queryTableProperty).Equals(false))
                        RemoveSelectedRow(queryTableProperty, queryColumnProperty);
                    else
                        return;
                }
                else
                    return;
            }

            return;
        }

    }
}
