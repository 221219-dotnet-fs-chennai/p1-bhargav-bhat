using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectData
{
    public interface IRepo1
    {
        //Trainer Add(Trainer trainer);
        //Trainer GetAllTrainers();
        string SignIn();
        void SignUp();

        void UpdateTrainer(string s);
        List<Trainer> DisplayTrainer(int s);
    }
}
