using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectData
{
    public class AdditionalSql
    {
        private readonly string cString;
        public AdditionalSql(string cString)
        {
            this.cString = cString;
        }

        public List<AdditionalDetails> DisplayData(int s)
        {
            List<AdditionalDetails> edu = new List<AdditionalDetails>();
            using SqlConnection con = new SqlConnection(cString);
            con.Open();
            int ID = s;
            string query = $"Select Title,Achievements,Publications,Volunteering_Experiences from AdditionalDetails where Trainer_Id={ID}";
            SqlCommand command2 = new SqlCommand(query, con);
            SqlDataReader sdr = command2.ExecuteReader();

            while (sdr.Read())
            {
                edu.Add(new AdditionalDetails()
                {
                    Title=sdr.GetString(0),
                    Achievments = sdr.GetString(1),
                    Publications = sdr.GetString(2),
                    Volunteering_Experiences = sdr.GetString(3)
                }); ;
            }
            return edu;
        }

        public void AddAdditionalData(int ID)
        {
            using SqlConnection con = new SqlConnection(cString);
            int Id = ID;
            con.Open();
            Console.WriteLine("Enter the Title for Additional Details : ");
            string t = Console.ReadLine();
            Console.WriteLine("Enter your Achievements (If Any) : ");
            string ach = Console.ReadLine();
            Console.WriteLine("Enter your Publications (If Any) : ");
            string pub = Console.ReadLine();
            Console.WriteLine("Enter your Volunteering Experiences (If Any): ");
            string vol= Console.ReadLine();
            
            string query2 = $"insert into AdditionalDetails(Trainer_ID,Title,Achievements,Publications,Volunteering_Experiences) values({Id},'{t}','{ach}','{pub}','{vol}')";
            SqlCommand command2 = new SqlCommand(query2, con);
            command2.ExecuteNonQuery();
            Console.WriteLine("\nAdditional Details Added Successfully\n");
            con.Close();
        }

        public void DeleteWorkExperience(int ID)
        {

            using SqlConnection con = new SqlConnection(cString);
            int Id = ID;
            con.Open();
            Console.WriteLine("Enter the Title that you want to delete: ");
            string del = Console.ReadLine();
            string query = $"delete from AdditionalDetails where Title='{del}' and Trainer_ID= {Id}";
            SqlCommand command2 = new SqlCommand(query, con);
            command2.ExecuteNonQuery();
            Console.WriteLine("\nSuccessfully Deleted..!\n");
            con.Close();
        }

        public void UpdateWorkExperience(int ID)
        {
            using SqlConnection con = new SqlConnection(cString);
            int Id = ID;
            con.Open();
            Console.WriteLine("Please enter the Title to update your details");
            string up = Console.ReadLine();
            Console.WriteLine("Please fill the Updated Details");
            Console.WriteLine("Enter the New Title ");
            string t = Console.ReadLine();
            Console.WriteLine("Enter your Achievements (If Any) :");
            string ach = Console.ReadLine();
            Console.WriteLine("Enter your Publications (If Any) : ");
            string pub = Console.ReadLine();
            Console.WriteLine("Enter your Volunteering Experiences (If Any) :");
            string vol = Console.ReadLine();
            

            string query = $"update AdditionalDetails set Title='{t}',Achievements='{ach}',Publications='{pub}',Volunteering_Experiences='{vol}' where Title='{up}' and Trainer_ID={Id}";
            SqlCommand command3 = new SqlCommand(query, con);
            command3.ExecuteNonQuery();
            Console.WriteLine("\nSuccessfully Updated\n");
            con.Close();
        }
    }
}
