
using Fitness_Center.Controllers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows;

public class RegisteredUserController {

    public RegisteredUserController() 
    {


    }

    public void getRegisteredUserInfo() 
    {

        ICollection<RegisteredUserModel> registeredUsers = new List<RegisteredUserModel>();

        var query = "SELECT * from Users";

        SqlConnectController connection = new SqlConnectController();

        connection.openConnection();

        DataTable dt = connection.performQuery(query);

        RegisteredUserModel user = new RegisteredUserModel();

        user.Name = dt.Rows[0]["Name"].ToString();
        user.Surname = dt.Rows[0]["Surname"].ToString();
        user.JMBG = dt.Rows[0]["JMBG"].ToString();
        user.Email = dt.Rows[0]["Email"].ToString();
        user.AddressId = Convert.ToInt32(dt.Rows[0]["AddressId"]);
        user.UserName = dt.Rows[0]["UserName"].ToString();
        user.Password = dt.Rows[0]["Password"].ToString();
        user.Gender = EGender.Male;
        user.UserType = EUserType.Administrator;
        user.IsRemoved = Boolean.Parse(dt.Rows[0]["IsRemoved"].ToString());

        registeredUsers.Add(user);

        MessageBox.Show(user.UserName.ToString());


        connection.closeConnection();

        MessageBox.Show(registeredUsers.Count.ToString() + "\n" + registeredUsers.ToString());
    }

    protected void changeRegisteredUserInfo(String JMBG) 
    {
        // TODO implement here
        return;
    }

    protected void logoutFromSystem() 
    {
        // TODO implement here
        return;
    }

}