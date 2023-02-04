using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fluent_API.Entities
{
    public class EFAdditional : IAdditionalsRepo
    {
        TrainerDatabaseProjectContext context;
        public EFAdditional(TrainerDatabaseProjectContext _context)
        {
            context = _context;
        }

        public AdditionalDetail AddAdditional(AdditionalDetail ad)
        {
            context.AdditionalDetails.Add(ad);
            context.SaveChanges();
            return ad;
        }

        public AdditionalDetail DeleteAdditional(int id, string name)
        {
            var sk = context.AdditionalDetails.Where(x => x.TrainerId == id & x.Title == name).SingleOrDefault();
            context.AdditionalDetails.Remove(sk);
            context.SaveChanges();
            return sk;
        }

        public List<AdditionalDetail> DisplayAdditional(string email)
        {
            var ss = from p in context.Trainers
                     join s in context.AdditionalDetails on p.TrainerId equals s.TrainerId
                     where p.Email == email
                     select s;
            return ss.ToList();
        }

        public AdditionalDetail UpdateAdditional(AdditionalDetail ad)
        {
            context.AdditionalDetails.Update(ad);
            context.SaveChanges();
            return ad;
        }
    }
}
