using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectData
{
    public class AdditionalSwitch
    {
        public string cString;
        public AdditionalSwitch(string cString)
        {
            this.cString = cString;
        }

        public void ADSwitch(string s)
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
            AdditionalSql asql = new AdditionalSql(File.ReadAllText("../../../cString.txt"));
            main:
            try
            {
                do
                {
                    
                    Console.WriteLine("\n1.View Additional Details\n2.Add Additional Details\n3.Update Additional Details\n4.Delete Additional Details\nPress 0 to Return Main Menu\n");
                    Console.WriteLine("Enter your choice: ");
                    ch = Convert.ToInt32(Console.ReadLine());
                    switch (ch)
                    {
                        case 0:
                            Console.WriteLine("\nThank You...");
                            break;
                        case 1:
                            List<AdditionalDetails> list1 = asql.DisplayData(Id);
                            Console.WriteLine("--------------------Additional Details-------------------");
                            int a = 0;
                            foreach (var item in list1)
                            {
                                Console.WriteLine("Additional Details "+a+" : ");
                                Console.WriteLine(item.ToString());
                            }
                            break;
                        case 2:
                            asql.AddAdditionalData(Id);
                            break;
                        case 3:
                            List<AdditionalDetails> list2 = asql.DisplayData(Id);
                            Console.WriteLine("--------------------Additional Details-------------------");
                            foreach (var item in list2)
                            {
                                Console.WriteLine(item.ToString());
                            }
                            asql.UpdateWorkExperience(Id);
                            break;
                        case 4:
                            List<AdditionalDetails> list3 = asql.DisplayData(Id);
                            Console.WriteLine("--------------------Additional Details-------------------");
                            foreach (var item in list3)
                            {
                                Console.WriteLine(item.ToString());
                            }
                            asql.DeleteWorkExperience(Id);
                            break;
                        default:
                            Console.WriteLine("Invalid Choice, Please enter correct choice...!");
                            break;
                    }

                } while (ch > 0);
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
