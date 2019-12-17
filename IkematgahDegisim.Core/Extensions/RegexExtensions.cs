using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace IkematgahDegisim.Core.Extensions
{
    public static class RegexExtensions
    {
        public static Regex CreateTcKimlikRegex(this Regex regex)
        {    
            regex=new Regex(@"/^[1-9]{1}[0-9]{10}$");
            return regex;
        }

        public static Regex CreatePhoneNumberRegex(this Regex regex)
        {
            regex = new Regex(@"/^(05)([0-9]{2})\s?([0-9]{3})\s?([0-9]{2})\s?([0-9]{2})$/");
            return regex;
        }

        public static Regex CreateBirthDateRegex(this Regex regex)
        {
            regex = new Regex(@"/^([1-9]|[12][0-9]|3[01])(\/?\.?\-?\s?)(0[1-9]|1[12])(\/?\.?\-?\s?)(19[0-9][0-9]|20[0][0-9]|20[1][0-8])$/"); 
            return regex;
        }


        public static Regex CreateEmailRegex(this Regex regex)
        {
            regex = new Regex(@"/^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$");
            return regex;
        }

        public static Regex CreatePasswordRegex(this Regex regex)
        {

            regex = new Regex(@"/^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[#$^+=!*()@%&]).{8,10}$");
            return regex;
        }


        public static bool VerifyToRegex(this Regex regex,string input)
        {
            return regex.IsMatch(input);
        }
    }
}
