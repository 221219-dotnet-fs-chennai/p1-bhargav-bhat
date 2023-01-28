using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public interface ITrainerRepo<T>
    {
        List<T> DisplayTrainer();

        //void AddTrainer(Trainer trainer);
        Trainer AddTrainer(Trainer trainer);

        List<T> FetchTrainer(string email);
    }
}
