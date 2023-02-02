using Fluent_API;
using Fluent_API.Entities;
using Models;


namespace Business_Logic
{
    public class SkillsLogic : ISkills
    {
        TrainerDatabaseProjectContext context = new TrainerDatabaseProjectContext();
        ISkillsRepo<Fluent_API.Entities.Skill> srepo;
        public SkillsLogic() 
        {
            srepo = new EFSkillsRepo();
        }

        public int IdFetcher(string email)
        {
            var ss = (from p in context.Trainers
                      where p.Email == email
                      select p.TrainerId).SingleOrDefault();
                      
            return ss;
        }

        public Skills AddSkill(int s,Skills skill)
        {
            Skill ss = new Skill();
            ss.TrainerId = s;
            ss.SkillName = skill.skillName;

            ss = srepo.AddSkills(ss);
            return Mapper.Map(ss);
            
        }

        public IEnumerable<Skills> GetSkills(string email)
        {
            return Mapper.Map(srepo.DisplaySkills(email));
        }

        public Skills DeleteSl(int s)
        {
            var d=srepo.DeleteSkill(s);
            return Mapper.Map(d);
        }
    }
}
