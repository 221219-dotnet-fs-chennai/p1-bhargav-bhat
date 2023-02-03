using Fluent_API.Entities;


namespace Fluent_API
{
    public class EFTrainerRepo : ITrainerRepo
    {
        private readonly TrainerDatabaseProjectContext context;

        public EFTrainerRepo(TrainerDatabaseProjectContext _context)
        {
            context = _context;
        }

        public int IdFetcher(string email)
        {
            var ss = (from p in context.Trainers
                      where p.Email == email
                      select p.TrainerId).SingleOrDefault();

            return ss;
        }
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
