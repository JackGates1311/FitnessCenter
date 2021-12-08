
using Fitness_Center.Controllers;
using Fitness_Center.Models;
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

    public void getRegisteredUserInfo(RegisteredUserModel user, AddressModel address) 
    {

        var query = "select Users.Name, Users.Surname, Users.JMBG, Users.Email, Users.AddressId, Users.UserName, Users.Password, " +
            "Users.Gender, Users.UserType, Users.IsRemoved, " +
            "Addresses.Country, Addresses.City, Addresses.Street, Addresses.AddressNumber from addresses " +
            "inner join Users ON Addresses.AddressId = Users.AddressId " +
            "where Users.UserName LIKE '" + LoggedInUserModel.userName + "'";

        SqlConnectController connection = new SqlConnectController();

        connection.openConnection();

        DataTable dt = connection.performQuery(query);

        user.Name = dt.Rows[0]["Name"].ToString();
        user.Surname = dt.Rows[0]["Surname"].ToString();
        user.JMBG = dt.Rows[0]["JMBG"].ToString();
        user.Email = dt.Rows[0]["Email"].ToString();
        user.AddressId = Convert.ToInt32(dt.Rows[0]["AddressId"]);
        address.Country = dt.Rows[0]["Country"].ToString();
        address.City = dt.Rows[0]["City"].ToString();
        address.Street = dt.Rows[0]["Street"].ToString();
        address.Number = dt.Rows[0]["AddressNumber"].ToString();
        user.UserName = dt.Rows[0]["UserName"].ToString();
        user.Password = dt.Rows[0]["Password"].ToString();

        if (dt.Rows[0]["Gender"].Equals(EGender.Male.ToString()))
            user.Gender = EGender.Male;
        if (dt.Rows[0]["Gender"].Equals(EGender.Female.ToString()))
            user.Gender = EGender.Female;

        if (dt.Rows[0]["UserType"].Equals("Administrator"))
            user.UserType = EUserType.Administrator;
        else if (dt.Rows[0]["UserType"].Equals("Instructor"))
            user.UserType = EUserType.Instructor;
        else
            user.UserType = EUserType.Customer;

        user.IsRemoved = Boolean.Parse(dt.Rows[0]["IsRemoved"].ToString());

        connection.closeConnection();
    }

    public void changeRegisteredUserInfo(RegisteredUserModel user, AddressModel address) 
    {
        var query = "UPDATE Users SET Name = '" + user.Name + "', " + "Surname = '" + user.Surname + "', " +
            "Email = '" + user.Email + "', Password = '" + user.Password + "', Gender = '" + user.Gender.ToString() + "' " +
            "WHERE UserName LIKE '" + LoggedInUserModel.userName +  "' " +
            "UPDATE Addresses SET Country = '" + address.Country +"', City = '" + address.City + "', " +
            "Street = '" + address.Street + "', AddressNumber = '" + address.Number + "' " +
            "FROM Users AS u INNER JOIN Addresses AS a ON u.AddressId = a.AddressId AND UserName LIKE '" + LoggedInUserModel.userName +
            "' WHERE u.UserName LIKE '" + LoggedInUserModel.userName + "' ;";

        SqlConnectController connection = new SqlConnectController();

        connection.openConnection();

        DataTable dt = connection.performQuery(query);

        MessageBox.Show("Podaci o ulogovanom korisniku su uspešno izmenjeni!", "Obaveštenje - Fitnes centar", MessageBoxButton.OK, MessageBoxImage.Information);

    }

}