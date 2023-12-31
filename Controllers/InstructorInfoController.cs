﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace Fitness_Center.Controllers
{
    class InstructorInfoController
    {
        public void LoadInstructorData(DataGrid table, String Name, String Surname, String Email, String Street)
        {
            var query = "SELECT Users.Name, Users.Surname, Users.Email, Addresses.Country, Addresses.City, Addresses.Street, " +
                "Addresses.AddressNumber FROM Addresses INNER JOIN Users ON Addresses.AddressId = Users.AddressId WHERE Users.UserType = 'Instructor' " +
                "AND IsRemoved='0' AND Name LIKE '%" + Name + "%' and Surname LIKE '%" + Surname + "%' and Street LIKE '%" + Street + "%' and Email LIKE '%" + 
                Email + "%'";

            SqlConnectController connection = new SqlConnectController();

            connection.OpenConnection();

            DataTable dt = connection.PerformQuery(query);

            table.ItemsSource = dt.DefaultView;

            connection.CloseConnection();
        }

    }
}
