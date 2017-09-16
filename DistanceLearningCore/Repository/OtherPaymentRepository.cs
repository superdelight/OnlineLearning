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
    public class OtherPaymentRepository : Repository<DistanceLearningDomain.Model.OtherPayment,OtherPayment>, IOtherPayment
    {
        private ElearningPayEntities Context;
        public OtherPaymentRepository(ElearningPayEntities Context)
            :base(Context)
        {
            Mapper.CreateMap<DistanceLearningDomain.Model.OtherPayment, OtherPayment>();
            Mapper.CreateMap<OtherPayment, DistanceLearningDomain.Model.OtherPayment>();
            this.Context = Context;   
        }
        public IEnumerable<DistanceLearningDomain.Model.OtherPayment> GetAllOtherFee()
        {
            var rawApplicant = (from c in Context.Payments.OfType<OtherPayment>() select c).ToList();
            var refinedApplicant = Mapper.Map<List<OtherPayment>, List<DistanceLearningDomain.Model.OtherPayment>>(rawApplicant);
            return refinedApplicant;
        }

        public bool ConfirmOtherFee(string payDescription)
        {
            var rawApplicant = (from c in Context.Payments where c.PaymentDescription.ToLower() == payDescription.ToLower() && c is OtherPayment select c).Any();
            return rawApplicant;
        }

        public bool ConfirmOtherFee(int Id)
        {
            var rawApplicant = (from c in Context.Payments where c.Id == Id && c is OtherPayment select c).Any();
            return rawApplicant;
        }

        public DistanceLearningDomain.Model.OtherPayment GetOtherFee(string paDescription)
        {
            var rawApplicant = (from c in Context.Payments.OfType<OtherPayment>() where c.PayDescription.ToLower() == paDescription.ToLower() select c).FirstOrDefault();
            var refinedApplicant = Mapper.Map<OtherPayment, DistanceLearningDomain.Model.OtherPayment>(rawApplicant);
            return refinedApplicant;
        }

        public DistanceLearningDomain.Model.OtherPayment GetOtherFee(int Id)
        {
            var rawApplicant = (from c in Context.Payments.OfType<OtherPayment>() where c.Id== Id select c).FirstOrDefault();
            var refinedApplicant = Mapper.Map<OtherPayment, DistanceLearningDomain.Model.OtherPayment>(rawApplicant);
            return refinedApplicant;
        }         
    }
}
