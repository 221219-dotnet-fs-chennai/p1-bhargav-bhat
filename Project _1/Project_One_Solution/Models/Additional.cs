using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Additional
    {
        public Additional()
        {
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Achievments { get; set; }
        public string Publications { get; set; }
        public string Volunteering_Experiences { get; set; }
        public override string ToString()
        {
            return $"Title : {Title}\nAchievements : {Achievments}\nPublications : {Publications}\nVolunteering Experiences : {Volunteering_Experiences}";
        }
    }
}
