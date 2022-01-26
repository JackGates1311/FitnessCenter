
using Fitness_Center.Controllers;
using Fitness_Center.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows;

public class LoginController {

    public LoginController() {

    }

    public Boolean loginToSystem(String userName, String password) {

        var query = "SELECT * FROM users WHERE username = '" + userName + "' COLLATE SQL_Latin1_General_Cp1_CS_AS AND password = '" + password 
            + "' COLLATE SQL_Latin1_General_Cp1_CS_AS " + "AND IsRemoved = 0;";

        SqlConnectController connection = new SqlConnectController();

        connection.OpenConnection();

        if (connection != null && connection.Connection.State == ConnectionState.Open)
        {

            SqlCommand cmd = new SqlCommand(query, connection.Connection);

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable("Users");

            adapter.Fill(dt);

            cmd.Dispose();

            connection.CloseConnection();

            if (dt != null && dt.Rows.Count == 1) 
            {
                LoggedInUserModel.userName = userName;

                if (dt.Rows[0]["UserType"].Equals("Administrator"))
                    LoggedInUserModel.userType = EUserType.Administrator;
                else if (dt.Rows[0]["UserType"].Equals("Instructor"))
                    LoggedInUserModel.userType = EUserType.Instructor;
                else
                    LoggedInUserModel.userType = EUserType.Customer;

                return true;
            }
            else

                return false;
        }
        else
            return false;
  
    }

}