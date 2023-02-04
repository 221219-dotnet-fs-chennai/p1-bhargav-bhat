
using Fluent_API.Entities;
using Models;


namespace Business_Logic
{
    public interface IEducationLogic
    {
        IEnumerable<Educate> GetEducation(string email);
        Educate UpdateEdu(int s,string email,string name,Educate educate);

        Educate AddEducation(int s,Educate educate);

        Educate DeleteEducation(int s,string name);

    }
}
