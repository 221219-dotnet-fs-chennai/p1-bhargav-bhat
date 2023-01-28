using Fluent_API.Entities;
using Models;
using System.Text.RegularExpressions;

namespace Fluent_API.Entities
{
    public class EFRepo : ITrainerRepo<Trainer>
    {
        TrainerDatabaseProjectContext context = new TrainerDatabaseProjectContext();

        public Models.Trainer AddTrainer(Models.Trainer trainer)
        {
            Trainer t = new Trainer();

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
            trainer.Password = string.Empty;
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
            
             return trainer;
        }


        public List<Trainer> DisplayTrainer()
        {
            return context.Trainers.ToList();
        }

        public List<Trainer> FetchTrainer(string email)
        {

            var tr = from t in context.Trainers
                     where t.Email == email
                     select t;
            return tr.ToList();
        }
    }
}
