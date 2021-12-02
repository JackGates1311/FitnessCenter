using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace Fitness_Center.Controllers
{
    class ViewInstructorsInfoController
    {
        public void loadInstructorData(DataGrid table)
        {

            //var registeredUser = new RegisteredUserModel("Marko", "Mitrovic", "1311001184066", "makimitrovic07@gmail.com", "maxim123", "maxim123", EGender.Male, false);

            var query = "SELECT Users.Name, Users.Surname, Users.Email, Addresses.Country, Addresses.City, Addresses.Street, " +
                "Addresses.AddressNumber FROM Addresses inner join Users ON Addresses.AddressId = Users.AddressId where Users.UserType = 'Instructor'; ";

            SqlConnectController connection = new SqlConnectController();

            connection.openConnection();

            DataTable dt = connection.performQuery(query);

            table.ItemsSource = dt.DefaultView;

            connection.closeConnection();
        }
    }
}
