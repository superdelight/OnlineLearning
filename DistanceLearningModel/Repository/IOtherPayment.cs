using DistanceLearningDomain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DistanceLearningDomain.Repository
{
    public interface IOtherPayment : IRepository<OtherPayment>
    {
        IEnumerable<OtherPayment> GetAllOtherFee();
        bool ConfirmOtherFee(string payDescription);
        bool ConfirmOtherFee(int Id);
        OtherPayment GetOtherFee(string paDescription);
        OtherPayment GetOtherFee(int Id);
    }
}
