using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using System.Text.RegularExpressions;

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
                return null;
            
        }
    }
}
