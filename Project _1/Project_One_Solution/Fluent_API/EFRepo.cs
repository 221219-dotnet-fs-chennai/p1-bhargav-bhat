using Fluent_API.Entities;
using Models;

namespace Fluent_API.Entities
{
    public class EFRepo: ITrainerRepo<Entities.Trainer> ,ISkillsRepo<Entities.Skill>
    {
        TrainerDatabaseProjectContext context=new TrainerDatabaseProjectContext();

        public List<Entities.Trainer> DisplayTrainer()
        {
            return context.Trainers.ToList();
        }

        public List<Entities.Skill> DisplaySkills()
        {
            return context.Skills.ToList();
        }
    }
}