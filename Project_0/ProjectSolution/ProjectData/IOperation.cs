using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectData
{
    public interface IOperation
    {
        void AddSkills(int Id);
        List<Skills> DisplaySkills(int s);
        //void UpdateSkills();
        void DeleteSkills(int Id);
    }
}
