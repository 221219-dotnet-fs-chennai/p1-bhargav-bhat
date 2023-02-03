using Models;
using System;

namespace Fluent_API.Entities
{
    public class EFEducational : IEducateRepo
    {
        TrainerDatabaseProjectContext context;

        public EFEducational(TrainerDatabaseProjectContext _context)
        {
            context= _context;
        }

        public Education AddEducations(Education education)
        {
            context.Educations.Add(education);
            context.SaveChanges();
            return education;
        }

        public Education DeleteEducation(int id, string sname)
        {
            var sk = context.Educations.Where(x => x.TrainerId==id & x.CollegeUniversity==sname).SingleOrDefault();
            context.Educations.Remove(sk);
            context.SaveChanges();
            return sk;
        }

        public List<Education> DisplayEducations(string email)
        {
            var ss = from p in context.Trainers
                     join s in context.Educations on p.TrainerId equals s.TrainerId
                     where p.Email == email
                     select s;
            return ss.ToList();
        }

        public Education UpdateEducation(Education education)
        {
            context.Educations.Update(education); 
            context.SaveChanges();
            return education;   
        }
    }
}
