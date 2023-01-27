using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic
{
    public class Validation
    {
        public static int HandleStringNulls(int? name)
        {
            if (name.HasValue)
                return name.Value;
            return 0;
        }
    }
}
