using Models;
using System;

namespace Fluent_API.Entities
{
    public class EFEducational : IEdu<Education>
    {
        TrainerDatabaseProjectContext context = new TrainerDatabaseProjectContext();

        public List<Education> DisplayEducations()
        {
            return context.Educations.ToList();
        }
    }
}
