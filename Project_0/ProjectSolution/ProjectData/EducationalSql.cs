using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ProjectData
{
    public class EducationalSql:IOperation2
    {
        private readonly string cString;
        public EducationalSql(string cString)
        {
            this.cString = cString;
        }

        public List<Educational> DisplayEducations(int s)
        {
            List<Educational> edu = new List<Educational>();
            using SqlConnection con = new SqlConnection(cString);
            con.Open();
            int ID = s;
            string query = $"Select College_University,Degree,StartDate,EndDate,Description from Educations where Trainer_Id={ID}";
            SqlCommand command2 = new SqlCommand(query, con);
            SqlDataReader sdr = command2.ExecuteReader();

            while (sdr.Read())
            {
                edu.Add(new Educational()
                {
                    College_Uni = sdr.GetString(0),
                    Degree= sdr.GetString(1),
                    Start_Date= sdr.GetString(2),
                    End_Date= sdr.GetString(3),
                    Descriptions= sdr.GetString(4)
                }); ;
            }

            return edu;
        }

        public void AddEducation(int ID)
        {
            using SqlConnection con = new SqlConnection(cString);
            int Id = ID;
            string stdt, eddt;
            con.Open();
            Console.WriteLine("Enter your College or University Name: ");
            string College = Console.ReadLine();
            Console.WriteLine("Enter Degree : ");
            string Degree = Console.ReadLine();
            startdatecheck:
            Console.WriteLine("Enter Start Date(MM/YYYY) (Format should be followed): ");
            string sd = Console.ReadLine();
            string pattern = @"^((0[1-9])|(1[0-2]))\/(\d{4})$";
            var isPhoneMatch = Regex.IsMatch(sd,pattern);
            if (isPhoneMatch)
                stdt = sd;
            else
                goto startdatecheck;
            edcheck:
            Console.WriteLine("Enter End Date(MM/YYYY)(Format should be followed): ");
            string ed = Console.ReadLine();
            string pattern1 = @"^((0[1-9])|(1[0-2]))\/(\d{4})$";
            var isedmatch= Regex.IsMatch(ed, pattern);
            if (isedmatch)
                eddt = ed;
            else
                goto edcheck;
            Console.WriteLine("Decription (Optional): ");
            string d = Console.ReadLine();
            string query2 = $"insert into Educations(Trainer_ID,College_University,Degree,StartDate,EndDate,Description) values({Id},'{College}','{Degree}','{sd}','{eddt}','{d}')";
            SqlCommand command2 = new SqlCommand(query2, con);
            command2.ExecuteNonQuery();
            Console.WriteLine("\nEducation Added Successfully\n");
            con.Close();
         }
                
        public void DeleteEducation(int ID)
        {

            using SqlConnection con = new SqlConnection(cString);
            int Id = ID;
            con.Open();
            Console.WriteLine("Enter The College Name/University that you want to delete: ");
            string del = Console.ReadLine();
            string query = $"delete from Educations where College_University='{del}' and Trainer_ID= {Id}";
            SqlCommand command2 = new SqlCommand(query, con);
            command2.ExecuteNonQuery();
            Console.WriteLine("\nSuccessfully Deleted..!\n");
            con.Close();
        }

        public void UpdateEducation(int ID)
        {
            string stdt, eddt;
            using SqlConnection con = new SqlConnection(cString);
            int Id = ID;
            con.Open();
            Console.WriteLine("Please enter College name to update your details");
            string up=Console.ReadLine();
            Console.WriteLine("Please fill the Updated Details");
            Console.WriteLine("Enter your College Name");
            string CName = Console.ReadLine();
            Console.WriteLine("Enter your Degree");
            string deg = Console.ReadLine();
            startdatecheck:
            Console.WriteLine("Enter Start Date(MM/YYYY) (Format should be followed):");
            string sd = Console.ReadLine();
            string pattern = @"^((0[1-9])|(1[0-2]))\/(\d{4})$";
            var isPhoneMatch = Regex.IsMatch(sd, pattern);
            if (isPhoneMatch)
                stdt = sd;
            else
                goto startdatecheck;
            edcheck:
            Console.WriteLine("Enter End Date(MM/YYYY) (Format should be followed):");
            string ed = Console.ReadLine();
            string pattern1 = @"^((0[1-9])|(1[0-2]))\/(\d{4})$";
            var isedmatch = Regex.IsMatch(ed, pattern);
            if (isedmatch)
                eddt = ed;
            else
                goto edcheck;
            Console.WriteLine("Description(Optional)");
            string descr = Console.ReadLine();

            string query = $"update Educations set College_University='{CName}',Degree='{deg}',StartDate='{sd}',EndDate='{ed}',Description='{descr}' where College_University='{up}' and Trainer_ID={Id}";
            SqlCommand command3 = new SqlCommand(query,con);
            command3.ExecuteNonQuery();
            Console.WriteLine("\nSuccessfully Updated\n");
            con.Close();
        }
    }
}
