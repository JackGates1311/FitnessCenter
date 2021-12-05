
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

public class FitnessCenterModel : IDataErrorInfo
{

    public FitnessCenterModel() {
    }

    private String id;

    private String centerName;

    private String address;

    public string Id { get => id; set => id = value; }
    public string CenterName { get => centerName; set => centerName = value; }
    public string Address { get => address; set => address = value; }

    public string Error => throw new NotImplementedException();

    #region IDataErrorInfo Members

    public string this[string propertyName] 
    {
        get
        {
            string result = null;

            if (propertyName == "Id")
            {

                if (Id.ToString().Length != 7)
                {
                    result = "Ovo polje mora sadržati taèno 7 brojeva";
                }

                if (Id.ToString().Any(Char.IsLetter))
                {
                    result = "Ovo polje sme samo sadržati brojeve";
                }

                if (String.IsNullOrEmpty(Convert.ToString(Id)))
                {
                    result = "Ovo polje je obavazno";
                }
            }

            if (propertyName == "CenterName")
            {
                if (string.IsNullOrEmpty(CenterName.ToString()))
                {
                    result = "Ovo polje je obavezno";
                }
            }

            return result;
        }
    }

    #endregion
}