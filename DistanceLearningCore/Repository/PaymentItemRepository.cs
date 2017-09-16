using AutoMapper;
using DistanceLearningCore.Model.Payment;
using DistanceLearningCore.Model.StaffModel;
using DistanceLearningDomain.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace DistanceLearningCore.Repository
{
    public class PaymentItemRepository : Repository<DistanceLearningDomain.Model.PaymentItem,PaymentItem>, IPaymentItem
    {
        private ElearningPayEntities Context;
        public PaymentItemRepository(ElearningPayEntities Context)
            :base(Context)
        {
            Mapper.CreateMap<DistanceLearningDomain.Model.PaymentItem, PaymentItem>();
            Mapper.CreateMap<PaymentItem, DistanceLearningDomain.Model.PaymentItem>();
            this.Context = Context;   
        }
 
        public bool ConfirmPaymentItem(int payId, int ItemId)
        {
            var rawApplicant = (from c in Context.PaymentItems where c.PayId==payId && c.ItemId==ItemId select c).Any();
            return rawApplicant;
        }

        public DistanceLearningDomain.Model.PaymentItem GetPaymentItem(int payId, int ItemId)
        {
            var rawApplicant = (from c in Context.PaymentItems where c.PayId == payId && c.ItemId==ItemId select c).FirstOrDefault();
            var refinedApplicant = Mapper.Map<PaymentItem, DistanceLearningDomain.Model.PaymentItem>(rawApplicant);
            return refinedApplicant;
        }

        public IEnumerable<DistanceLearningDomain.Model.PaymentItem> GetAllPaymentItem(int payId)
        {
            var rawApplicant = (from c in Context.PaymentItems where c.PayId == payId select c).ToList();
            var refinedApplicant = Mapper.Map<List<PaymentItem>,  List<DistanceLearningDomain.Model.PaymentItem>>(rawApplicant);
            return refinedApplicant;
        }

        public IEnumerable<DistanceLearningDomain.Model.PaymentItem> GetAllPaymentItemByItem(int ItemID)
        {
            var rawApplicant = (from c in Context.PaymentItems where c.ItemId == ItemID select c).ToList();
            var refinedApplicant = Mapper.Map<List<PaymentItem>, List<DistanceLearningDomain.Model.PaymentItem>>(rawApplicant);
            return refinedApplicant;
        }
    }
}
