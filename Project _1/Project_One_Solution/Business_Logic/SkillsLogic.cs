using Fluent_API;
using Fluent_API.Entities;
using Models;


namespace Business_Logic
{
    public class SkillsLogic : ISkills
    {
        TrainerDatabaseProjectContext context = new TrainerDatabaseProjectContext();
        ISkillsRepo srepo;
        public SkillsLogic(ISkillsRepo _srepo) 
        {
            srepo = _srepo;
        }

        

        public Skills AddSkill(int s,string name)
        {
            Skill ss = new Skill();
            ss.TrainerId = s;
            ss.SkillName = name;

            ss = srepo.AddSkills(ss);
            return Mapper.Map(ss);
            
        }

        public IEnumerable<Skills> GetSkills(string email)
        {
            return Mapper.Map(srepo.DisplaySkills(email));
        }

        public Skills DeleteSl(int id,string sname)
        {
            var d=srepo.DeleteSkill(id,sname);
            return Mapper.Map(d);
        }
    }
}
