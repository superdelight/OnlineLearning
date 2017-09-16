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
    public class SubjectRepository : Repository<DistanceLearningDomain.Model.Subject,Subject>,ISubjectRepository
    {
        private ElearningAdminEntities Context;
        public SubjectRepository(ElearningAdminEntities Context)
            :base(Context)
        {
            Mapper.CreateMap<DistanceLearningDomain.Model.Subject, Subject>();
            Mapper.CreateMap<Subject, DistanceLearningDomain.Model.Subject>();
            this.Context = Context;   
        }
        public bool ConfirmSubject(string detail)
        {
            var rawApplicant = (from c in Context.Subjects where c.SubjectDetails.ToLower() == detail.ToLower() select c).Any();
            return rawApplicant;
        }

        public DistanceLearningDomain.Model.Subject GetSubject(string detail)
        {
            var rawApplicant = (from c in Context.Subjects  where c.SubjectDetails.ToLower() == detail.ToLower() select c).FirstOrDefault();
            var refinedApplicant = Mapper.Map<Subject, DistanceLearningDomain.Model.Subject>(rawApplicant);
            return refinedApplicant;
        }
    }
}
