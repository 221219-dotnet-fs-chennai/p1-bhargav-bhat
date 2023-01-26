using Data_Logic;
using Models;

namespace Business_Logic
{
    public class Logic : ILogic
    {
        TrainerSql tsql;
        public Logic (string cString)
        {
            tsql= new TrainerSql (cString);
        }

        public IEnumerable<Trainer> GetTrainers()
        {
            return (IEnumerable<Trainer>)tsql.DisplayTrainer();
        }
    }
}