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
        public int Id3 { get; set; }
        public int? TrainerId { get; set; }

        public string Company_Name { get; set; }

        public string Role { get; set; }

        public string StartDate { get; set; }

        public string EndDate { get; set; }

        public string Description { get; set; }

        public override string ToString()
        {
            return $"Company Name : {Company_Name}\nRole : {Role}\nStart Date : {StartDate}\nEnd Date : {EndDate}\nDiscription : {Description} ";
        }
    }
}
