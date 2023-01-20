using ProjectData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectConsole
{
    public class Main_Menu
    {
        public void Menu(string s)
        {
            Console.Clear();
            int ch;
            TrainerSql r = new TrainerSql(File.ReadAllText("../../../cString.txt"));
            TrainerSwitch ts = new TrainerSwitch(File.ReadAllText("../../../cString.txt"));
            SkillsSql skills = new SkillsSql(File.ReadAllText("../../../cString.txt"));
            SkillSwitch skillSwitch = new SkillSwitch(File.ReadAllText("../../../cString.txt"));
            EducationalSql esql = new EducationalSql(File.ReadAllText("../../../cString.txt"));
            EducationSwitch es = new EducationSwitch(File.ReadAllText("../../../cString.txt"));
            WorkExperienceSql we = new WorkExperienceSql(File.ReadAllText("../../../cString.txt"));
            WorkExperienceSwitch wes = new WorkExperienceSwitch(File.ReadAllText("../../../cString.txt"));
            AdditionalSql asl = new AdditionalSql(File.ReadAllText("../../../cString.txt"));
            AdditionalSwitch asw = new AdditionalSwitch(File.ReadAllText("../../../cString.txt"));
        step2:
            try
            {
                Log.Information("------Login Successfull------");
                
                do
                {
                    Console.Clear() ;
                    Console.WriteLine("=========================");
                    Console.WriteLine("-        Welcome        -");
                    Console.WriteLine("=========================");
                    Console.WriteLine("1.Profile Data\n2.Educational Data\n3.Work Experience Data\n4.Skills\n5.Additional Data\nPress [0] to Exit\n");
                    Console.WriteLine("=========================");
                    Console.WriteLine("Enter your Choice:");
                    ch = Convert.ToInt32(Console.ReadLine());
                    switch (ch)
                    {
                        case 1:
                            int a = ts.TSwitch(s);
                            Log.Information("------Working with Trainer Table------");
                            if (a == 1)
                            {
                                return;
                            }
                            else
                                break;
                        case 2:
                            es.ESwitch(s);
                            Log.Information("-----Working With Education Table-------");
                            break;
                        case 3:
                            wes.WESwitch(s);
                            Log.Information("-----Working with Work Experience Table -------");
                            break;
                        case 4:
                            skillSwitch.SSwitch(s);
                            Log.Information("-----Working with Skills Table-------");
                            break;
                        case 5:
                            asw.ADSwitch(s);
                            Log.Information("------Working with Additional Details Table------");
                            break;
                        case 0:
                            Console.WriteLine("Thank you You are redirecting to the Sign In/Sign Up Menu....");
                            Console.ReadKey();
                            return;
                        default:
                            Console.WriteLine("Invalid Choice Please Re-Enter your Choice:");
                            Console.ReadKey();  
                            break;
                    }

                } while (ch > 0);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
                goto step2;
            }
        }
    }
}
