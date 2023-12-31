
using Fitness_Center.Controllers;
using Fitness_Center.Models;
using Fitness_Center.Views;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

public class RegisteredUserController {

    public RegisteredUserController() 
    {


    }

    public void GetRegisteredUserInfo(RegisteredUserModel user, AddressModel address, String queryProperty) 
    {
        var query = "SELECT Users.Name, Users.Surname, Users.JMBG, Users.Email, Users.AddressId, Users.UserName, Users.Password, " +
            "Users.Gender, Users.UserType, Users.IsRemoved, " +
            "Addresses.Country, Addresses.City, Addresses.Street, Addresses.AddressNumber from Addresses " +
            "INNER JOIN Users ON Addresses.AddressId = Users.AddressId " +
            "WHERE " + queryProperty + ";";

        SqlConnectController connection = new SqlConnectController();

        connection.OpenConnection();

        DataTable dt = connection.PerformQuery(query);

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

        connection.CloseConnection();
    }

    public void LoadUserData(DataGrid table, String queryProperty, String queryHideDeletedUsers, String Name, String Surname, String Email, String Street)
    {
        var query = "SELECT Users.AddressId, Users.Name, Users.Surname, Users.JMBG, Users.Email, Users.UserName, Users.Password, Users.Gender, Users.UserType, " +
            "Addresses.Country, Addresses.City, Addresses.Street, Addresses.AddressNumber, Users.IsRemoved " +
            "FROM Users INNER JOIN Addresses ON Addresses.AddressId = Users.AddressId " + queryProperty + " " + queryHideDeletedUsers +
            " AND Name LIKE '%" + Name + "%' and Surname LIKE '%" + Surname + "%' and Street LIKE '%" + Street + "%' and Email LIKE '%" + Email + "%'" + " ;";

        SqlConnectController connection = new SqlConnectController();

        connection.OpenConnection();

        DataTable dt = connection.PerformQuery(query);

        ParseGenderAndUserType(dt);

        table.ItemsSource = dt.DefaultView;

        connection.CloseConnection();

    }

    private void ParseGenderAndUserType(DataTable dt)
    {
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            if (dt.Rows[i]["Gender"].Equals("Male"))
                dt.Rows[i]["Gender"] = "M";
            else
                dt.Rows[i]["Gender"] = "�";

            if (dt.Rows[i]["UserType"].Equals("Instructor"))
                dt.Rows[i]["UserType"] = "Instruktor";
            if (dt.Rows[i]["UserType"].Equals("Customer"))
                dt.Rows[i]["UserType"] = "Polaznik";

        }
    }

    public void ChangeRegisteredUserInfo(RegisteredUserModel user, AddressModel address, String queryPropertyUsers, String queryPropertyAddresses) 
    {
        var query = "UPDATE Users SET Name = '" + user.Name + "', " + "Surname = '" + user.Surname + "', " +
            "Email = '" + user.Email + "', Password = '" + user.Password + "', Gender = '" + user.Gender.ToString() + "' " +
            "WHERE " + queryPropertyUsers + 
            "UPDATE Addresses SET Country = '" + address.Country +"', City = '" + address.City + "', " +
            "Street = '" + address.Street + "', AddressNumber = '" + address.Number + "' " +
            "FROM Users AS u INNER JOIN Addresses AS a ON u.AddressId = a.AddressId AND " + queryPropertyAddresses + ";";

        SqlConnectController connection = new SqlConnectController();

        connection.OpenConnection();

        DataTable dt = connection.PerformQuery(query);

        connection.CloseConnection();

        MessageBox.Show("Podaci o ulogovanom korisniku su uspe�no izmenjeni", "Obave�tenje - Fitnes centar", MessageBoxButton.OK, MessageBoxImage.Information);

    }

    public void RemoveUser(String selectedRowId)
    { 
    
    }

}