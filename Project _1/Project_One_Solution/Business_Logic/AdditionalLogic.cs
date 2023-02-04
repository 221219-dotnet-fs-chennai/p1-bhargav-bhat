using Fluent_API.Entities;
using Fluent_API;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic
{
    public class AdditionalLogic:IAddLogic
    {
        TrainerDatabaseProjectContext context;
        IAdditionalsRepo repo;
        public AdditionalLogic(IAdditionalsRepo _repo)
        {
            repo = _repo;
        }

        public Additional AddAdditional(int s, Additional ad)
        {
            AdditionalDetail d = new AdditionalDetail();
            d.TrainerId = s;
            d.Title= ad.Title;
            d.Achievements = ad.Achievments;
            d.Publications = ad.Publications;
            d.VolunteeringExperiences = ad.Volunteering_Experiences;

            d=repo.AddAdditional(d);
            return Mapper.Map(d);
        }

        public Additional DeleteAddtional(int s, string name)
        {
            var d = repo.DeleteAdditional(s, name);
            return Mapper.Map(d);
        }

        public IEnumerable<Additional> DisplayAdditional(string email)
        {
            return Mapper.Map(repo.DisplayAdditional(email));
        }

        public Additional UpdateAdditional(int s, string email, string name, Additional ad)
        {
            var tra = (from tr in repo.DisplayAdditional(email)
                       where tr.TrainerId == s & tr.Title == name
                       select tr).FirstOrDefault();

            if (tra != null)
            {
                tra.TrainerId = s;
                tra.Title = ad.Title;
                tra.Achievements= ad.Achievments;
                tra.Publications = ad.Publications;
                tra.VolunteeringExperiences = ad.Volunteering_Experiences;

                tra = repo.UpdateAdditional(tra);
            }
            return Mapper.Map(tra);
        }
    }
}
