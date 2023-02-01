

using Models;

namespace Business_Logic
{
    public interface ILogic
    {
        IEnumerable<Trainer> GetTrainers();
        Trainer AddTrainers(Trainer trainer);

        Trainer UpdateTrainer(string email,Trainer trainer);

        Trainer RemoveTrainers(string email);

    }
}
