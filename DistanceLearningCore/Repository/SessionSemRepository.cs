using AutoMapper;
using DistanceLearningCore.Model.Administration;
using DistanceLearningDomain.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace DistanceLearningCore.Repository
{
    public class SessionSemRepository : Repository<DistanceLearningDomain.Model.SessionSem,SessionSem>,ISessionSemRepository
    {
        private ElearningAdminEntities Context;
        public SessionSemRepository(ElearningAdminEntities Context)
            :base(Context)
        {
            Mapper.CreateMap<DistanceLearningDomain.Model.SessionSem, SessionSem >();
            Mapper.CreateMap<SessionSem, DistanceLearningDomain.Model.SessionSem>();
            this.Context = Context;   
        }
     
        public bool ConfirmSessionSem(int SessId, int SemId)
        {
            var rawApplicant = (from c in Context.SessionSems where c.SessId == SemId select c).Any();
            return rawApplicant;
        }

        public DistanceLearningDomain.Model.SessionSem GetSessionSem(int SessId, int SemId)
        {
            var rawApplicant = (from c in Context.SessionSems where c.SessId == SessId && c.SemId==SemId select c).FirstOrDefault();
            var refinedApplicant = Mapper.Map<SessionSem, DistanceLearningDomain.Model.SessionSem>(rawApplicant);
            return refinedApplicant;
        }

        public IEnumerable<DistanceLearningDomain.Model.SessionSem> GetAllSessionInSession(int SessId)
        {
            var rawApplicant = (from c in Context.SessionSems where c.SessId == SessId  select c).ToList();
            var refinedApplicant = Mapper.Map<List<SessionSem>, List<DistanceLearningDomain.Model.SessionSem>>(rawApplicant);
            return refinedApplicant;
        }

        public IEnumerable<DistanceLearningDomain.Model.SessionSem> GetAllSessionInSemester(int SemId)
        {
            var rawApplicant = (from c in Context.SessionSems where c.SemId == SemId select c).ToList();
            var refinedApplicant = Mapper.Map<List<SessionSem>, List<DistanceLearningDomain.Model.SessionSem>>(rawApplicant);
            return refinedApplicant;
        }

        public IEnumerable<DistanceLearningDomain.Model.SessionSem> GetAllOpenSessionInSession(int SessId)
        {
            var rawApplicant = (from c in Context.SessionSems where c.SessId == SessId select c).ToList();
            var refinedApplicant = Mapper.Map<List<SessionSem>, List<DistanceLearningDomain.Model.SessionSem>>(rawApplicant);
            return refinedApplicant;
        }

        public IEnumerable<DistanceLearningDomain.Model.SessionSem> GetAllOpenSessionInSemester(int SemId)
        {
            var rawApplicant = (from c in Context.SessionSems where c.SemId == SemId select c).ToList();
            var refinedApplicant = Mapper.Map<List<SessionSem>, List<DistanceLearningDomain.Model.SessionSem>>(rawApplicant);
            return refinedApplicant;
        }


        public DistanceLearningDomain.Model.SessionSem GetActiveSessionSem()
        {
            var rawApplicant = (from c in Context.SessionSems where c.IsOpen==true select c).FirstOrDefault();
            var refinedApplicant = Mapper.Map<SessionSem, DistanceLearningDomain.Model.SessionSem>(rawApplicant);
            return refinedApplicant;
        }
    }
}
