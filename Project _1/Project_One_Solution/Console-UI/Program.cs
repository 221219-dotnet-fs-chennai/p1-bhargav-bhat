using Business_Logic;

public static class Program
{
    public static void Main(string[] args)
    {
        ILogic l = new Logic();
        Console.WriteLine("Fetching........");
        Console.WriteLine("---------------------- Profile View --------------------");
        var t = l.GetTrainers();
        foreach (var i in t)
        {
            Console.WriteLine(i.ToString());
        }
        Console.WriteLine("------------------------ Skills -------------------------");
        var s = l.GetSkills();
        foreach (var i in s)
        {
            Console.WriteLine(i.ToString());
        }
        Console.WriteLine("------------------------ Work Experience -------------------------");
        var w = l.GetWorkExperiences();
        foreach (var i in w)
        {
            Console.WriteLine(i.ToString());
        }
        Console.WriteLine("-------------------------------------------------------------------");
    }
}