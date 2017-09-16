using DistanceLearningDomain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DistanceLearningDomain.Repository
{
    public interface ISessionSemRepository : IRepository<SessionSem>
    {
       
        bool ConfirmSessionSem(int SessId,int SemId);
        SessionSem GetActiveSessionSem();
        SessionSem GetSessionSem(int SessId, int SemId);
        IEnumerable<SessionSem> GetAllSessionInSession(int SessId);
        IEnumerable<SessionSem> GetAllSessionInSemester(int SemId);
        IEnumerable<SessionSem> GetAllOpenSessionInSession(int SessId);
        IEnumerable<SessionSem> GetAllOpenSessionInSemester(int SemId);

    }
}

