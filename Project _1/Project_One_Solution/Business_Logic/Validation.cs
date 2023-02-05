using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using System.Text.RegularExpressions;
using System.Reflection;
using System.Numerics;

namespace Business_Logic
{
    public static class Validation
    {
        public static string Password(string p)
        {
            string pattern = @"^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])(?=.*[@#$%^&-+=()])(?=\S+$).{8,20}$";
            var IsEmailCheck = Regex.IsMatch(p, pattern);
            if (IsEmailCheck)
                return p;
            else
                throw new UserException("Password must include 1 Uppercase,1 Lowercase,1 digit and 1 special character ,size is minimum 8 to 20 ");
        }

        public static string Email(string p)
        {
            string pattern = @"^(([a-zA-Z]+)(\d+)?)@([a-zA-Z]+).([a-zA-Z]{2,4})$";
            var IsEmailCheck = Regex.IsMatch(p, pattern);
            if (IsEmailCheck)
                return p;
            else
                throw new UserException("Please enter correct email format, Try again");
        }

        public static string Gender(string p)
        {
            string pattern = @"^((M|m)ale)|((F|f)emale)$";
            var IsEmailCheck = Regex.IsMatch(p, pattern);
            if (IsEmailCheck)
                return p;
            else
                throw new UserException("Please enter Either male or female ,Try again");
        }

        public static string Phone(string p)
        {
            string pattern = @"^[6-9]\d{9}$";
            var IsEmailCheck = Regex.IsMatch(p, pattern);
            if (IsEmailCheck)
                return p;
            else
                throw new UserException("Please enter 10 digit number only");
        }

        public static string startdate(string p)
        {
            string pattern = @"^((0[1-9])|(1[0-2]))\/(\d{4})$";
            var IsDateCheck = Regex.IsMatch(p, pattern);
            if (IsDateCheck)
                return p;
            else
                throw new UserException("Please enter the date in format of DD/YYYY only");
        }

        public static string enddate(string p)
        {
            string pattern = @"^((0[1-9])|(1[0-2]))\/(\d{4})$";
            var IsDateCheck = Regex.IsMatch(p, pattern);
            if (IsDateCheck)
                return p;
            else
                throw new UserException("Please enter the date in format of DD/YYYY only");
        }
    }
}
