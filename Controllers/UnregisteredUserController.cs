
using Fitness_Center.Controllers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows;

public class UnregisteredUserController 
{

    public UnregisteredUserController() 
    {


    }


    public void registerNewUser(RegisteredUserModel user, AddressModel address)
    {
        var query = "INSERT INTO Users values ('" + user.Name + "', '" + user.Surname + "', '" + user.JMBG + "', " +
            "'" + user.Email + "', (SELECT MAX(AddressId) as AddressId FROM Users) + 1, '" + user.UserName + "', '" + user.Password + "', " +
            "'" + user.Gender.ToString() + "', '" + user.UserType.ToString() + "', '0') " +
            "INSERT INTO Addresses values ((SELECT MAX(AddressId) as AddressId FROM Users), '" + address.Country + "', '" + address.City + "', " +
            "'" + address.Street + "', '" + address.Number + "');";

        SqlConnectController connection = new SqlConnectController();

        connection.openConnection();

        DataTable dt = connection.performQuery(query);

        MessageBox.Show("Korisnik je uspe�no registrovan!");
    }

}