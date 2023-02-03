using Fluent_API;
using Fluent_API.Entities;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic
{
    public class EducationLogic : IEducationLogic
    {
        TrainerDatabaseProjectContext context;
        IEducateRepo repo;
        public EducationLogic(IEducateRepo _repo)
        {
            repo= _repo;
        }

        public Educate AddEducation(int s, Educate educate)
        {
            Education ed=new Education();
            ed.TrainerId = s;
            ed.CollegeUniversity = educate.College_Uni;
            ed.Degree= educate.Degree;
            ed.StartDate = educate.Start_Date;
            ed.EndDate= educate.End_Date;
            ed.Description = educate.Descriptions;

            ed=repo.AddEducations(ed);
            return Mapper.Map(ed);
        }

        public Educate DeleteEducation(int s, string name)
        {
            var d = repo.DeleteEducation(s, name);
            return Mapper.Map(d);
        }

        public IEnumerable<Educate> GetEducation(string email)
        {
            return Mapper.Map(repo.DisplayEducations(email));
        }

        public Educate UpdateEdu(int s,string email, string name,Educate educate)
        {
            var tra = (from tr in repo.DisplayEducations(email)
                       where tr.TrainerId == s & tr.CollegeUniversity == name
                       select tr).FirstOrDefault();

            if (tra != null)
            {
                tra.TrainerId= s;
                tra.CollegeUniversity = educate.College_Uni;
                tra.Degree= educate.Degree;
                tra.StartDate=educate.Start_Date; 
                tra.EndDate = educate.End_Date;
                tra.Description = educate.Descriptions;
               
                tra = repo.UpdateEducation(tra);
            }
            return Mapper.Map(tra);
        }
    }
}
