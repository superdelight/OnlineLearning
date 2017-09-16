using DistanceLearningDomain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DistanceLearningDomain.Repository
{
    public interface IAdmissionRepository : IRepository<Admission>
    {
        bool ConfirmAdmission(string admissionDescription);
        Admission GetAdmissionByProgramme(int admissionProgId);
        IEnumerable<Admission> GetAllAdmissionInSession(int sessId);
        IEnumerable<Admission> GetAllActiveAdmissionInSession(int sessId);
        IEnumerable<Admission> GetAllClosedAdmission();
        IEnumerable<Admission> GetAllOpenAdmission();
      
    }
}

