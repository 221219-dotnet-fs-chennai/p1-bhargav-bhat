using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using System.Text.RegularExpressions;

namespace ProjectData
{
    public class TrainerSql : IRepo1
    {
        private readonly string cString;
        Trainer trainer = new Trainer();
        public TrainerSql(string cString)
        {
            this.cString = cString;
        }
        
        public string SignIn()
        {
            Trainer trainers = new Trainer();
            string a="Exit";
            int op = 0;
            using SqlConnection con = new SqlConnection(cString);
            con.Open();
            Console.Clear();
            Console.WriteLine("\n======= Welcome =========\n");
            Console.WriteLine("Enter your Email Id : ");
            string uname = Console.ReadLine();
            Console.WriteLine("Enter your Password : ");
            string upass = string.Empty;
            ConsoleKey key;
            do
            {
                var keyInfo = Console.ReadKey(intercept: true);
                key = keyInfo.Key;

                if (key == ConsoleKey.Backspace && upass.Length > 0)
                {
                    Console.Write("\b \b");
                    upass = upass[0..^1];
                }
                else if (!char.IsControl(keyInfo.KeyChar))
                {
                    Console.Write("*");
                    upass += keyInfo.KeyChar;
                }
            } while (key != ConsoleKey.Enter);
            Console.WriteLine("\n\nPress [1] to Confirm\tor\tPress [0] to Exit");
            
            if (Convert.ToInt32(Console.ReadLine())==1)
            {
                string query = "select * from Trainer";
                SqlCommand command1 = new SqlCommand(query, con);
                SqlDataReader reader = command1.ExecuteReader();
                bool suc = false;

                while (reader.Read())
                {
                    trainers.Email = reader.GetString(4);
                    trainers.Password = reader.GetString(5);
                    if (uname == trainers.Email)
                    {
                        if (upass == trainers.Password)
                        {
                            Console.WriteLine("\nSuccess...... (Press any Key to Go Forword)");
                            op = 1;
                            Console.ReadKey();
                            suc = true;
                        }
                        else
                        {
                            Console.WriteLine("\nWrong Password\nPlease Try Again");
                            Console.ReadKey();
                            return a;
                        }
                    }
                }
            }
            
            if(op==0)
            {
                Console.WriteLine("\nLogin failed...Please Try Again\n");
                Console.ReadKey();
                con.Close();
                return a;
            }
            else
            con.Close();
            return uname;

        }

        public void SignUp()
        {
            try
            {
                Console.Clear();
                SqlConnection con = new SqlConnection(cString);
                con.Open();
                Console.WriteLine("\n==========Welcome===========\n");
                Console.WriteLine("Enter your First name : ");
                trainer.firstName = Console.ReadLine();
                Console.WriteLine("Enter your Last name : ");
                trainer.lastName = Console.ReadLine();
                gendercheck:
                Console.WriteLine("Enter your Gender : "); 
                trainer.Gender = Console.ReadLine();
                string pat = @"^((M|m)ale)|((F|f)emale)$";
                var isGenderCheck=Regex.IsMatch(trainer.Gender, pat);
                if (isGenderCheck)
                {
                emailcheck:
                    Console.WriteLine("Enter your Email : ");
                    trainer.Email = Console.ReadLine();
                    string pattern1 = @"^(([a-zA-Z]+)(\d+)?)@([a-zA-Z]+).([a-zA-Z]{2,4})$";
                    var isEmailMatch = Regex.IsMatch(trainer.Email, pattern1);
                    if (isEmailMatch)
                    {
                        Console.WriteLine("Enter your Password : ");
                        trainer.Password = string.Empty;
                        ConsoleKey key;
                        do
                        {
                            var keyInfo = Console.ReadKey(intercept: true);
                            key = keyInfo.Key;

                            if (key == ConsoleKey.Backspace && trainer.Password.Length > 0)
                            {
                                Console.Write("\b \b");
                                trainer.Password = trainer.Password[0..^1];
                            }
                            else if (!char.IsControl(keyInfo.KeyChar))
                            {
                                Console.Write("*");
                                trainer.Password += keyInfo.KeyChar;
                            }
                        } while (key != ConsoleKey.Enter);
                    phonecheck:
                        Console.WriteLine("\nEnter your Phone Number : ");
                        trainer.Phone = Console.ReadLine();
                        string pattern = @"^[6-9]\d{9}$";
                        var isPhoneMatch = Regex.IsMatch(trainer.Phone, pattern);
                        if (isPhoneMatch)
                        {
                            Console.WriteLine("Enter your City : ");
                            trainer.City = Console.ReadLine();
                            Console.WriteLine("Enter your State : ");
                            trainer.State = Console.ReadLine();
                            Console.WriteLine("Enter your Country : ");
                            trainer.Country = Console.ReadLine();
                            Console.WriteLine("Please tell us something about yourself : ");
                            trainer.Aboutme = Console.ReadLine();

                            string query = $"insert into Trainer(firstName,lastName,Gender,Email,Password,Phone,City,State,Country,AboutMe) VALUES('{trainer.firstName}','{trainer.lastName}','{trainer.Gender}','{trainer.Email}','{trainer.Password}','{trainer.Phone}','{trainer.City}','{trainer.State}','{trainer.Country}','{trainer.Aboutme}')";
                            SqlCommand command1 = new SqlCommand(query, con);
                            command1.ExecuteNonQuery();
                            Console.WriteLine("\nSuccessfully Registered\nPlease Press any Key to Continue.");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine("\nPlease Enter 10 digit number (press enter to continue)");
                            Console.ReadKey();
                            goto phonecheck;
                        }
                    }
                    else
                    {
                        Console.WriteLine("\nEnter Correct Email Syntax (press enter to continue)");
                        Console.ReadKey();
                        goto emailcheck;
                    }
                }
                else
                {
                    Console.WriteLine("\nPlease enter either Male or Female Do not give values as single letter (press enter to continue)");
                    Console.ReadKey();
                    goto gendercheck;
                }
            }
                
            catch (Exception)
            {
                Console.WriteLine("\nEmail already Exist, Please SignIn (press any key to return Main Menu)");
                Console.ReadKey();
            }
        }

        public void UpdateTrainer(string s)
        {
            SqlConnection con = new SqlConnection(cString);
            con.Open();
            string uname = s;
            Console.WriteLine("You cannot Update Email Id Other details can be Update, Please enter Updated Details");
            Console.WriteLine("\nEnter your First Name : ");
            string fname=Console.ReadLine();
            Console.WriteLine("Enter your Last Name : ");
            string lname = Console.ReadLine();
            a:
            Console.WriteLine("Enter your Gender : ");
            string g = Console.ReadLine();
            string pat = @"^((M|m)ale)|((F|f)emale)$";
            var isGenderCheck = Regex.IsMatch(g, pat);
            if (isGenderCheck)
            {
                Console.WriteLine("Enter your updated Password : ");
                string pwd = string.Empty;
                ConsoleKey key;
                do
                {
                    var keyInfo = Console.ReadKey(intercept: true);
                    key = keyInfo.Key;

                    if (key == ConsoleKey.Backspace && pwd.Length > 0)
                    {
                        Console.Write("\b \b");
                        pwd = pwd[0..^1];
                    }
                    else if (!char.IsControl(keyInfo.KeyChar))
                    {
                        Console.Write("*");
                        pwd += keyInfo.KeyChar;
                    }
                } while (key != ConsoleKey.Enter);
                b:
                Console.WriteLine("\nEnter your Phone Number : ");
                string phone = Console.ReadLine();
                string pattern = @"^[6-9]\d{9}$";
                var isPhoneMatch = Regex.IsMatch(phone, pattern);
                if (isPhoneMatch)
                {
                    Console.WriteLine("Enter your City : ");
                    string city = Console.ReadLine();
                    Console.WriteLine("Enter your State : ");
                    string stat = Console.ReadLine();
                    Console.WriteLine("Enter your Country : ");
                    string cntry = Console.ReadLine();
                    Console.WriteLine("About you (Optional) : ");
                    string am = Console.ReadLine();
                    string query = $"update Trainer set firstName='{fname}',lastName='{lname}',Gender='{g}',Password='{pwd}',Phone='{phone}',City='{city}',State='{stat}',Country='{cntry}',AboutMe='{am}' where Email='{uname}'";
                    SqlCommand command3 = new SqlCommand(query, con);
                    command3.ExecuteNonQuery();
                    Console.WriteLine("\nSuccessfully Updated Press Enter to Continue...\n");
                    Console.ReadKey();
                    con.Close();
                }
                else
                {

                    Console.WriteLine("\nPlease Enter 10 digit number (press enter to continue)");
                    Console.ReadKey();
                    goto b;
                }
            }
            else
            {
                Console.WriteLine("\nPlease enter either Male or Female Do not give values as single letter (press enter to continue)");
                Console.ReadKey();
                goto a;
            }
        }

        public List<Trainer> DisplayTrainer(int s)
        {
            List<Trainer> edu = new List<Trainer>();
            using SqlConnection con = new SqlConnection(cString);
            con.Open();
            int ID = s;
            string query = $"Select * from Trainer where Trainer_Id={ID}";
            SqlCommand command2 = new SqlCommand(query, con);
            SqlDataReader sdr = command2.ExecuteReader();

            while (sdr.Read())
            {
                edu.Add(new Trainer()
                { 
                    firstName = sdr.GetString(1),
                    lastName = sdr.GetString(2),
                    Gender = sdr.GetString(3),
                    Email = sdr.GetString(4),
                    Password = sdr.GetString(5),
                    Phone=sdr.GetString(6),
                    City=sdr.GetString(7),
                    State=sdr.GetString(8),
                    Country=sdr.GetString(9),
                    Aboutme=sdr.GetString(10)

                }); ;
            }
            return edu;

        } 
        public int DeleteProfile(int s)
        {
            using SqlConnection con = new SqlConnection(cString);
            int Id = s;
            con.Open();
            Console.WriteLine("\nPlease Press [1] to Confirm Delete\tor\tPress [0] to go to Main Menu\n");
            int del = Convert.ToInt32(Console.ReadLine());
            if(del==1)
            {
                string query = $"delete from Trainer where Trainer_Id={Id}";
                SqlCommand command2 = new SqlCommand(query, con);
                command2.ExecuteNonQuery();
                Console.WriteLine("\nSuccessfully Deleted..!(Press any Key to Continue)\n");
                Console.ReadKey();
                con.Close();
            }
            else
            {
                Console.WriteLine("\nLoading back to Main Menu.......\n");
                Console.ReadKey();
            }
            return del;
        }
    }
}

