using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectData
{
    public class TrainerSwitch
    {
        public string cString;
        public TrainerSwitch(string cString)
        {
            this.cString= cString;
        }

        public int TSwitch(string s)
        {
            int ch,d=0;
            
            TrainerSql ss = new TrainerSql(File.ReadAllText("../../../cString.txt"));
            TrainerSwitch ts = new TrainerSwitch(File.ReadAllText("../../../cString.txt"));
            SkillsSql skills = new SkillsSql(File.ReadAllText("../../../cString.txt"));
            SkillSwitch skillSwitch = new SkillSwitch(File.ReadAllText("../../../cString.txt"));
            EducationalSql esql = new EducationalSql(File.ReadAllText("../../../cString.txt"));
            EducationSwitch es = new EducationSwitch(File.ReadAllText("../../../cString.txt"));
            WorkExperienceSql we = new WorkExperienceSql(File.ReadAllText("../../../cString.txt"));
            WorkExperienceSwitch wes = new WorkExperienceSwitch(File.ReadAllText("../../../cString.txt"));
            AdditionalSql asl = new AdditionalSql(File.ReadAllText("../../../cString.txt"));
            AdditionalSwitch asw = new AdditionalSwitch(File.ReadAllText("../../../cString.txt"));
            // Fetching Id of the Trainer
            string u = s;
            using SqlConnection con = new SqlConnection(cString);
            con.Open();
            string userName = s;
            string query1 = $"select Trainer_Id from Trainer where Email='{userName}'";
            SqlCommand command1 = new SqlCommand(query1, con);
            SqlDataReader reader = command1.ExecuteReader();
            reader.Read();
            int Id = reader.GetInt32(0);
            con.Close();
            main:
            try
            {
                do
                {
                    Console.Clear();
                    Console.WriteLine("\n1.View Profile\n2.Update Profile\n3.Delete Profile\nPress 0 to Return Main Menu\n");
                    Console.WriteLine("Enter your choice: ");
                    ch = Convert.ToInt32(Console.ReadLine());
                    switch (ch)
                    {
                        case 0:
                            Console.WriteLine("Thanks...");
                            Console.ReadKey();
                            return 0;
                        case 1:Console.Clear();
                            {
                                List<Trainer> list5 = ss.DisplayTrainer(Id);
                                Console.WriteLine("\n---------------------Profile Details-----------------------");
                                foreach (var item in list5)
                                {
                                    Console.WriteLine(item.ToString());
                                }
                                List<Educational> list3 = esql.DisplayEducations(Id);
                                Console.WriteLine("\n--------------------Education Details---------------------");
                                int x = 0;
                                foreach (var item in list3)
                                {
                                    x++;
                                    Console.Write("\nEducation Details " + x + " : \n");
                                    Console.WriteLine(item.ToString());
                                }
                                List<WorkExperience> list2 = we.DisplayWorkExperience(Id);
                                Console.WriteLine("\n--------------------Work Experience Details---------------");
                                int a = 0;
                                foreach (var item in list2)
                                {
                                    a++;
                                    Console.Write("\nWork Experience " + a + " : \n");
                                    Console.WriteLine(item.ToString());
                                }
                                List<Skills> list1 = skills.DisplaySkills(Id);
                                Console.WriteLine("\n-------------------------Skills----------------------------");
                                int c = 0;
                                foreach (var item in list1)
                                {
                                    c++;
                                    Console.Write("Skill " + c + " : ");
                                    Console.WriteLine(item.ToString());
                                }
                                List<AdditionalDetails> list4 = asl.DisplayData(Id);
                                Console.WriteLine("\n--------------------Additional Details---------------------");
                                int y = 0;
                                foreach (var item in list4)
                                {
                                    y++;
                                    Console.Write("\nAdditional Details " + y + " : \n");
                                    Console.WriteLine(item.ToString());
                                }
                                Console.WriteLine("\n-------------------------------------------------------------");
                                Console.WriteLine("\nPress any key to Go Back");
                                
                            }
                            Console.ReadKey();
                            break;
                        case 2:
                            ss.UpdateTrainer(u);
                            
                            break;
                        case 3:
                            d = ss.DeleteProfile(Id);
                            if (d == 1)
                            {
                                return d;
                            }
                            else
                            {
                                Console.WriteLine("Returning to menu...(Press any Key to Continue)");
                                
                            }
                            break;
                        default:
                            Console.WriteLine("Invalid Choices Please Try Again");
                            
                            break;
                    }

                } while (ch > 0);
                return d;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
                goto main;
            }
        }
    }
}
