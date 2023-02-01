
using Fluent_API.Entities;

namespace Fluent_API
{
    public interface ITrainerRepo<T>
    {
        List<T> DisplayTrainer();

        Trainer AddTrainer(Trainer trainer);

        //List<T> FetchTrainer(string email);

        T UpdateTrainer(T trainer);

        T DeleteTrainer(string email);
    }
}
