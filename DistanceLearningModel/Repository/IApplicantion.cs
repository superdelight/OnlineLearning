using DistanceLearningDomain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DistanceLearningDomain.Repository
{
    public interface IApplicantion : IRepository<Application>
    {
        Application GetSingleApplication(int appId, int AdmissionProgId);
        Application GetSingleApplication(string usr);
        bool CreateNewApp(Application app);
        bool ConfirmApplication(int appId, int AdmissionProgId);
        IEnumerable<Application> GetAllApplication(int admissionProgr);
       
    }
}

