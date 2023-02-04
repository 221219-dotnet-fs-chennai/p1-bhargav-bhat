using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic
{
    public interface IAddLogic
    {
        IEnumerable<Additional> DisplayAdditional(string email);
        Additional UpdateAdditional(int s, string email, string name, Additional ad);

        Additional AddAdditional(int s, Additional ad);

        Additional DeleteAddtional(int s, string name);
    }
}
