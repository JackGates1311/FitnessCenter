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

        public void openConnection()
        {
            connectionString = (@"Data Source = MAKI-PC; Initial Catalog=fitnessCenter; Integrated Security = True");

            Connection = new SqlConnection(connectionString);

            try
            {
                Connection.Open();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.ToString());
            }
        }
        public void closeConnection()
        {
            Connection.Close();
        }

    }
}
