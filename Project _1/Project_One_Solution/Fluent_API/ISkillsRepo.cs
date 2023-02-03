using Fluent_API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fluent_API
{
    public interface ISkillsRepo
    {
        List<Skill> DisplaySkills(string email);
        Skill AddSkills( Skill skill);
        Skill DeleteSkill(int id,string name);

    }
}
