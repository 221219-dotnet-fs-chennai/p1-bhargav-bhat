using Models;
using System;


namespace Fluent_API.Entities
{
    public class EFSkillsRepo : ISkillsRepo<Skill>
    {
        TrainerDatabaseProjectContext context = new TrainerDatabaseProjectContext();

        public List<Skill> DisplaySkills()
        {
            return context.Skills.ToList();
        }
    }
}
