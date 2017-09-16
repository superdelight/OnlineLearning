using DistanceLearningDomain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DistanceLearningDomain.Repository
{
    public interface IPaymentItem : IRepository<PaymentItem>
    {
        bool ConfirmPaymentItem(int payId,int ItemId);
        PaymentItem GetPaymentItem(int payId, int ItemId);
        IEnumerable<PaymentItem> GetAllPaymentItem(int payId);
        IEnumerable<PaymentItem> GetAllPaymentItemByItem(int ItemID);
       
    }
}
