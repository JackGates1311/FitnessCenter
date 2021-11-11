
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public abstract class RegisteredUserModel {

    public RegisteredUserModel() {
    }

    private String name;

    private String surname;

    private String JMBG;

    private String email;

    private String userName;

    private String password;

    private Gender gender;

    private Boolean isRemoved;

    public string Name { get => name; set => name = value; }
    public string Surname { get => surname; set => surname = value; }
    public string JMBG1 { get => JMBG; set => JMBG = value; }
    public string Email { get => email; set => email = value; }
    public string UserName { get => userName; set => userName = value; }
    public string Password { get => password; set => password = value; }
    public Gender Gender { get => gender; set => gender = value; }
    public bool IsRemoved { get => isRemoved; set => isRemoved = value; }
}