using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public interface IEdu<T>
    {
        List<T> DisplayEducations();
    }
}
