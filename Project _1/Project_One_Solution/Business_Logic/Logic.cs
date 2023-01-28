using Models;


namespace Business_Logic
{
    public class Logic : ILogic
    {

        ITrainerRepo<Fluent_API.Entities.Trainer> repo;
        ISkillsRepo<Fluent_API.Entities.Skill> skillRepo;
        IWork<Fluent_API.Entities.WorkExperience> work;
        IEdu<Fluent_API.Entities.Education> edu;
        IAdditionals<Fluent_API.Entities.AdditionalDetail> addit;
        public Logic()
        {
            repo = new Fluent_API.Entities.EFRepo();
            skillRepo=new Fluent_API.Entities.EFSkillsRepo();
            work = new Fluent_API.Entities.EFWorkExp();
            edu = new Fluent_API.Entities.EFEducational();
            addit = new Fluent_API.Entities.EFAdditional();
        }

        public IEnumerable<Additional> GetAdditionals()
        {
            return Mapper.Map(addit.DisplayAdditional());
        }

        public IEnumerable<Educate> GetEducations()
        {
            return Mapper.Map(edu.DisplayEducations());
        }

        public IEnumerable<Models.Skills> GetSkills()
        {
            return Mapper.Map(skillRepo.DisplaySkills());
        }

        public IEnumerable<Models.Trainer> GetTrainers()
        {
            return Mapper.Map(repo.DisplayTrainer());
        }

        public IEnumerable<WorkE> GetWorkExperiences()
        {
            return Mapper.Map(work.DisplayWork());
        }
    }
}