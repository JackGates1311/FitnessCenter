using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Controls;

namespace Fitness_Center.Controllers
{
    class ViewInstructorsInfoController
    {
        public void loadData(DataGrid table)
        {

            var query = "SELECT Users.Name, Users.Surname, Users.Email, Addresses.Country, Addresses.City, Addresses.Street, " +
                "Addresses.AddressNumber FROM Addresses inner join Users ON Addresses.AddressId = Users.AddressId where Users.UserType = 'Instructor'; ";

            SqlConnectController connection = new SqlConnectController();

            connection.openConnection();

            if (connection != null && connection.Connection.State == ConnectionState.Open)
            {

                SqlCommand cmd = new SqlCommand(query, connection.Connection);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable("Users");

                adapter.Fill(dt);

                table.ItemsSource = dt.DefaultView;

                cmd.Dispose();

                connection.closeConnection();
            }
            else
            {
                return;
            }
        }
    }
}
