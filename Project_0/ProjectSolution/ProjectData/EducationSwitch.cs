using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectData
{
    public class EducationSwitch
    {
        public string cString;
        public EducationSwitch(string cString)
        {
            this.cString = cString;
        }

        public void ESwitch(string s)
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
            EducationalSql ss = new EducationalSql(File.ReadAllText("../../../cString.txt"));
            main1:
            try
            {
                do
                {
                    Console.Clear();
                    Console.WriteLine("\n1.View Educations Details\n2.Add Educational Data\n3.Update Educational Data\n4.Delete Educational Data\n Press 0 to Return Main Menu\n");
                    Console.WriteLine("Enter your choice: ");
                    ch = Convert.ToInt32(Console.ReadLine());
                    switch (ch)
                    {
                        case 0:
                            Console.WriteLine("Thank You ");
                            Console.WriteLine("\nPress any key to Continue...");
                            Console.ReadKey();
                            break;
                        case 1:
                            List<Educational> list1 = ss.DisplayEducations(Id);
                            Console.WriteLine("--------------------Education Details---------------");
                            int a = 0;
                            foreach (var item in list1)
                            {
                                a++;
                                Console.WriteLine("\nEducational Details "+a+" : ");
                                Console.WriteLine(item.ToString());
                            }
                            Console.WriteLine("\nPress any key to Continue...");
                            Console.ReadKey();
                            break;
                        case 2:
                            ss.AddEducation(Id);
                            Console.WriteLine("\nPress any key to Continue...");
                            Console.ReadKey() ;
                            break;
                        case 3:
                            List<Educational> list2 = ss.DisplayEducations(Id);
                            Console.WriteLine("--------------------Education Details---------------");
                            foreach (var item in list2)
                            {
                                Console.WriteLine(item.ToString());
                            }
                            ss.UpdateEducation(Id);
                            Console.WriteLine("\nPress any key to Continue...");
                            Console.ReadKey();
                            break;
                        case 4:
                            List<Educational> list3 = ss.DisplayEducations(Id);
                            Console.WriteLine("--------------------Education Details---------------");
                            foreach (var item in list3)
                            {
                                Console.WriteLine(item.ToString());
                            }
                            ss.DeleteEducation(Id);
                            Console.WriteLine("\nPress any key to Continue...");
                            Console.ReadKey();
                            break;
                        default:
                            Console.WriteLine("Invalid Choice, Please enter correct choice...!");
                            Console.ReadKey();
                            break;
                    }

                } while (ch > 0);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message+"Please try again press any key to continue");
                Console.ReadKey();
                goto main1;
            }
        }
    }
}
