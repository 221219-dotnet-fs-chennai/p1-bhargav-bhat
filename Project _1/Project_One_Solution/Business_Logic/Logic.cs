﻿using Models;
using Fluent_API;

namespace Business_Logic
{
    public class Logic : ILogic
    {

        ITrainerRepo<Fluent_API.Entities.Trainer> repo;
        ISkillsRepo<Fluent_API.Entities.Skill> skillRepo;
        IWork<Fluent_API.Entities.WorkExperience> work;
        public Logic()
        {
            repo = new Fluent_API.Entities.EFRepo();
        }
        public IEnumerable<Models.Trainer> GetTrainers()
        {
            return Mapper.Map(repo.DisplayTrainer());
        }

        public IEnumerable<Models.Skills> GetSkills()
        {
            return Mapper.Map(skillRepo.DisplaySkills());
        }

        public IEnumerable<Models.WorkExperience> GetWorkExperiences()
        {
            return Mapper.Map(work.DisplayWork());
        }
    }
}