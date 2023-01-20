using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectData
{
    public interface IOperation2
    {
        void AddEducation(int Id);
        void DeleteEducation(int Id);
        void UpdateEducation(int Id);

        List<Educational> DisplayEducations(int Id);
    }
}
