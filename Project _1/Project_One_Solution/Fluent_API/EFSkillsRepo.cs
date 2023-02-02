using Fluent_API.Entities;
using Models;

namespace Fluent_API.Entities
{
    public class EFSkillsRepo : ISkillsRepo<Skill>
    {
        TrainerDatabaseProjectContext context = new TrainerDatabaseProjectContext();

        public Skill AddSkills(Skill skill)
        {
            Console.WriteLine("\n==========Welcome===========\n");
            Console.WriteLine("Enter your skill : ");
            skill.SkillName=Console.ReadLine();

            context.Skills.Add(skill);
            context.SaveChanges();
            return skill;
        }

        public Skill DeleteSkill(int id)
        {
            Console.WriteLine("\n==========Welcome===========\n");
            Console.WriteLine("Enter your skill want to delete : ");
            string SkillName = Console.ReadLine();
            var sk=context.Skills.Where(x => x.SkillName==SkillName).FirstOrDefault();
            context.Skills.Remove(sk);
            context.SaveChanges();
            return sk;
        }

        public List<Skill> DisplaySkills(string email)
        {
            var ss=from p in context.Trainers 
                   join s in context.Skills on p.TrainerId equals s.TrainerId
                   where p.Email== email
                   select s;
            return ss.ToList();
        }
    }
}
