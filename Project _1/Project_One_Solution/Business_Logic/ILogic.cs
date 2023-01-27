
using Models;


namespace Business_Logic
{
    public interface ILogic
    {
        IEnumerable<Trainer> GetTrainers();
        IEnumerable<Skills> GetSkills();
        IEnumerable<WorkExperience> GetWorkExperiences();
    }
}
