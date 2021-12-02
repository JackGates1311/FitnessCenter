
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

public class AddressModel : IDataErrorInfo
{

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


    public AddressModel()
    {
        Id = 0;
        Street = "";
        Number = "";
        City = "";
        Country = "";

    }

    public AddressModel(int id, string street, string number, string city, string country)
    {
        Id = id;
        Street = street;
        Number = number;
        City = city;
        Country = country;
    }

    public override string ToString()
    {
        return base.ToString();
    }

    #region IDataErrorInfo Members

    public string Error => throw new NotImplementedException();

    public string this[string propertyName]
    {
        get
        {
            string result = null;

            if (propertyName == "Country")
            {
                if (Regex.IsMatch(Country, @"\d"))
                {
                    result = "Država ne postoji";
                }
                if (string.IsNullOrEmpty(Country))
                {
                    result = "Ovo polje je obavazno";
                }
            }

            if (propertyName == "City")
            {
                if (Regex.IsMatch(City, @"\d"))
                {
                    result = "Grad ne postoji";
                }
                if (string.IsNullOrEmpty(City))
                {
                    result = "Ovo polje je obavazno";
                }
            }

            if (propertyName == "Street")
            {
                if (Regex.IsMatch(Street, @"\d"))
                {
                    result = "Ulica ne postoji";
                }
                if (string.IsNullOrEmpty(Street))
                {
                    result = "Ovo polje je obavazno";
                }
            }

            if (propertyName == "Number")
            {
                if (Number.Length > 10)
                {
                    result = "Broj nije validan";
                }
                if (string.IsNullOrEmpty(Number))
                {
                    result = "Ovo polje je obavazno";
                }
            }

            return result;
        }


    }

    #endregion
}