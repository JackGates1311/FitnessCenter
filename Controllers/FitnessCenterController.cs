
using Fitness_Center.Controllers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows;

public class FitnessCenterController {

    public FitnessCenterController() 
    {

    }
    public void FetchFitnessCenterInfo(FitnessCenterModel fitnessCenter, AddressModel address)
    {
        var query = "SELECT fitnessCenter.FitnessCenterID, fitnessCenter.Center, Addresses.Street, " +
            "Addresses.AddressNumber, Addresses.City, Addresses.Country FROM Addresses " +
            "inner join fitnessCenter ON Addresses.AddressId = fitnessCenter.AddressID";

        SqlConnectController connection = new SqlConnectController();

        connection.openConnection();

        DataTable dt = connection.performQuery(query);

        fitnessCenter.Id = dt.Rows[0]["FitnessCenterID"].ToString();
        fitnessCenter.CenterName = dt.Rows[0]["Center"].ToString();

        String fullAddress = dt.Rows[0]["Street"].ToString() + " " + dt.Rows[0]["AddressNumber"].ToString()
            + ", " + dt.Rows[0]["City"].ToString() + ", " + dt.Rows[0]["Country"].ToString();

        address.Country = dt.Rows[0]["Country"].ToString();
        address.City = dt.Rows[0]["City"].ToString();
        address.Street = dt.Rows[0]["Street"].ToString();
        address.Number = dt.Rows[0]["AddressNumber"].ToString();

        fitnessCenter.Address = fullAddress;

        connection.closeConnection();
    }

    public void ChangeFitnessCenterInfo(FitnessCenterModel fitnessCenter, AddressModel address) 
    {
        var query = "UPDATE FitnessCenter SET FitnessCenterId = '" + fitnessCenter.Id + "', Center = '" + fitnessCenter.CenterName + "' " +
            "WHERE AddressId = 100 " + "UPDATE Addresses SET Country = '" + address.Country + "', City = '" + address.City + "', " +
            "Street = '" + address.Street + "', AddressNumber = '" + address.Number + "' where AddressId = 100;";

        SqlConnectController connection = new SqlConnectController();

        connection.openConnection();

        DataTable dt = connection.performQuery(query);

        MessageBox.Show("Podaci o fitnes centru su uspešno izmenjeni!", "Obaveštenje - Fitnes centar", MessageBoxButton.OK, MessageBoxImage.Information);

    }

}