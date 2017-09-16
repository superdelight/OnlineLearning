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
    public class PaymentRepository : Repository<DistanceLearningDomain.Model.Payment,Payment>, IPayment
    {
        private ElearningPayEntities Context;
        public PaymentRepository(ElearningPayEntities Context)
            :base(Context)
        {
            Mapper.CreateMap<DistanceLearningDomain.Model.Payment, Payment>();
            Mapper.CreateMap<Payment, DistanceLearningDomain.Model.Payment>();
            this.Context = Context;   
        }
        public bool ConfirmPayment(string payDescription)
        {
            var rawApplicant = (from c in Context.Payments where c.PaymentDescription.ToLower() == payDescription.ToLower() select c).Any();
            return rawApplicant;
        }
        public override IEnumerable<DistanceLearningDomain.Model.Payment> GetAll()
        {
            var rawApplicant = (from c in Context.Payments select c).ToList();
            var refinedApplicant = rawApplicant.Select(c => new DistanceLearningDomain.Model.Payment() { Id = c.Id, PaymentDescription = c.PaymentDescription, DateCreated = c.DateCreated }).ToList();
            return refinedApplicant;
        }
        public DistanceLearningDomain.Model.Payment GetPayment(string paDescription)
        {
            var rawApplicant = (from c in Context.Payments where c.PaymentDescription.ToLower() == paDescription.ToLower() select c).FirstOrDefault();
            var refinedApplicant = Mapper.Map<Payment, DistanceLearningDomain.Model.Payment>(rawApplicant);
            return refinedApplicant;
        }
    }
}
