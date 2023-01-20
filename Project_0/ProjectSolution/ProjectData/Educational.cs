using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectData
{
    public class Educational
    {
        public Educational() 
        {
        }
        public int Id { get; set; }
        public string College_Uni { get; set; }
        public string Degree { get; set; }
        public string Start_Date { get; set; }
        public string End_Date { get; set;}
        public string Descriptions { get; set; }

        public override string ToString()
        {
            return $"College or University Name : {College_Uni}\nDegree : {Degree}\nStart Date : {Start_Date}\nEnd Date : {End_Date}\nDescription : {Descriptions} ";
        }
    }
}
