using DistanceLearningDomain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DistanceLearningDomain.Repository
{
    public interface IApplicantProgress : IRepository<ApplicantProgress>
    {
        ApplicantProgress GetApplicantProgress(int stepId, int appId);
        bool ConfirmApplicantProgress(int stepId, int appId);
       
    }
}

