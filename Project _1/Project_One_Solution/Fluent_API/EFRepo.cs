using Fluent_API.Entities;
using Models;

namespace Fluent_API.Entities
{
    public class EFRepo : ITrainerRepo<Trainer>, ISkillsRepo<Skill>,IWork<WorkExperience>
    {
        TrainerDatabaseProjectContext context = new TrainerDatabaseProjectContext();

        public List<Trainer> DisplayTrainer()
        {
            return context.Trainers.ToList();
        }

        public List<Skill> DisplaySkills()
        {
            return context.Skills.ToList();
        }

        public List<WorkExperience> DisplayWork()
        {
            return context.WorkExperiences.ToList();
        }
    }
}