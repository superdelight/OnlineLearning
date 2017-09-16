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
    public class AcceptanceRepository : Repository<DistanceLearningDomain.Model.AcceptancePayment, AcceptancePayment>, IAcceptance
    {
        private ElearningPayEntities Context;
        public AcceptanceRepository (ElearningPayEntities Context)
            :base(Context)
        {
            Mapper.CreateMap<DistanceLearningDomain.Model.AcceptancePayment, AcceptancePayment>();
            Mapper.CreateMap<AcceptancePayment, DistanceLearningDomain.Model.AcceptancePayment>();
            this.Context = Context;   
        }
        
        public IEnumerable<DistanceLearningDomain.Model.AcceptancePayment> GetAllAcceptanceFee()
        {
            var rawApplicant = (from c in Context.Payments.OfType<AcceptancePayment>() select c).ToList();
            var refinedApplicant = Mapper.Map<List<AcceptancePayment>, List<DistanceLearningDomain.Model.AcceptancePayment>>(rawApplicant);
            return refinedApplicant;
        }

        public bool ConfirmAcceptance(string payDescription)
        {
            var rawApplicant = (from c in Context.Payments where c.PaymentDescription.ToLower() == payDescription.ToLower() && c is AcceptancePayment select c).Any();
            return rawApplicant;
        }

        public bool ConfirmAcceptance(int Id)
        {
            var rawApplicant = (from c in Context.Payments where c.Id == Id && c is AcceptancePayment select c).Any();
            return rawApplicant;
        }

        public DistanceLearningDomain.Model.AcceptancePayment GetAcceptanceFee(string paDescription)
        {
            var rawApplicant = (from c in Context.Payments.OfType<AcceptancePayment>() where c.AcceptDescription.ToLower()==paDescription.ToLower() select c).FirstOrDefault();
            var refinedApplicant = Mapper.Map<AcceptancePayment, DistanceLearningDomain.Model.AcceptancePayment>(rawApplicant);
            return refinedApplicant;
        }
        public DistanceLearningDomain.Model.AcceptancePayment GetAcceptanceFee(int Id)
        {
            var rawApplicant = (from c in Context.Payments.OfType<AcceptancePayment>() where c.Id==Id select c).FirstOrDefault();
            var refinedApplicant = Mapper.Map<AcceptancePayment, DistanceLearningDomain.Model.AcceptancePayment>(rawApplicant);
            return refinedApplicant;
        }
     
    }
}
