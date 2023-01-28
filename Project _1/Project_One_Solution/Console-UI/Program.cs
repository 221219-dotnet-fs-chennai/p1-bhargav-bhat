using Business_Logic;
using Fluent_API.Entities;

public static class Program
{
    public static void Main(string[] args)
    {
        ILogic l = new Logic();
        EFSkillsRepo e= new EFSkillsRepo();
        EFRepo eFS = new EFRepo();
        Console.WriteLine("Fetching........");
        Console.WriteLine("---------------------------- Profile View --------------------------");
        var t = l.GetTrainers();
        foreach (var i in t)
        {
            Console.WriteLine(i.ToString());
        }
        Console.WriteLine("---------------------------- Skills --------------------------------");
        var s = l.GetSkills();
        foreach (var i in s)
        {
            Console.WriteLine(i.ToString());
        }
        Console.WriteLine("------------------------ Work Experience ---------------------------");
        var w = l.GetWorkExperiences();
        foreach (var i in w)
        {
            Console.WriteLine(i.ToString());
        }
        Console.WriteLine("------------------------ Education Details -------------------------");
        var edu = l.GetEducations();
        foreach (var i in edu)
        {
            Console.WriteLine(i.ToString());
        }
        Console.WriteLine("------------------------ Additional Details -------------------------");
        var addi = l.GetAdditionals();
        foreach (var i in addi)
        {
            Console.WriteLine(i.ToString());
        }
        Console.WriteLine("----------------------------------------------------------------------");
    }
}