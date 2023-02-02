using Business_Logic;
using Fluent_API;
using Fluent_API.Entities;

public static class Program
{
    public static void Main(string[] args)
    {
        Models.Trainer trainer = new Models.Trainer();
        Models.Skills skills= new Models.Skills();
        ISkills e = new SkillsLogic();
        ILogic l = new Logic();
        Console.WriteLine("Enter email to fetch data : ");
        string email = Console.ReadLine();
        int id=e.IdFetcher(email);

        //e.AddSkill(id, skills);
        //e.DeleteSl(id);

        //l.AddTrainers(trainer); //---------------------adding trainer

        //var t=l.GetTrainers();
        //foreach (var i in t)
        //{
        //    Console.WriteLine(i);
        //}




        //var sk=e.GetSkills(email);
        //foreach(var i in sk)
        //{
        //    Console.WriteLine(i.ToString());
        //}

        //l.UpdateTrainer(email, trainer); ---------------update

        //l.RemoveTrainers(email);-----------------------------Delete



    }
}