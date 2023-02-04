
using Models;
using System;

namespace Fluent_API.Entities
{
    public class EFWorkExpRepo : IWorkRepo
    {
        TrainerDatabaseProjectContext context;

        public EFWorkExpRepo(TrainerDatabaseProjectContext _context)
        {
            context= _context;
        }

        public WorkExperience AddEWorkDetails(WorkExperience work)
        {
            context.WorkExperiences.Add(work);
            context.SaveChanges();
            return work;
        }

        public WorkExperience DeleteWorkDetails(int id, string name)
        {
            var sk = context.WorkExperiences.Where(x => x.TrainerId == id & x.CompanyName == name).SingleOrDefault();
            context.WorkExperiences.Remove(sk);
            context.SaveChanges();
            return sk;
        }

        public List<WorkExperience> DisplayWork(string email)
        {
            var ss = from p in context.Trainers
                     join s in context.WorkExperiences on p.TrainerId equals s.TrainerId
                     where p.Email == email
                     select s;
            return ss.ToList();
        }

        public WorkExperience UpdateWorkDetails(WorkExperience work)
        {
            context.WorkExperiences.Update(work);
            context.SaveChanges();
            return work;
        }
    }
}
