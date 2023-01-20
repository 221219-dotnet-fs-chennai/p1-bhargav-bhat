global using Serilog;
using ProjectConsole;
using ProjectData;

namespace UI_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.File(@"..\..\..\Logs\logs.txt", rollingInterval: RollingInterval.Day, rollOnFileSizeLimit: true)
                .CreateLogger();
            Log.Information("---------------Program Starts--------------------");
        step1:
            try
            {
                int ch;
                IRepo1 r = new TrainerSql(File.ReadAllText("../../../cString.txt"));
                Trainer trainer = new Trainer();
                SkillsSql skills = new SkillsSql(File.ReadAllText("../../../cString.txt"));
                SkillSwitch skillSwitch = new SkillSwitch(File.ReadAllText("../../../cString.txt"));
                EducationalSql esql = new EducationalSql(File.ReadAllText("../../../cString.txt"));
                EducationSwitch es = new EducationSwitch(File.ReadAllText("../../../cString.txt"));
                Main_Menu mm = new Main_Menu();
                do
                {
                    Console.Clear();
                    Console.WriteLine("Welcome to Trainers Page");
                    Console.WriteLine("1.Sign In\n2.Sign Up\n3.Exit\n");
                    Console.WriteLine("Plesae Enter your option");
                    ch = Convert.ToInt32(Console.ReadLine());

                    switch (ch)
                    {

                        case 1:
                            string s = r.SignIn();
                            Log.Information("-----------------Signing In-----------------------");
                            if (s != "Exit")
                                mm.Menu(s);
                            else
                            {
                                Console.WriteLine("Exited");
                            }
                            break;
                        case 2:
                            r.SignUp();
                            break;
                        case 3:
                            Log.Information("-------------------Program Ends--------------------");
                            return;

                        default: break;
                    }
                } while (ch > 0);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
                goto step1;
            }
        }
    }
}