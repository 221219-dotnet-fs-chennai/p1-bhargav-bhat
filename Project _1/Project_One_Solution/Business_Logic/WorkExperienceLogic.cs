using Fluent_API.Entities;
using Fluent_API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Business_Logic
{
    public class WorkExperienceLogic : IWork
    {
        TrainerDatabaseProjectContext context;
        IWorkRepo repo;

        public WorkExperienceLogic(IWorkRepo _repo)
        {
            repo= _repo;
        }

        public WorkE AddWork(int s, WorkE work)
        {
            WorkExperience w=new WorkExperience();

            w.TrainerId = s;
            w.CompanyName = work.Company_Name;
            w.Role=work.Role;
            w.StartDate= Validation.startdate(work.StartDate)?work.StartDate : throw new UserException("Please enter the date in format of DD/YYYY only"); ;
            w.EndDate= Validation.enddate(work.EndDate)?work.EndDate : throw new UserException("Please enter the date in format of DD/YYYY only"); ;
            w.Description= work.Description;

            w = repo.AddEWorkDetails(w);
            return Mapper.Map(w);
        }

        public WorkE DeleteWork(int s, string name)
        {
            var d = repo.DeleteWorkDetails(s, name);
            return Mapper.Map(d);
        }

        public IEnumerable<WorkE> GetWork(string email)
        {
            return Mapper.Map(repo.DisplayWork(email));
        }

        public WorkE UpdateWorkExp(int s, string email, string name, WorkE work)
        {
            var tra = (from tr in repo.DisplayWork(email)
                       where tr.TrainerId == s & tr.CompanyName == name
                       select tr).FirstOrDefault();

            if (tra != null)
            {
                tra.TrainerId= s;
                tra.CompanyName= work.Company_Name;
                tra.Role= work.Role;
                tra.StartDate= Validation.startdate(work.StartDate)?work.StartDate : throw new UserException("Please enter the date in format of DD/YYYY only"); ;
                tra.EndDate= Validation.enddate(work.EndDate)?work.EndDate : throw new UserException("Please enter the date in format of DD/YYYY only"); ;
                tra.Description= work.Description;

                tra=repo.UpdateWorkDetails(tra);
            }

            return Mapper.Map(tra);

        }
    }
}
