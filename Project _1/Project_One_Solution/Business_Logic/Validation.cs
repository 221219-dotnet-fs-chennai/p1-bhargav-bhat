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
        public static bool Password(string p)
        {
            string pattern = @"^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])(?=.*[@#$%^&-+=()])(?=\S+$).{8,20}$";
            var IsEmailCheck = Regex.IsMatch(p, pattern);
            if (IsEmailCheck)
                return true;
            else
                return false;
                
        }

        public static bool Email(string p)
        {
            string pattern = @"^(([a-zA-Z]+)(\d+)?)@([a-zA-Z]+).([a-zA-Z]{2,4})$";
            var IsEmailCheck = Regex.IsMatch(p, pattern);
            if (IsEmailCheck)
                return true;
            else
                return false;
                
        }

        public static bool Gender(string p)
        {
            string pattern = @"^((M|m)ale)|((F|f)emale)$";
            var IsEmailCheck = Regex.IsMatch(p, pattern);
            if (IsEmailCheck)
                return true;
            else
                return false;
        }

        public static bool Phone(string p)
        {
            string pattern = @"^[6-9]\d{9}$";
            var IsEmailCheck = Regex.IsMatch(p, pattern);
            if (IsEmailCheck)
                return true;
            else
                return false;
                
        }

        public static bool startdate(string p)
        {
            string pattern = @"^((0[1-9])|(1[0-2]))\/(\d{4})$";
            var IsDateCheck = Regex.IsMatch(p, pattern);
            if (IsDateCheck)
                return true;
            else
                return false;
                
        }

        public static bool enddate(string p)
        {
            string pattern = @"^((0[1-9])|(1[0-2]))\/(\d{4})$";
            var IsDateCheck = Regex.IsMatch(p, pattern);
            if (IsDateCheck)
                return true;
            else
                return false;
               
        }
    }
}
