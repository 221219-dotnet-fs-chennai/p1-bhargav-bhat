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
      
        public int? Id { get; set; }
        public string? College_Uni { get; set; }
        public string? Degree { get; set; }
        public string? Start_Date { get; set; } = null!;
        public string? End_Date { get; set; } = null!;
        public string? Descriptions { get; set; }

        public override string ToString()
        {
            return $"College or University Name : {College_Uni}\nDegree : {Degree}\nStart Date : {Start_Date}\nEnd Date : {End_Date}\nDescription : {Descriptions} ";
        }
    }
}
