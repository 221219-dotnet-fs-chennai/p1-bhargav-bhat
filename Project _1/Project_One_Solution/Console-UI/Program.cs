using Business_Logic;
using Fluent_API;
using Fluent_API.Entities;

public static class Program
{
    public static void Main(string[] args)
    {
        Models.Trainer trainer = new Models.Trainer();
        EFSkillsRepo e = new EFSkillsRepo();
        EFRepo eFS = new EFRepo();
        ILogic l = new Logic();


        //l.AddTrainers(trainer); ---------------------adding trainer


        Console.WriteLine("Enter email to fetch data : ");
        string email = Console.ReadLine();


        l.UpdateTrainer(email, trainer);

        //l.RemoveTrainers(email);-----------------------------Delete



    }
}