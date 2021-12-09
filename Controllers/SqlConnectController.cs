using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows;

namespace Fitness_Center.Controllers
{
    public class SqlConnectController
    {
        public SqlConnection Connection { get; set; }
        private string connectionString { get; set; }

        public void OpenConnection()
        {
            connectionString = (@"Data Source = MAKI-PC; Initial Catalog=fitnessCenter; Integrated Security = True");

            Connection = new SqlConnection(connectionString);

            try
            {
                Connection.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greška prilikom ostvarivanja konekcije sa bazom podataka. \n Detalji\n\n: " + ex.ToString(), "Greška - Fitnes centar",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public DataTable PerformQuery(String query)
        {
            if (Connection.State == ConnectionState.Open)
            {

                SqlCommand cmd = new SqlCommand(query, Connection);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();

                adapter.Fill(dt);

                cmd.Dispose();

                return dt;
            }
            else
            {
                return null;
            }
        }

        public void CloseConnection()
        {
            Connection.Close();
        }

    }
}
