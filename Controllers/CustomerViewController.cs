using Fitness_Center.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows.Controls;

namespace Fitness_Center.Controllers
{
    public class CustomerViewController
    {
        public void LoadCustomerData(DataGrid table)
        {
            var query = "SELECT DISTINCT Users.Name, Users.Surname, Users.Email, Users.UserName, Users.Gender, " +
                "Addresses.Country, Addresses.City, Addresses.Street, Addresses.AddressNumber from Workouts " +
                "INNER JOIN Users ON Workouts.CustomerUserName = Users.UserName INNER JOIN Addresses ON Addresses.AddressId = Users.AddressId " +
                "WHERE Workouts.IsRemoved = '0' AND Workouts.InstructorUserName = '" + LoggedInUserModel.userName + "'";

            SqlConnectController connection = new SqlConnectController();

            connection.OpenConnection();

            DataTable dt = connection.PerformQuery(query);

            ParseGender(dt);

            table.ItemsSource = dt.DefaultView;

            connection.CloseConnection();
        }

        public void ParseGender(DataTable dt)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["Gender"].Equals("Male"))
                    dt.Rows[i]["Gender"] = "Muški";
                else
                    dt.Rows[i]["Gender"] = "Ženski";
            }
        }
    }
}
