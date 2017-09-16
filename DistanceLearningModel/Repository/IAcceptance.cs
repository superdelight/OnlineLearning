using DistanceLearningDomain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DistanceLearningDomain.Repository
{
    public interface IAcceptance : IRepository<AcceptancePayment>
    {
        IEnumerable<AcceptancePayment> GetAllAcceptanceFee();
        bool ConfirmAcceptance(string payDescription);
        bool ConfirmAcceptance(int Id);
        AcceptancePayment GetAcceptanceFee(string paDescription);
        AcceptancePayment GetAcceptanceFee(int Id);

    }
}

