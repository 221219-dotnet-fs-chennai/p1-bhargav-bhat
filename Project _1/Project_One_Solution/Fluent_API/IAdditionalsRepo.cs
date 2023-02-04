using Fluent_API.Entities;

namespace Fluent_API
{
    public interface IAdditionalsRepo
    {
        List<AdditionalDetail> DisplayAdditional(string email);
        AdditionalDetail AddAdditional(AdditionalDetail ad);
        AdditionalDetail UpdateAdditional(AdditionalDetail ad);
        AdditionalDetail DeleteAdditional(int id,string email);

    }
}
