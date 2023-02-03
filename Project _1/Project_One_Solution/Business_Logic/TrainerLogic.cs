
using Fluent_API;
using Models;
using System.Xml;

namespace Business_Logic
{
    public class TrainerLogic : ITrainerLogic
    {

        ITrainerRepo repo;

        public TrainerLogic(ITrainerRepo _repo)
        {
            repo = _repo;
        }

        public Trainer AddTrainers(Trainer trainer)
        {
            return Mapper.Map(repo.AddTrainer(Mapper.Map(trainer)));
        }

        public Trainer RemoveTrainers(string email)
        {
            var d=repo.DeleteTrainer(email);
            return Mapper.Map(d);
        }

        public Trainer UpdateTrainer(string email,Trainer trainer)
        {
            var tra=(from tr in repo.DisplayTrainer()
                     where tr.Email == email
                     select tr).FirstOrDefault();

            if(tra!=null)
            {
                tra.FirstName = trainer.firstName;
                tra.LastName = trainer.lastName;
                tra.Gender = trainer.Gender;
                tra.Password = trainer.Password;
                tra.Phone= trainer.Phone;
                tra.City= trainer.City;
                tra.State= trainer.State;
                tra.Country= trainer.Country;
                tra.AboutMe = trainer.Aboutme;

                tra=repo.UpdateTrainer(tra);
            }
            return Mapper.Map(tra);
        }

        IEnumerable<Trainer> ITrainerLogic.GetTrainers()
        {
            return Mapper.Map(repo.DisplayTrainer());
        }
    }
}