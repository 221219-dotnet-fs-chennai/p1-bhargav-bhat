using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Models
{
    public class WorkE
    {
        public WorkE()
        {
        }
        public int Id { get; set; }
        public string Company_Name { get; set; }
        public string Role { get; set; }

        public string startdate;
        public string StartDate 
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
        public string EndDate 
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
                    enddate = value;
                }
                else
                {
                    throw new InvalidDataException("Invalid Data, Please try again");
                }
            }
        }
        public string Description { get; set; }

        public override string ToString()
        {
            return $"Company Name : {Company_Name}\nRole : {Role}\nStart Date : {StartDate}\nEnd Date : {EndDate}\nDiscription : {Description} ";
        }
    }
}
