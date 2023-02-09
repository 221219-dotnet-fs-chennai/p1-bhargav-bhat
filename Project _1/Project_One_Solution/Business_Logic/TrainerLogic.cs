
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
            trainer.Gender = Validation.Gender(trainer.Gender)? trainer.Gender : throw new UserException("Please enter Either male or female ,Try again");
            trainer.Email = Validation.Email(trainer.Email)?trainer.Email : throw new UserException("Please enter correct email format, Try again"); ;
            trainer.Password= Validation.Password(trainer.Password)?trainer.Password : throw new UserException("Password must include 1 Uppercase,1 Lowercase,1 digit and 1 special character ,size is minimum 8 to 20"); ;
            trainer.Phone= Validation.Phone(trainer.Phone)?trainer.Phone: throw new UserException("Please enter 10 digit number only"); ;
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
                tra.Gender = Validation.Gender(trainer.Gender)? trainer.Gender : throw new UserException("Please enter Either male or female ,Try again");
                tra.Password = Validation.Password(trainer.Password)?trainer.Password: throw new UserException("Password must include 1 Uppercase,1 Lowercase,1 digit and 1 special character ,size is minimum 8 to 20"); ;
                tra.Phone= Validation.Phone(trainer.Phone)?trainer.Phone: throw new UserException("Please enter 10 digit number only"); ;
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

        public Trainer FetchTrainer(string email) 
        {
            var tra=(from t in repo.DisplayTrainer()
                    where t.Email == email
                    select t).FirstOrDefault();
            return Mapper.Map(tra);
        }
    }
}