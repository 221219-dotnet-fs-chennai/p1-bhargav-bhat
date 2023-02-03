using Fluent_API.Entities;
using Models;


namespace Business_Logic
{
    public interface ISkills
    {
        IEnumerable<Skills> GetSkills(string email);
        Skills AddSkill(int s, string name);

        Skills DeleteSl(int s,string sname);
    }
}
