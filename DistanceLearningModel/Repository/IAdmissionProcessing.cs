using DistanceLearningDomain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DistanceLearningDomain.Repository
{
    public interface IAdmissionProcessing : IRepository<AdmissionProcessing>
    {
        bool ConfirmAdmission(string usr);
        bool ConfirmAdmission(int applicationId);  
        AdmissionProcessing GetAdmissionProcessing(string usr);
    }
}