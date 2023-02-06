using Fluent_API;
using Fluent_API.Entities;
using Models;


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
            ed.StartDate = Validation.startdate(educate.Start_Date)?educate.Start_Date : throw new UserException("Please enter the date in format of DD/YYYY only");
            ed.EndDate= Validation.enddate(educate.End_Date)?educate.End_Date : throw new UserException("Please enter the date in format of DD/YYYY only"); 
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
                tra.StartDate= Validation.startdate(educate.Start_Date) ? educate.Start_Date : throw new UserException("Please enter the date in format of DD/YYYY only");
                tra.EndDate = Validation.enddate(educate.End_Date) ? educate.End_Date : throw new UserException("Please enter the date in format of DD/YYYY only");
                tra.Description = educate.Descriptions;
               
                tra = repo.UpdateEducation(tra);
            }
            return Mapper.Map(tra);
        }
    }
}
