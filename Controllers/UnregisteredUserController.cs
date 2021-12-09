
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

    public void RegisterNewUser(RegisteredUserModel user, AddressModel address, Fitness_Center.Views.UserInfoView userInfoView)
    {
        var query = "INSERT INTO Users values ('" + user.Name + "', '" + user.Surname + "', '" + user.JMBG + "', " +
            "'" + user.Email + "', (SELECT MAX(AddressId) as AddressId FROM Users) + 1, '" + user.UserName + "', '" + user.Password + "', " +
            "'" + user.Gender.ToString() + "', '" + user.UserType.ToString() + "', '0') " +
            "INSERT INTO Addresses values ((SELECT MAX(AddressId) as AddressId FROM Users), '" + address.Country + "', '" + address.City + "', " +
            "'" + address.Street + "', '" + address.Number + "');";

        SqlConnectController connection = new SqlConnectController();

        connection.OpenConnection();

        try
        {
            DataTable dt = connection.PerformQuery(query);

            MessageBox.Show("Korisnik je uspešno registrovan!", "Obaveštenje - Fitnes centar", MessageBoxButton.OK, MessageBoxImage.Information);

            userInfoView.CloseParentWindow();
        }
        catch
        {
            MessageBox.Show("Korisnik je veæ registrovan sa istim korisnièkim imenom ili JMBG-om na sistem", "Upozorenje - Fitnes centar", 
                MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        connection.CloseConnection();


    }

}