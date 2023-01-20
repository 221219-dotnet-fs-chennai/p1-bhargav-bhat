using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectData
{
    public class WorkExperienceSwitch
    {
        public string cString;
        public WorkExperienceSwitch(string cString)
        {
            this.cString = cString;
        }

        public void WESwitch(string s)
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
            WorkExperienceSql ss = new WorkExperienceSql(File.ReadAllText("../../../cString.txt"));
            main:
            try
            {
                do
                {
                    Console.WriteLine("\n1.View Work Experience Details\n2.Add Work Experience Data\n3.Update Work Experience Data\n4.Delete Work Experience Data\nPress 0 to Return Main Menu\n");
                    Console.WriteLine("Enter your choice: ");
                    ch = Convert.ToInt32(Console.ReadLine());
                    switch (ch)
                    {
                        case 0:
                            Console.WriteLine("Thank You");
                            break;
                        case 1:
                            List<WorkExperience> list1 = ss.DisplayWorkExperience(Id);
                            Console.WriteLine("--------------------Work Experience Details---------------");
                            int a = 0;
                            foreach (var item in list1)
                            {
                                a++;
                                Console.WriteLine("\nWork Experience "+a+" : \n");
                                Console.WriteLine(item.ToString());
                            }
                            break;
                        case 2:
                            ss.AddWorkExperience(Id);
                            break;
                        case 3:
                            List<WorkExperience> list2 = ss.DisplayWorkExperience(Id);
                            Console.WriteLine("--------------------Work Experience Details---------------");
                            foreach (var item in list2)
                            {
                                Console.WriteLine(item.ToString());
                            }
                            ss.UpdateWorkExperience(Id);
                            break;
                        case 4:
                            List<WorkExperience> list3 = ss.DisplayWorkExperience(Id);
                            Console.WriteLine("--------------------Work Experience Details---------------");
                            foreach (var item in list3)
                            {
                                Console.WriteLine(item.ToString());
                            }
                            ss.DeleteWorkExperience(Id);
                            break;
                        default:
                            Console.WriteLine("Invalid Choice, Please enter correct choice...!");
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
