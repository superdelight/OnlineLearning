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
    public class AdmissionProcessingRepository : Repository<DistanceLearningDomain.Model.AdmissionProcessing, AdmissionProcessing>, IAdmissionProcessing
    {
        private StudentElearningEntities Context;
        public AdmissionProcessingRepository(StudentElearningEntities Context)
            :base(Context)
        {
            Mapper.CreateMap<DistanceLearningDomain.Model.AdmissionProcessing, AdmissionProcessing>();
            Mapper.CreateMap<AdmissionProcessing, DistanceLearningDomain.Model.AdmissionProcessing>();
            this.Context = Context;   
        }
     

        public bool ConfirmAdmission(string usr)
        {
            return Context.AdmissionProcessings.Where(c => c.Application.Applicant.LoginID == usr).Any();
        }

        public DistanceLearningDomain.Model.AdmissionProcessing GetAdmissionProcessing(string usr)
        {
            var rawApplicant = Context.AdmissionProcessings.Where(c => c.Application.Applicant.LoginID == usr).FirstOrDefault();
            var refinedApplicant = Mapper.Map<AdmissionProcessing, DistanceLearningDomain.Model.AdmissionProcessing>(rawApplicant);
            return refinedApplicant;
        }


        public bool ConfirmAdmission(int applicationId)
        {
            var rawApplicant = Context.AdmissionProcessings.Where(c => c.ApplicationId== applicationId).Any();
            //var refinedApplicant = Mapper.Map<AdmissionProcessing, DistanceLearningDomain.Model.AdmissionProcessing>(rawApplicant);
            return rawApplicant;
        }
    }
}
