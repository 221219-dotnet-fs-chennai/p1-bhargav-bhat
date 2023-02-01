using Fluent_API.Entities;
using Models;


namespace Fluent_API
{
    public class EFRepo : ITrainerRepo<Entities.Trainer>
    {
        TrainerDatabaseProjectContext context = new TrainerDatabaseProjectContext();

        public Entities.Trainer AddTrainer(Entities.Trainer t)
        {

            Console.WriteLine("\n==========Welcome===========\n");
            Console.WriteLine("Enter your First name : ");
                t.FirstName = Console.ReadLine();
            Console.WriteLine("Enter your Last name : ");
            t.LastName = Console.ReadLine();
            Console.WriteLine("Enter your Gender : ");
            t.Gender = Console.ReadLine();
            Console.WriteLine("Enter your Email : ");
            t.Email = Console.ReadLine();
            Console.WriteLine("Enter your Password : ");
            t.Password = string.Empty;
            ConsoleKey key;
            do
            {
                var keyInfo = Console.ReadKey(intercept: true);
                key = keyInfo.Key;

                if (key == ConsoleKey.Backspace && t.Password.Length > 0)
                {
                 Console.Write("\b \b");
                 t.Password = t.Password[0..^1];
                 }
                 else if (!char.IsControl(keyInfo.KeyChar))
                 {
                 Console.Write("*");
                 t.Password += keyInfo.KeyChar;
                 }
             } while (key != ConsoleKey.Enter);
             Console.WriteLine("\nEnter your Phone Number : ");
             t.Phone = Console.ReadLine();
             Console.WriteLine("Enter your City : ");
             t.City = Console.ReadLine();
             Console.WriteLine("Enter your State : ");
             t.State = Console.ReadLine();
             Console.WriteLine("Enter your Country : ");
             t.Country = Console.ReadLine();
             Console.WriteLine("Please tell us something about yourself : ");
             t.AboutMe = Console.ReadLine();

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

        public List<Entities.Trainer> FetchTrainer(string email)
        {

            var tr = from t in context.Trainers
                     where t.Email == email
                     select t;
            return tr.ToList();
        }

        public Entities.Trainer UpdateTrainer(Entities.Trainer t)
        {
            Console.WriteLine("\n==========Welcome===========\n");
            Console.WriteLine("Enter your First name : ");
            t.FirstName = Console.ReadLine();
            Console.WriteLine("Enter your Last name : ");
            t.LastName = Console.ReadLine();
            Console.WriteLine("Enter your Gender : ");
            t.Gender = Console.ReadLine();
            Console.WriteLine("Enter your Password : ");
            t.Password = string.Empty;
            ConsoleKey key;
            do
            {
                var keyInfo = Console.ReadKey(intercept: true);
                key = keyInfo.Key;

                if (key == ConsoleKey.Backspace && t.Password.Length > 0)
                {
                    Console.Write("\b \b");
                    t.Password = t.Password[0..^1];
                }
                else if (!char.IsControl(keyInfo.KeyChar))
                {
                    Console.Write("*");
                    t.Password += keyInfo.KeyChar;
                }
            } while (key != ConsoleKey.Enter);
            Console.WriteLine("\nEnter your Phone Number : ");
            t.Phone = Console.ReadLine();
            Console.WriteLine("Enter your City : ");
            t.City = Console.ReadLine();
            Console.WriteLine("Enter your State : ");
            t.State = Console.ReadLine();
            Console.WriteLine("Enter your Country : ");
            t.Country = Console.ReadLine();
            Console.WriteLine("Please tell us something about yourself : ");
            t.AboutMe = Console.ReadLine();

            context.Trainers.Update(t);
            context.SaveChanges();

            return t;
        }

        //public Trainer UpdateTrainer(Trainer trainers)
        //{
        //    context.Trainers.Update(trainers);
        //    context.SaveChanges();
        //    return trainers;
        //}
    }
}
