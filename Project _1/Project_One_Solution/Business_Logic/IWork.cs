using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic
{
    public interface IWork
    {
        IEnumerable<WorkE> GetWork(string email);
        WorkE UpdateWorkExp(int s, string email, string name, WorkE work);

        WorkE AddWork(int s, WorkE work);

        WorkE DeleteWork(int s, string name);
    }
}