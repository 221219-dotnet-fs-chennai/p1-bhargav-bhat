﻿
using Models;


namespace Business_Logic
{
    public interface ILogic
    {
        IEnumerable<Trainer> GetTrainers();
        IEnumerable<Skills> GetSkills();
        IEnumerable<WorkE> GetWorkExperiences();
        IEnumerable<Educate> GetEducations();
        IEnumerable<Additional> GetAdditionals();
        Trainer AddTrainers(Trainer trainer);

        IEnumerable<Trainer> FetchTrain(string email);
    }
}
