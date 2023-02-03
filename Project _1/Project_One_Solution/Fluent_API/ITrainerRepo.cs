
using Fluent_API.Entities;

namespace Fluent_API
{
    public interface ITrainerRepo
    {
        List<Trainer> DisplayTrainer();

        Trainer AddTrainer(Trainer trainer);

        //List<T> FetchTrainer(string email);

        Trainer UpdateTrainer(Trainer trainer);

        Trainer DeleteTrainer(string email);

        int IdFetcher(string email);
    }
}
