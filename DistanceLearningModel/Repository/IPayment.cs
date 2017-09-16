using DistanceLearningDomain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DistanceLearningDomain.Repository
{
    public interface IPayment : IRepository<Payment>
    {
        bool ConfirmPayment(string payDescription);
        Payment GetPayment(string paDescription);
       
    }
}
