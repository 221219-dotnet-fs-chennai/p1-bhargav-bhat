using Fluent_API.Entities;
using Models;

namespace Fluent_API.Entities
{
    public class EFRepo : ITrainerRepo<Trainer>
    {
        TrainerDatabaseProjectContext context = new TrainerDatabaseProjectContext();


        public List<Trainer> DisplayTrainer()
        {
            return context.Trainers.ToList();
        }
    }
}