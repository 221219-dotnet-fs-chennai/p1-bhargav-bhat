using Entities;
using Microsoft.Data.SqlClient;

namespace Data_Logic
{
    public class TrainerSql
    {
        private readonly string cString;
        Trainer trainer = new Trainer();

        public TrainerSql()
        {
        }

        public TrainerSql(string cString)
        {
            this.cString = cString;
        }
        public List<Trainer> DisplayTrainer()
        {
            List<Trainer> edu = new List<Trainer>();
            using SqlConnection con = new SqlConnection(cString);
            con.Open();
            //int ID = s;
            string query = "Select * from Trainer";
            SqlCommand command2 = new SqlCommand(query, con);
            SqlDataReader sdr = command2.ExecuteReader();

            while (sdr.Read())
            {
                edu.Add(new Trainer()
                {
                    FirstName = sdr.GetString(1),
                    LastName = sdr.GetString(2),
                    Gender = sdr.GetString(3),
                    Email = sdr.GetString(4),
                    Password = sdr.GetString(5),
                    Phone = sdr.GetString(6),
                    City = sdr.GetString(7),
                    State = sdr.GetString(8),
                    Country = sdr.GetString(9),
                    AboutMe = sdr.GetString(10)

                }); ;
            }
            con.Close();
            return edu;

        }

    }
}