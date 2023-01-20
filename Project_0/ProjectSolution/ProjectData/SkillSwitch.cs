using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ProjectData
{
    public class SkillSwitch
    {
        public string cString;
        public SkillSwitch(string cString)
        {
            this.cString = cString;
        }

        public void SSwitch(string s)
        {

            using SqlConnection con = new SqlConnection(cString);
            con.Open();
            string userName = s;
            string query1 = $"select Trainer_Id from Trainer where Email='{userName}'";
            SqlCommand command1 = new SqlCommand(query1, con);
            SqlDataReader reader = command1.ExecuteReader();
            reader.Read();
            int Id = reader.GetInt32(0);
            con.Close();
            int ch;
            SkillsSql ss = new SkillsSql(File.ReadAllText("../../../cString.txt"));
            main:
            try
            {
                do
                {
                    
                    Console.WriteLine("\n1.View Skills\n2.Add Skill\n3.Delete Skills\n Press 0 to Return Main Menu\n");
                    Console.WriteLine("Enter your choice: ");
                    ch = Convert.ToInt32(Console.ReadLine());
                    switch (ch)
                    {
                        case 1:
                            List<Skills> list1 = ss.DisplaySkills(Id);
                            Console.WriteLine("-----Skills-----");
                            int a = 1;
                            foreach (var item in list1)
                            {
                                Console.WriteLine("\nSkill "+a+" : ");
                                Console.WriteLine(item.ToString());
                            }
                            break;
                        case 2:
                            ss.AddSkills(Id);
                            break;
                        case 3:
                            List<Skills> list2 = ss.DisplaySkills(Id);
                            Console.WriteLine("--Skills--");
                            foreach (var item in list2)
                            {
                                Console.WriteLine(item.ToString());
                            }
                            ss.DeleteSkills(Id);
                            break;
                        case 0:
                            break;
                        default:
                            Console.WriteLine("\nEnter Correct Choice");
                            break;
                    }
                } while (ch > 0);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
                goto main;
            }
        }
    }
}
