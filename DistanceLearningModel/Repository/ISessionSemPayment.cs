using DistanceLearningDomain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DistanceLearningDomain.Repository
{
    public interface ISessionSemPayment : IRepository<SessionSemPayment>
    {
        IEnumerable<SessionSemPayment> GetAllSessionSemPayment();
        bool ConfirmSessionSemPayment(string payDescription);
        IEnumerable<SessionSemPayment> GetAllSessionSemPayment(int payId);
        IEnumerable<SessionSemPayment> GetAllSessionSemPaymentBySession(int payId,int sessId);
        SessionSemPayment GetSesionPayment(int payId, int SessId);
        IEnumerable<SessionSemPayment> GetAllSessionPayment(int SessId);
        IEnumerable<SessionSemPayment> GetAllSessionPaymentInSession(int SessId);
        IEnumerable<SessionSemPayment> GetAllSessionPaymentSemester(int semId);
        SessionSemPayment GetSessionSemPayment(string paDescription);
        SessionSemPayment GetSessionSemPayment(int Id);
 
    }
}

