using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectData
{
    public interface IOperations4
    {
        List<AdditionalDetails> DisplayData(int s);
        void AddAdditionalData(int ID);
        void DeleteWorkExperience(int ID);
        void UpdateWorkExperience(int ID);
    }
}
