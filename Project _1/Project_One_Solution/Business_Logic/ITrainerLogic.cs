

using Models;

namespace Business_Logic
{
    public interface ITrainerLogic
    {
        IEnumerable<Trainer> GetTrainers();
        Trainer AddTrainers(Trainer trainer);

        Trainer UpdateTrainer(string email,Trainer trainer);

        Trainer RemoveTrainers(string email);
        Trainer FetchTrainer(string email,string password);

    }
}
