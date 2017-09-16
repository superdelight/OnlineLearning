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
    public class SessionSemPaymentRepository : Repository<DistanceLearningDomain.Model.SessionSemPayment,SessionSemPayment>, ISessionSemPayment
    {
        private ElearningPayEntities Context;
        public SessionSemPaymentRepository(ElearningPayEntities Context)
            :base(Context)
        {
            Mapper.CreateMap<DistanceLearningDomain.Model.SessionSemPayment, SessionSemPayment>();
            Mapper.CreateMap<SessionSemPayment, DistanceLearningDomain.Model.SessionSemPayment>();
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

        public IEnumerable<DistanceLearningDomain.Model.SessionSemPayment> GetAllSessionSemPayment()
        {
            var rawApplicant = (from c in Context.PayCategories.OfType<SessionSemPayment>() select c).ToList();
            var refinedApplicant = Mapper.Map<IEnumerable<SessionSemPayment>, IEnumerable<DistanceLearningDomain.Model.SessionSemPayment>>(rawApplicant);
            return refinedApplicant;
        }

        public bool ConfirmSessionSemPayment(string payDescription)
        {
            var rawApplicant = (from c in Context.PayCategories where c is SessionSemPayment && c.Description.ToLower() == payDescription.ToLower() select c).Any();
            return rawApplicant;
        }

        IEnumerable<DistanceLearningDomain.Model.SessionSemPayment> ISessionSemPayment.GetAllSessionPayment(int SessId)
        {
            var rawApplicant = (from c in Context.PayCategories.OfType<SessionSemPayment>() where c.SessId == SessId select c);
            var refinedApplicant = Mapper.Map<IEnumerable<SessionSemPayment>, IEnumerable<DistanceLearningDomain.Model.SessionSemPayment>>(rawApplicant);
            return refinedApplicant;
        }
        public IEnumerable<DistanceLearningDomain.Model.SessionSemPayment> GetAllSessionPaymentInSession(int SessId)
        {
            var rawApplicant = (from c in Context.PayCategories.OfType<SessionSemPayment>()  where c.SessionSem.SessId == SessId select c);
            var refinedApplicant = Mapper.Map<IEnumerable<SessionSemPayment>, IEnumerable<DistanceLearningDomain.Model.SessionSemPayment>>(rawApplicant);
            return refinedApplicant;
        }
        public IEnumerable<DistanceLearningDomain.Model.SessionSemPayment> GetAllSessionPaymentSemester(int semId)
        {
            var rawApplicant = (from c in Context.PayCategories.OfType<SessionSemPayment>() where c.SessionSem.SemId == semId select c);
            var refinedApplicant = Mapper.Map<IEnumerable<SessionSemPayment>, IEnumerable<DistanceLearningDomain.Model.SessionSemPayment>>(rawApplicant);
            return refinedApplicant;
        }
        public DistanceLearningDomain.Model.SessionSemPayment GetSessionSemPayment(string paDescription)
        {
            var rawApplicant = (from c in Context.PayCategories.OfType<SessionSemPayment>()  where c.Description.ToLower()== paDescription.ToLower() select c).FirstOrDefault();
            var refinedApplicant = Mapper.Map<SessionSemPayment, DistanceLearningDomain.Model.SessionSemPayment>(rawApplicant);
            return refinedApplicant;
        }
        public DistanceLearningDomain.Model.SessionSemPayment GetSessionSemPayment(int Id)
        {
            var rawApplicant = (from c in Context.PayCategories.OfType<SessionSemPayment>() where c.Id == Id select c).FirstOrDefault();
            var refinedApplicant = Mapper.Map<SessionSemPayment, DistanceLearningDomain.Model.SessionSemPayment>(rawApplicant);
            return refinedApplicant;
        }
        public IEnumerable<DistanceLearningDomain.Model.SessionSemPayment> GetAllSessionSemPayment(int payId)
        {
            var rawApplicant = (from c in Context.PayCategories.OfType<SessionSemPayment>() where c.PayId == payId select c);
            var refinedApplicant = Mapper.Map<IEnumerable<SessionSemPayment>, IEnumerable<DistanceLearningDomain.Model.SessionSemPayment>>(rawApplicant);
            return refinedApplicant;
        }
        public IEnumerable<DistanceLearningDomain.Model.SessionSemPayment> GetAllSessionSemPaymentBySession(int payId, int sessId)
        {
            var rawApplicant = (from c in Context.PayCategories.OfType<SessionSemPayment>() where c.PayId == payId && c.SessionSem.SessId==sessId select c);
            var refinedApplicant = Mapper.Map<IEnumerable<SessionSemPayment>, IEnumerable<DistanceLearningDomain.Model.SessionSemPayment>>(rawApplicant);
            return refinedApplicant;
        }
        public DistanceLearningDomain.Model.SessionSemPayment GetSesionPayment(int payId, int SessId)
        {
            var rawApplicant = (from c in Context.PayCategories.OfType<SessionSemPayment>() where c.PayId == payId && c.SessId == SessId select c).FirstOrDefault();
            var refinedApplicant = Mapper.Map<SessionSemPayment, DistanceLearningDomain.Model.SessionSemPayment>(rawApplicant);
            return refinedApplicant;
        }
    }
}
