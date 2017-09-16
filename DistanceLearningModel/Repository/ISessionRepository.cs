using DistanceLearningDomain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DistanceLearningDomain.Repository
{
    public interface ISessionRepository : IRepository<Session>
    {
        Session GetCurrentSesion();
        bool ConfirmSession(string Session);
        IEnumerable<Session> GetAllClosedSession();
    }
}

