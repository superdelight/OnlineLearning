using AutoMapper;
using DistanceLearningCore.Model.Payment;
using DistanceLearningDomain.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace DistanceLearningCore.Repository
{
    public class ApplicantPaymentRepository : Repository<DistanceLearningDomain.Model.ApplicantPayment, ApplicantPayment>, IApplicantPayment
    {
        private ElearningPayEntities Context;
        public ApplicantPaymentRepository(ElearningPayEntities Context)
            :base(Context)
        {
            Mapper.CreateMap<DistanceLearningDomain.Model.ApplicantPayment, ApplicantPayment>();
            Mapper.CreateMap<ApplicantPayment, DistanceLearningDomain.Model.ApplicantPayment>();
            this.Context = Context;   
        }
     
    

        public IEnumerable<DistanceLearningDomain.Model.ApplicantPayment> GetAllApplicantPayment()
        {
            var rawApplicant = (from c in Context.Payments.OfType<ApplicantPayment>() select c).ToList();
            var refinedApplicant = Mapper.Map<List<ApplicantPayment>, List<DistanceLearningDomain.Model.ApplicantPayment>>(rawApplicant);
            return refinedApplicant;
        }

        public bool ConfirmApplicant(string payDescription)
        {
            var rawApplicant = (from c in Context.Payments where c.PaymentDescription.ToLower() == payDescription.ToLower() && c is ApplicantPayment select c).Any();
            return rawApplicant;
        }

        public bool ConfirmApplicantPayment(int Id)
        {
            var rawApplicant = (from c in Context.Payments where c.Id == Id && c is ApplicantPayment select c).Any();
            return rawApplicant;
        }

        public DistanceLearningDomain.Model.ApplicantPayment GetApplicantPayment(string paDescription)
        {
            var rawApplicant = (from c in Context.Payments.OfType<ApplicantPayment>() where c.PaymentDescription.ToLower() == paDescription.ToLower() select c).FirstOrDefault();
            var refinedApplicant = Mapper.Map<ApplicantPayment, DistanceLearningDomain.Model.ApplicantPayment>(rawApplicant);
            return refinedApplicant;
        }

        public DistanceLearningDomain.Model.ApplicantPayment GetApplicantPayment(int Id)
        {
            var rawApplicant = (from c in Context.Payments.OfType<ApplicantPayment>() where c.Id == Id select c).FirstOrDefault();
            var refinedApplicant = Mapper.Map<ApplicantPayment, DistanceLearningDomain.Model.ApplicantPayment>(rawApplicant);
            return refinedApplicant;
        }
    }
}
