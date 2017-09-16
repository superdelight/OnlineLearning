using DistanceLearningDomain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DistanceLearningDomain.Repository
{
    public interface IStepRepository : IRepository<Step>
    {
       
        bool ConfirmStep(string detail);
        Step GetStep(string detail);
        Step GetStepByForce(string detail);
        IEnumerable<Step> GetAllSteps(int appId);

    }
}

