
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

public class RegisteredUserModel : IDataErrorInfo
{

    private String name;

    private String surname;

    private String _JMBG;

    private String email;

    private int addressId;

    private String userName;

    private String password;

    private EGender gender;

    private EUserType userType;

    private Boolean isRemoved;

    public string Name { get => name; set => name = value;}
    public string Surname { get => surname; set => surname = value; }
    public string JMBG { get => _JMBG; set => _JMBG = value; }
    public string Email { get => email; set => email = value; }
    public int AddressId { get => addressId; set => addressId = value; }
    public string UserName { get => userName; set => userName = value; }
    public string Password { get => password; set => password = value; }
    public EGender Gender { get => gender; set => gender = value; }
    public EUserType UserType { get => userType; set => userType = value; }
    public bool IsRemoved { get => isRemoved; set => isRemoved = value; }

    public RegisteredUserModel() 
    {

        Name = "";
        Surname = "";
        JMBG = "";
        Email = "";
        AddressId = 0;
        UserName = "";
        Password = "";
        Gender = gender;
        UserType = userType;
        IsRemoved = false;

    }
    public RegisteredUserModel(string name, string surname, string _JMBG, string email, int addressId, string userName,
        string password, EGender gender, EUserType userType, bool isRemoved) 
    {
        Name = name;
        Surname = surname;
        JMBG = _JMBG;
        Email = email;
        AddressId = addressId;
        UserName = userName;
        Password = password;
        Gender = gender;
        UserType = userType;
        IsRemoved = isRemoved;
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

            if (propertyName == "Name")
            {
                if (Regex.IsMatch(Name, @"\d"))
                {
                    result = "Ime nije validno";
                }
                if (Name.Length <= 2)
                {
                    result = "Ime je prekratko";
                }
                if (string.IsNullOrEmpty(Name))
                {
                    result = "Ovo polje je obavazno";
                }

            }

            if (propertyName == "Surname")
            {
                if (Regex.IsMatch(Surname, @"\d"))
                {
                    result = "Prezime nije validno";
                }
                if (Surname.Length <= 2)
                {
                    result = "Prezime je prekratko";
                }
                if (string.IsNullOrEmpty(Surname))
                {
                    result = "Ovo polje je obavazno";
                }

            }

            if (propertyName == "UserName")
            {
                if (UserName.Length <= 4)
                {
                    result = "Korisnièko ime je prekratko";
                }
                if (string.IsNullOrEmpty(UserName))
                {
                    result = "Ovo polje je obavazno";
                }

            }

            if (propertyName == "Email")
            {
                if (Regex.IsMatch(Email, @"(^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$)").Equals(false))
                {
                    result = "E-Mail nije validan";
                }
                if (string.IsNullOrEmpty(Email))
                {
                    result = "Ovo polje je obavazno";
                }

            }

            if (propertyName == "Password")
            {

                if (Password.Length <= 5)
                {
                    result = "Lozinka je prekratka";
                }
                if (string.IsNullOrEmpty(Password))
                {
                    result = "Ovo polje je obavazno";
                }

            }

            if (propertyName == "JMBG")
            {
                if (JMBG.Length != 13)
                {
                    result = "JMBG nije validan";
                }
                if (JMBG.Any(Char.IsLetter))
                {
                    result = "JMBG sme sadržati samo brojeve";
                }
                if (string.IsNullOrEmpty(JMBG))
                {
                    result = "Ovo polje je obavazno";
                }
            }

            return result;
        }

    }

    #endregion
}