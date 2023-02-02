using Fluent_API.Entities;
using Models;


namespace Business_Logic
{
    public interface ISkills
    {
        IEnumerable<Skills> GetSkills(string email);
        Skills AddSkill(int s,Skills skill);

        int IdFetcher(string email);

        Skills DeleteSl(int s);
    }
}
