using System;
using System.Data.SqlClient;
using System.Text.RegularExpressions;


namespace ProjectData
{
    public class WorkExperienceSql:IOperations3
    {
        private readonly string cString;
        public WorkExperienceSql(string cString)
        {
            this.cString = cString;
        }
        public List<WorkExperience> DisplayWorkExperience(int s)
        {
            List<WorkExperience> edu = new List<WorkExperience>();
            using SqlConnection con = new SqlConnection(cString);
            con.Open();
            int ID = s;
            string query = $"Select Company_Name,Role,StartDate,EndDate,Description from WorkExperience where Trainer_Id={ID}";
            SqlCommand command2 = new SqlCommand(query, con);
            SqlDataReader sdr = command2.ExecuteReader();

            while (sdr.Read())
            {
                edu.Add(new WorkExperience()
                {
                    Company_Name = sdr.GetString(0),
                    Role = sdr.GetString(1),
                    StartDate = sdr.GetString(2),
                    EndDate = sdr.GetString(3),
                    Description = sdr.GetString(4)
                }); ;
            }
            return edu;
        }

        public void AddWorkExperience(int ID)
        {
            string stdt, eddt;
            using SqlConnection con = new SqlConnection(cString);
            int Id = ID;
            con.Open();
            Console.WriteLine("Enter your Company Name: ");
            string CName = Console.ReadLine();
            Console.WriteLine("Enter Role : ");
            string Role = Console.ReadLine();
            startdatecheck:
            Console.WriteLine("Enter Start Date(MM/YYYY) (Format should be followed)");
            string sd = Console.ReadLine();
            string pattern = @"^((0[1-9])|(1[0-2]))\/(\d{4})$";
            var isPhoneMatch = Regex.IsMatch(sd, pattern);
            if (isPhoneMatch)
                stdt = sd;
            else
                goto startdatecheck;
            edcheck:
            Console.WriteLine("Enter End Date(MM/YYYY) (Format should be followed)");
            string ed = Console.ReadLine();
            string pattern1 = @"^((0[1-9])|(1[0-2]))\/(\d{4})$";
            var isedmatch = Regex.IsMatch(ed, pattern);
            if (isedmatch)
                eddt = ed;
            else
                goto edcheck;
            Console.WriteLine("Decription (Optional): ");
            string d = Console.ReadLine();
            string query2 = $"insert into WorkExperience(Trainer_ID,Company_Name,Role,StartDate,EndDate,Description) values({Id},'{CName}','{Role}','{sd}','{eddt}','{d}')";
            SqlCommand command2 = new SqlCommand(query2, con);
            command2.ExecuteNonQuery();
            Console.WriteLine("\nWork Experience Added Successfully\n");
            con.Close();
        }

        public void DeleteWorkExperience(int ID)
        {

            using SqlConnection con = new SqlConnection(cString);
            int Id = ID;
            con.Open();
            Console.WriteLine("\nEnter The Company Name that you want to delete: ");
            string del = Console.ReadLine();
            string query = $"delete from WorkExperience where Company_Name='{del}' and Trainer_ID={Id}";
            SqlCommand command2 = new SqlCommand(query, con);
            command2.ExecuteNonQuery();
            Console.WriteLine("\nSuccessfully Deleted..!\n");
            con.Close();
        }

        public void UpdateWorkExperience(int ID)
        {
            string stdt, eddt;
            using SqlConnection con = new SqlConnection(cString);
            int Id = ID;
            con.Open();
            Console.WriteLine("\nPlease enter Company Name to update your details");
            string up = Console.ReadLine();
            Console.WriteLine("Please fill the Updated Details");
            Console.WriteLine("Enter your Company Name");
            string CName = Console.ReadLine();
            Console.WriteLine("Enter Role");
            string deg = Console.ReadLine();
        startdatecheck:
            Console.WriteLine("Enter Start Date(MM/YYYY)");
            string sd = Console.ReadLine();
            string pattern = @"^((0[1-9])|(1[0-2]))\/(\d{4})$";
            var isPhoneMatch = Regex.IsMatch(sd, pattern);
            if (isPhoneMatch)
                stdt = sd;
            else
                goto startdatecheck;
        edcheck:
            Console.WriteLine("Enter End Date(MM/YYYY)");
            string ed = Console.ReadLine();
            string pattern1 = @"^((0[1-9])|(1[0-2]))\/(\d{4})$";
            var isedmatch = Regex.IsMatch(ed, pattern);
            if (isedmatch)
                eddt = ed;
            else
                goto edcheck;
            Console.WriteLine("Description(Optional)");
            string descr = Console.ReadLine();

            string query = $"update WorkExperience set Company_Name='{CName}',Role='{deg}',StartDate='{stdt}',EndDate='{eddt}',Description='{descr}' where Company_Name='{up}' and Trainer_ID={Id}";
            SqlCommand command3 = new SqlCommand(query, con);
            command3.ExecuteNonQuery();
            Console.WriteLine("\nSuccessfully Updated\n");
            con.Close();
        }
    }
}
