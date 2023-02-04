using Fluent_API.Entities;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fluent_API
{
    public interface IWorkRepo
    {
        List<WorkExperience> DisplayWork(string email);

        WorkExperience UpdateWorkDetails(WorkExperience work);

        WorkExperience AddEWorkDetails(WorkExperience work);

        WorkExperience DeleteWorkDetails(int id, string email);
    }
}
