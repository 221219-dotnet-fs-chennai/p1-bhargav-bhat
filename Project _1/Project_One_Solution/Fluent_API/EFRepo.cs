using Fluent_API.Entities;


namespace Fluent_API
{
    public class EFRepo : ITrainerRepo<Entities.Trainer>
    {
        TrainerDatabaseProjectContext context = new TrainerDatabaseProjectContext();

        public Trainer AddTrainer(Trainer t)
        {
             context.Trainers.Add(t);
             context.SaveChanges();
            
             return t;
        }

        public Entities.Trainer DeleteTrainer(string email)
        {
            var s=context.Trainers.Where(t=>t.Email == email).FirstOrDefault();
            context.Trainers.Remove(s);
            context.SaveChanges();
            return s;
        }

        public List<Entities.Trainer> DisplayTrainer()
        {
            return context.Trainers.ToList();
        }

        public Entities.Trainer UpdateTrainer(Entities.Trainer t)
        {
            context.Trainers.Update(t);
            context.SaveChanges();

            return t;
        }

    }
}
