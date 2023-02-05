using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic
{
    public class UserException: Exception
    {
        public UserException(string s) 
        { 
            throw new Exception(s);
        }
    }
}
