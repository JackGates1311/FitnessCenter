
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class FitnessCenterModel {

    public FitnessCenterModel() {
    }

    private int id;

    private String centerName;

    private String address;

    public int Id { get => id; set => id = value; }
    public string CenterName { get => centerName; set => centerName = value; }
    public string Address { get => address; set => address = value; }
}