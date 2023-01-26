using Data_Logic;
using Entities;
using Fluent_API;

public static class Program
{
    public static void Main()
    {
        //TrainerSql ts=new TrainerSql();
        EFRepo ef=new EFRepo();
        Console.WriteLine("Printing..");
        var data=ef.GetTrainer();
        foreach(var r in data)
        {
            Console.WriteLine(r);
        }
    }
}