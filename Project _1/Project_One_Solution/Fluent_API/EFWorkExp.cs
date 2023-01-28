
using Models;
using System;

namespace Fluent_API.Entities
{
    public class EFWorkExp : IWork<WorkExperience>
    {
        TrainerDatabaseProjectContext context = new TrainerDatabaseProjectContext();

        public List<WorkExperience> DisplayWork()
        {
            return context.WorkExperiences.ToList();
        }
    }
}
