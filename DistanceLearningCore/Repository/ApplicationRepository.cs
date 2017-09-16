using AutoMapper;
using DistanceLearningCore.Model.StudentModel;
using DistanceLearningDomain.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace DistanceLearningCore.Repository
{
    public class ApplicationRepository : Repository<DistanceLearningDomain.Model.Application, Application>, IApplicantion
    {
        private StudentElearningEntities Context;
        public ApplicationRepository(StudentElearningEntities Context)
            :base(Context)
        {
            Mapper.CreateMap<DistanceLearningDomain.Model.Application, Application>();
            Mapper.CreateMap<Application, DistanceLearningDomain.Model.Application>();
            this.Context = Context;   
        }
     
        public DistanceLearningDomain.Model.Application GetSingleApplication(int appId, int AdmissionProgId)
        {
            var rawApplicant = Context.Applications.Where(c => c.AppId == appId && c.AdmProgID == AdmissionProgId).FirstOrDefault();
            var refinedApplicant = Mapper.Map<Application, DistanceLearningDomain.Model.Application>(rawApplicant);
            return refinedApplicant;
        }

        public bool ConfirmApplication(int appId, int AdmissionProgId)
        {
            var rawApplicant = Context.Applications.Where(c => c.AppId == appId && c.AdmProgID == AdmissionProgId).Any();
            return rawApplicant;
        }

        public IEnumerable<DistanceLearningDomain.Model.Application> GetAllApplication(int admissionProgr)
        {
            var rawApplicant = Context.Applications.Where(c => c.AdmProgID == admissionProgr).ToList();
            var refinedApplicant = Mapper.Map<List<Application>, List<DistanceLearningDomain.Model.Application>>(rawApplicant);
            return refinedApplicant;
        }
        public bool CreateNewApp(DistanceLearningDomain.Model.Application app)
        {
            try
            {
                var inst = Mapper.Map<DistanceLearningDomain.Model.Application, Application>(app);
                Context.Applications.Add(inst);
                Context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public DistanceLearningDomain.Model.Application GetSingleApplication(string usr)
        {
            var rawApplicant = Context.Applications.Where(c => c.Applicant.LoginID == usr).FirstOrDefault();
            var refinedApplicant = Mapper.Map<Application, DistanceLearningDomain.Model.Application>(rawApplicant);
            return refinedApplicant;
        }
    }
}
