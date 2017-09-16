using DistanceLearningDomain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DistanceLearningDomain.Repository
{
    public interface ISessionPayment : IRepository<SessionPayment>
    {
        IEnumerable<SessionPayment> GetAllSessionPayment();
        IEnumerable<SessionPayment> GetAllSessionPaymentFromPayment(int payId);
       SessionPayment GetSesionPayment(int payId,int SessId);
        bool ConfirmSessionPayment(string payDescription);
        IEnumerable<SessionPayment> GetAllSessionPayment(int SessId);
        SessionPayment GetSessionPayment(int Id);
        SessionPayment GetSessionPayment(string payDescription);
    }
}

