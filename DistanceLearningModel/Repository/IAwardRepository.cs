using DistanceLearningDomain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DistanceLearningDomain.Repository
{
    public interface IAwardRepository : IRepository<Award>
    {
        IEnumerable<Award> GetAllAwardInDepartment(int deptId);
        bool ConfirmAwardByAcronyms(string acronyms);
            bool ConfirmAwardByDescription(string description);
            Award GetAwardByMatricNo(string MatNo);
          Award GetAwardByApplicant(string usr);
          string  GetAwardApplicantAwardDescription(string usr);

    }
}

