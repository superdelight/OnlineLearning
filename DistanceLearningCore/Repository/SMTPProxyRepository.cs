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
    public class SMTPProxyRepository : Repository<DistanceLearningDomain.Model.SMTPProxy,SMTPProxy>,ISMTPProxyRepository
    {
        private ElearningAdminEntities Context;
        public SMTPProxyRepository(ElearningAdminEntities Context)
            :base(Context)
        {
            Mapper.CreateMap<DistanceLearningDomain.Model.SMTPProxy, SMTPProxy >();
            Mapper.CreateMap<SMTPProxy, DistanceLearningDomain.Model.SMTPProxy>();
            this.Context = Context;   
        }       
        public bool ConfirmSMTP(string detail)
        {
            var rawApplicant = (from c in Context.SMTPProxies where c.Description.ToLower() == detail.ToLower() select c).Any();
            return rawApplicant;
        }

        public DistanceLearningDomain.Model.SMTPProxy GetSMTP(string detail)
        {
            var rawApplicant = (from c in Context.SMTPProxies where c.Description.ToLower() == detail.ToLower() select c).FirstOrDefault();
            var refinedApplicant = Mapper.Map<SMTPProxy, DistanceLearningDomain.Model.SMTPProxy>(rawApplicant);
            return refinedApplicant;
        }
    }
}
