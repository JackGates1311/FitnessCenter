
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class AddressModel {

    public AddressModel() {
    }

    private int id;

    private String street;

    private String number;

    private String city;

    private String country;

    public int Id { get => id; set => id = value; }
    public string Street { get => street; set => street = value; }
    public string Number { get => number; set => number = value; }
    public string City { get => city; set => city = value; }
    public string Country { get => country; set => country = value; }
}