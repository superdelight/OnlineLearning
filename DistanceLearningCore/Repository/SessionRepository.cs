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
    public class SessionRepository : Repository<DistanceLearningDomain.Model.Session,Session>,ISessionRepository
    {
        private ElearningAdminEntities Context;
        public SessionRepository(ElearningAdminEntities Context)
            :base(Context)
        {
            Mapper.CreateMap<DistanceLearningDomain.Model.Session, Session>();
            Mapper.CreateMap<Session, DistanceLearningDomain.Model.Session>();
            this.Context = Context;   
        }
        public DistanceLearningDomain.Model.Session GetCurrentSesion()
        {
            var rawApplicant = (from c in Context.Sessions select c).OrderByDescending(c=>c.Id).FirstOrDefault();
            var refinedApplicant = Mapper.Map<Session, DistanceLearningDomain.Model.Session>(rawApplicant);
            return refinedApplicant;
        }
        public IEnumerable<DistanceLearningDomain.Model.Session> GetAllClosedSession()
        {
            var rawApplicant = (from c in Context.Sessions where c.IsOpen==false select c).ToList();
            var refinedApplicant = Mapper.Map<List<Session>, List<DistanceLearningDomain.Model.Session>>(rawApplicant);
            return refinedApplicant;
        }
        public bool ConfirmSession(string Session)
        {
          return (from c in Context.Sessions where c.SessionDescription.ToLower()==  Session.ToLower() select c).Any();
        }
    }
}
