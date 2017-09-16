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
    public class ChildPayRepository : Repository<DistanceLearningDomain.Model.ChildPayment,ChildPayment>, IChildPaymentRepository
    {
        private ElearningPayEntities Context;
        public ChildPayRepository(ElearningPayEntities Context)
            :base(Context)
        {
            Mapper.CreateMap<DistanceLearningDomain.Model.ChildPayment, ChildPayment>();
            Mapper.CreateMap<ChildPayment, DistanceLearningDomain.Model.ChildPayment>();
            this.Context = Context;   
        }
        public IEnumerable<DistanceLearningDomain.Model.ChildPayment> GetAllChildPayment()
        {
            var rawApplicant = (from c in Context.Payments.OfType<ChildPayment>() select c).ToList();
           var refinedApplicant = Mapper.Map<List<ChildPayment>, List<DistanceLearningDomain.Model.ChildPayment>>(rawApplicant);
            return refinedApplicant;
        }

        public bool ConfirmChildPayment(string payDescription)
        {
            var rawApplicant = (from c in Context.Payments where c.PaymentDescription.ToLower() == payDescription.ToLower() && c is ChildPayment select c).Any();
            return rawApplicant;
        }

        public bool ConfirmChildPayment(int Id)
        {
            var rawApplicant = (from c in Context.Payments where c.Id == Id && c is ChildPayment select c).Any();
            return rawApplicant;
        }

        public DistanceLearningDomain.Model.ChildPayment GetChildPayment(string paDescription)
        {
            var rawApplicant = (from c in Context.Payments.OfType<ChildPayment>() where c.PayDescription.ToLower() == paDescription.ToLower() select c).FirstOrDefault();
            var refinedApplicant = Mapper.Map<ChildPayment, DistanceLearningDomain.Model.ChildPayment>(rawApplicant);
            return refinedApplicant;
        }

        public DistanceLearningDomain.Model.ChildPayment GetChildPayment(int Id)
        {
            var rawApplicant = (from c in Context.Payments.OfType<ChildPayment>() where c.Id == Id select c).FirstOrDefault();
            var refinedApplicant = Mapper.Map<ChildPayment, DistanceLearningDomain.Model.ChildPayment>(rawApplicant);
            return refinedApplicant;
        }
    }
}
