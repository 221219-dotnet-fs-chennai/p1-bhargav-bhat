using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fluent_API.Entities
{
    public class EFAdditional : IAdditionals<AdditionalDetail>
    {
        TrainerDatabaseProjectContext context = new TrainerDatabaseProjectContext();

        public List<AdditionalDetail> DisplayAdditional()
        {
            return context.AdditionalDetails.ToList();
        }
    }
}
