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
    public class SessionPaymentRepository : Repository<DistanceLearningDomain.Model.SessionPayment,SessionPayment>, ISessionPayment
    {
        private ElearningPayEntities Context;
        public SessionPaymentRepository(ElearningPayEntities Context)
            :base(Context)
        {
            Mapper.CreateMap<DistanceLearningDomain.Model.SessionPayment, SessionPayment>();
            Mapper.CreateMap<SessionPayment, DistanceLearningDomain.Model.SessionPayment>();
            this.Context = Context;   
        }
        public IEnumerable<DistanceLearningDomain.Model.SessionPayment> GetAllSessionPayment()
        {
            var rawApplicant = (from c in Context.PayCategories.OfType<SessionPayment>() select c).ToList();
            var refinedApplicant = Mapper.Map<IEnumerable<SessionPayment>, IEnumerable<DistanceLearningDomain.Model.SessionPayment>>(rawApplicant);
            return refinedApplicant;
        }

        public bool ConfirmSessionPayment(string payDescription)
        {
            var rawApplicant = (from c in Context.PayCategories where c is SessionPayment && c.Description.ToLower() == payDescription.ToLower() select c).Any();
            return rawApplicant;
        }
        public IEnumerable<DistanceLearningDomain.Model.SessionPayment> GetAllSessionPayment(int SessId)
        {
            var rawApplicant = (from c in Context.PayCategories.OfType<SessionPayment>() where c.SessId==SessId select c).ToList();
            var refinedApplicant = Mapper.Map<IEnumerable<SessionPayment>, IEnumerable<DistanceLearningDomain.Model.SessionPayment>>(rawApplicant);
            return refinedApplicant;
        }

        public DistanceLearningDomain.Model.SessionPayment GetSessionPayment(int Id)
        {
            var rawApplicant = (from c in Context.PayCategories.OfType<SessionPayment>() where c.Id == Id select c).FirstOrDefault();
            var refinedApplicant = Mapper.Map<SessionPayment, DistanceLearningDomain.Model.SessionPayment>(rawApplicant);
            return refinedApplicant;
        }

        public DistanceLearningDomain.Model.SessionPayment GetSessionPayment(string payDescription)
        {
            var rawApplicant = (from c in Context.PayCategories.OfType<SessionPayment>() where c.Description.ToLower() == payDescription.ToLower() select c).FirstOrDefault();
            var refinedApplicant = Mapper.Map<SessionPayment, DistanceLearningDomain.Model.SessionPayment>(rawApplicant);
            return refinedApplicant;
        }


        public IEnumerable<DistanceLearningDomain.Model.SessionPayment> GetAllSessionPaymentFromPayment(int payId)
        {
            var rawApplicant = (from c in Context.PayCategories.OfType<SessionPayment>() where c.PayId==payId select c);
            var refinedApplicant = Mapper.Map<IEnumerable<SessionPayment>, IEnumerable<DistanceLearningDomain.Model.SessionPayment>>(rawApplicant);
            return refinedApplicant;
        }

        public DistanceLearningDomain.Model.SessionPayment GetSesionPayment(int payId, int SessId)
        {
            var rawApplicant = (from c in Context.PayCategories.OfType<SessionPayment>() where c.PayId == payId && c.SessId==SessId select c).FirstOrDefault();
            var refinedApplicant = Mapper.Map<SessionPayment, DistanceLearningDomain.Model.SessionPayment>(rawApplicant);
            return refinedApplicant;
        }


        
    }
}
