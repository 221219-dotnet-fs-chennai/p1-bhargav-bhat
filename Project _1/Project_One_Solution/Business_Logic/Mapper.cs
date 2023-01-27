using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic
{
    public class Mapper
    {
        public static Models.Trainer Map(Fluent_API.Entities.Trainer t)
        {
            return new Models.Trainer()
            {
                
                firstName = t.FirstName,
                lastName = t.LastName,
                Gender = t.Gender,
                Email = t.Email,
                Phone = t.Phone,
                City = t.City,
                State = t.State,
                Country = t.Country,
                Aboutme = t.AboutMe

            };
        }

        public static IEnumerable<Models.Trainer> Map(IEnumerable<Fluent_API.Entities.Trainer> trainers)
        {
            return trainers.Select(Map);
        }

        public static Models.Skills Map(Fluent_API.Entities.Skill s)
        {
            return new Models.Skills()
            {
                skillName = s.Skills
            };
        }

        public static IEnumerable<Models.Skills> Map(IEnumerable<Fluent_API.Entities.Skill> skills)
        {
            return skills.Select(Map);
        }
    }
}
