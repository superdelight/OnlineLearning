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
    public class AdmissionRepository : Repository<DistanceLearningDomain.Model.Admission,Admission>,IAdmissionRepository

    {
        private ElearningAdminEntities Context;
        public AdmissionRepository(ElearningAdminEntities Context)
            :base(Context)
        {
            Mapper.CreateMap<DistanceLearningDomain.Model.Admission, Admission >();
            Mapper.CreateMap<Admission, DistanceLearningDomain.Model.Admission>();
            this.Context = Context;   
        }
       
        public bool ConfirmAdmission(string admissionDescription)
        {
            var rawApplicant = (from c in Context.Admissions where c.AdmissionDescription.ToLower() == admissionDescription.ToLower() select c).Any();
            return rawApplicant;
        }

        public IEnumerable<DistanceLearningDomain.Model.Admission> GetAllAdmissionInSession(int sessId)
        {
            var rawApplicant = (from c in Context.Admissions where c.SessId== sessId select c).ToList();
            var refinedApplicant = Mapper.Map<List<Admission>, List<DistanceLearningDomain.Model.Admission>>(rawApplicant);
            return refinedApplicant;
        }

        public IEnumerable<DistanceLearningDomain.Model.Admission> GetAllClosedAdmission()
        {
            var rawApplicant = (from c in Context.Admissions where c.IsOpen==false select c).ToList();
            var refinedApplicant = Mapper.Map<List<Admission>, List<DistanceLearningDomain.Model.Admission>>(rawApplicant);
            return refinedApplicant;
        }

        public IEnumerable<DistanceLearningDomain.Model.Admission> GetAllOpenAdmission()
        {
            var rawApplicant = (from c in Context.Admissions where c.IsOpen == true select c).ToList();
            var refinedApplicant = Mapper.Map<List<Admission>, List<DistanceLearningDomain.Model.Admission>>(rawApplicant);
            return refinedApplicant;
        }


        public IEnumerable<DistanceLearningDomain.Model.Admission> GetAllActiveAdmissionInSession(int sessId)
        {
            var rawApplicant = (from c in Context.Admissions where c.IsOpen == true || c.ClosingDate<=DateTime.Now select c).ToList();
            var refinedApplicant = Mapper.Map<List<Admission>, List<DistanceLearningDomain.Model.Admission>>(rawApplicant);
            return refinedApplicant;
        }


        public DistanceLearningDomain.Model.Admission GetAdmissionByProgramme(int admissionProgId)
        {
            var rawApplicant = (from c in Context.Admissions from d in c.AdmissionProgrammes where d.Id == admissionProgId select c).FirstOrDefault();
            var refinedApplicant = Mapper.Map<Admission, DistanceLearningDomain.Model.Admission>(rawApplicant);
            return refinedApplicant;
        }
    }
}
