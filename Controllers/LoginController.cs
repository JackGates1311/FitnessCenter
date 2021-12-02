
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




    public void loginToSystem(String userName, String password) {

        var query = "SELECT * FROM users WHERE username = '" + userName + "' AND password = '" + password + "';";

        SqlConnectController connection = new SqlConnectController();

        connection.openConnection();

        if (connection != null && connection.Connection.State == ConnectionState.Open)
        {

            SqlCommand cmd = new SqlCommand(query, connection.Connection);

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable("Users");

            adapter.Fill(dt);

            cmd.Dispose();

            connection.closeConnection();

            if (dt != null && dt.Rows.Count == 1) 
            {
                LoggedInUserModel.userName = userName;
            }
            else
                MessageBox.Show("Prijava na sistem neuspešna!");
        }
        else
        {
            return;
        }
  
    }

    protected void registerNewUser(String name, String surname, String JMBG, String email, String userName, String password, EGender gender) {
        // TODO implement here
        return;
    }

}