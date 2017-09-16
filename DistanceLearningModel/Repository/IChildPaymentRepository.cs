using DistanceLearningDomain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DistanceLearningDomain.Repository
{
    public interface IChildPaymentRepository : IRepository<ChildPayment>
    {
       
        IEnumerable<ChildPayment> GetAllChildPayment();
        bool ConfirmChildPayment(string payDescription);
        bool ConfirmChildPayment(int Id);
        ChildPayment GetChildPayment(string paDescription);
        ChildPayment GetChildPayment(int Id);
    }
}

