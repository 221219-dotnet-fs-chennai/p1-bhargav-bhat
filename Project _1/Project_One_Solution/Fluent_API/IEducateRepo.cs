using Fluent_API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fluent_API
{
    public interface IEducateRepo
    {
        List<Education> DisplayEducations(string email);

        Education UpdateEducation(Education education);

        Education AddEducations(Education education);

        Education DeleteEducation(int id, string email);
    }
}
