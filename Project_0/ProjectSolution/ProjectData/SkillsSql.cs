using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectData
{
    public class SkillsSql:IOperation
    {
        private readonly string cString;
        public SkillsSql(string cString) 
        {
            this.cString = cString;
        }
        public void AddSkills(int ID)
        {
            using SqlConnection con = new SqlConnection(cString);
            int Id = ID;
            con.Open();
            Console.WriteLine("Enter your Skills:");
            string skill=Console.ReadLine();
            string query2 = $"insert into Skills(Trainer_ID,Skills) values({Id},'{skill}')";
            SqlCommand command2 = new SqlCommand(query2,con);
            command2.ExecuteNonQuery();
            Console.WriteLine("\nSkill Added Successfully\n");
            con.Close();
        }

        public List<Skills> DisplaySkills(int Id)
        {
            List<Skills> skills = new List<Skills>();
            using SqlConnection con = new SqlConnection(cString);
            con.Open();
            int ID = Id;
            string query = $"Select Skills from Skills where Trainer_Id={ID}";
            SqlCommand command2 = new SqlCommand(query, con);
            SqlDataReader sdr=command2.ExecuteReader();

            while(sdr.Read())
            {
                skills.Add(new Skills()
                {
                    skillName= sdr.GetString(0),
                }); ;
            }

            return skills;
        }

        public void DeleteSkills(int ID)
        {
            
            using SqlConnection con = new SqlConnection(cString);
            int Id = ID;
            con.Open();
            Console.WriteLine("Enter The SKill that you want to delete: ");
            string del=Console.ReadLine();
            string query = $"delete from skills where Skills='{del}' and Trainer_ID={Id}";
            SqlCommand command2 = new SqlCommand(query,con);
            command2.ExecuteNonQuery();
            Console.WriteLine("\nSuccessfully Deleted..!\n");
            con.Close();
        }
    }
}
