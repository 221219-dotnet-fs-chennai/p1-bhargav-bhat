using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectData
{
    public interface IOperations3
    {
        void AddWorkExperience(int Id);
        void UpdateWorkExperience(int Id);
        void DeleteWorkExperience(int Id);
        List<WorkExperience> DisplayWorkExperience(int s);
    }
}
