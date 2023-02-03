using Fluent_API.Entities;
using Models;

namespace Fluent_API.Entities
{
    public class EFSkillsRepo : ISkillsRepo
    {
        TrainerDatabaseProjectContext context;

        public EFSkillsRepo(TrainerDatabaseProjectContext _context)
        {
            context= _context;
        }
        public Skill AddSkills(Skill skill)
        {
            context.Skills.Add(skill);
            context.SaveChanges();
            return skill;
        }

        public Skill DeleteSkill(int id,string sname)
        {
            var sk=context.Skills.Where(x => x.SkillName==sname && x.TrainerId==id).SingleOrDefault();
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
