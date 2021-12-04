
using Fitness_Center.Controllers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

public class FitnessCenterController {

    public FitnessCenterController() 
    {

    }
    internal void fetchFitnessCenterInfo(FitnessCenterModel fitnessCenterModel)
    {
        var query = "SELECT fitnessCenter.FitnessCenterID, fitnessCenter.Center, Addresses.Street, " +
            "Addresses.AddressNumber, Addresses.City, Addresses.Country FROM Addresses " +
            "inner join fitnessCenter ON Addresses.AddressId = fitnessCenter.AddressID";

        SqlConnectController connection = new SqlConnectController();

        connection.openConnection();

        DataTable dt = connection.performQuery(query);

        fitnessCenterModel.Id = Convert.ToInt32(dt.Rows[0]["FitnessCenterID"]);
        fitnessCenterModel.CenterName = dt.Rows[0]["Center"].ToString();

        String fullAddress = dt.Rows[0]["Street"].ToString() + " " + dt.Rows[0]["AddressNumber"].ToString()
            + ", " + dt.Rows[0]["City"].ToString() + ", " + dt.Rows[0]["Country"].ToString();

        fitnessCenterModel.Address = fullAddress;

        connection.closeConnection();
    }

}