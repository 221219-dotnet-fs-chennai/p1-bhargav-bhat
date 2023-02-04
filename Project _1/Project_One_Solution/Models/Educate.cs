using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Models
{
    public class Educate
    {
        public Educate()
        {
        }
        public int Id { get; set; }
        public string College_Uni { get; set; }
        public string Degree { get; set; }
        public string startdate;
        public string Start_Date 
        {
            get
            {
                return startdate;
            }
            set
            {
                string pattern = @"^((0[1-9])|(1[0-2]))\/(\d{4})$";
                var IsDateCheck = Regex.IsMatch(value, pattern);
                if (IsDateCheck)
                {
                    startdate = value;
                }
                else
                {
                    throw new InvalidDataException("Invalid Data, Please try again");
                }
            }
        }
        public string enddate;
        public string End_Date 
        {
            get
            {
                return enddate;
            }
            set
            {
                string pattern = @"^((0[1-9])|(1[0-2]))\/(\d{4})$";
                var IsDateCheck = Regex.IsMatch(value, pattern);
                if (IsDateCheck)
                {
                    startdate = value;
                }
                else
                {
                    throw new InvalidDataException("Invalid Data, Please try again");
                }
            }
        }
        public string Descriptions { get; set; }

        public override string ToString()
        {
            return $"College or University Name : {College_Uni}\nDegree : {Degree}\nStart Date : {Start_Date}\nEnd Date : {End_Date}\nDescription : {Descriptions} ";
        }
    }
}
