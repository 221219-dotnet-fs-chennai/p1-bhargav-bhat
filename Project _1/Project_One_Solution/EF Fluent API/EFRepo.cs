using Entities;
using Fluent_API;
using Microsoft.Data.SqlClient;
using Models;

namespace Fluent_API
{
    public class EFRepo: IRepo<Entities.Trainer>
    {
        TrainerDatabaseProjectContext context =new TrainerDatabaseProjectContext();
        string cString = File.ReadAllText("E:\\GitRepo\\p1-bhargav-bhat\\Project _1\\Project_One_Solution\\Console UI\\cString.txt");
        public List<Entities.Trainer> GetTrainer()
        {
            using SqlConnection con=new SqlConnection(cString); 
            con.Open();
            return context.Trainers.ToList();
        }

    }
}