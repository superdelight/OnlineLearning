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
    public class AdmissionProgrammeRepository : Repository<DistanceLearningDomain.Model.AdmissionProgramme,AdmissionProgrammeAdmin>,IAdmissionProgrammeRepository

    {
        private ElearningAdminEntities Context;
        public AdmissionProgrammeRepository(ElearningAdminEntities Context)
            :base(Context)
        {
            Mapper.CreateMap<DistanceLearningDomain.Model.AdmissionProgramme, AdmissionProgrammeAdmin >();
            Mapper.CreateMap<AdmissionProgrammeAdmin, DistanceLearningDomain.Model.AdmissionProgramme>();
            this.Context = Context;   
        }

        public bool ConfirmAdmissionProgramme(int progId, int SessId)
        {
            var rawApplicant = (from c in Context.AdmissionProgrammeAdmins where c.ProgId == progId && c.AdminId==SessId select c).Any();
            return rawApplicant;
        }
        public DistanceLearningDomain.Model.AdmissionProgramme GetProgramme(int progId, int SessId)
        {
            var rawApplicant = (from c in Context.AdmissionProgrammeAdmins where c.AdminId == SessId  && c.ProgId==progId select c).FirstOrDefault();
            var refinedApplicant = Mapper.Map<AdmissionProgrammeAdmin, DistanceLearningDomain.Model.AdmissionProgramme>(rawApplicant);
            return refinedApplicant;
        }

        public IEnumerable<DistanceLearningDomain.Model.AdmissionProgramme> GetAllAdmissioProgrammenInSession(int sessId)
        {
            var rawApplicant = (from c in Context.AdmissionProgrammeAdmins where c.AdminId == sessId  select c).ToList();
            var refinedApplicant = Mapper.Map<List<AdmissionProgrammeAdmin>, List<DistanceLearningDomain.Model.AdmissionProgramme>>(rawApplicant);
            return refinedApplicant;
        }
        public IEnumerable<DistanceLearningDomain.Model.AdmissionProgramme> GetAllAdmissioProgrammenByProgramme(int ProgId)
        {
            var rawApplicant = (from c in Context.AdmissionProgrammeAdmins where c.ProgrammeLevel.Programme.Id == ProgId select c).ToList();
            var refinedApplicant = Mapper.Map<List<AdmissionProgrammeAdmin>, List<DistanceLearningDomain.Model.AdmissionProgramme>>(rawApplicant);
            return refinedApplicant;
        }
        public IEnumerable<DistanceLearningDomain.Model.AdmissionProgramme> GetAllAdmissioProgrammenByDept(int deptId)
        {
            var rawApplicant = (from c in Context.AdmissionProgrammeAdmins where c.ProgrammeLevel.Programme.DeptID == deptId select c).ToList();
            var refinedApplicant = Mapper.Map<List<AdmissionProgrammeAdmin>, List<DistanceLearningDomain.Model.AdmissionProgramme>>(rawApplicant);
            return refinedApplicant;
        }

        public IEnumerable<DistanceLearningDomain.Model.AdmissionProgramme> GetAllAdmissioProgrammenByFaculty(int facId)
        {
            var rawApplicant = (from c in Context.AdmissionProgrammeAdmins where c.ProgrammeLevel.Programme.Department.FacId == facId select c).ToList();
            var refinedApplicant = Mapper.Map<List<AdmissionProgrammeAdmin>, List<DistanceLearningDomain.Model.AdmissionProgramme>>(rawApplicant);
            return refinedApplicant;
        }

        public IEnumerable<DistanceLearningDomain.Model.AdmissionProgramme> GetAllAdmissioProgrammenByFaculty(int facId, int sessId)
        {
            var rawApplicant = (from c in Context.AdmissionProgrammeAdmins where c.ProgrammeLevel.Programme.Department.FacId == facId && c.Admission.SessId==sessId select c).ToList();
            var refinedApplicant = Mapper.Map<List<AdmissionProgrammeAdmin>, List<DistanceLearningDomain.Model.AdmissionProgramme>>(rawApplicant);
            return refinedApplicant;
        }

        public IEnumerable<DistanceLearningDomain.Model.AdmissionProgramme> GetAllAdmissioProgrammenByDept(int deptId, int sessId)
        {
            var rawApplicant = (from c in Context.AdmissionProgrammeAdmins where c.ProgrammeLevel.Programme.DeptID == deptId && c.Admission.SessId == sessId select c).ToList();
            var refinedApplicant = Mapper.Map<List<AdmissionProgrammeAdmin>, List<DistanceLearningDomain.Model.AdmissionProgramme>>(rawApplicant);
            return refinedApplicant;
        }


        public IEnumerable<DistanceLearningDomain.Model.AdmissionProgramme> GetAllAdmissioProgrammenByAdmission(int admissionId)
        {
            var rawApplicant = (from c in Context.AdmissionProgrammeAdmins where c.AdminId == admissionId select c).ToList();
            var refinedApplicant = Mapper.Map<List<AdmissionProgrammeAdmin>, List<DistanceLearningDomain.Model.AdmissionProgramme>>(rawApplicant);
            return refinedApplicant;
        }


        public IEnumerable<DistanceLearningDomain.Model.AdmissionProgramme> GetAllAdmissioProgrammenByProgrammeLevId(int ProgId)
        {
     
            var rawApplicant = (from c in Context.AdmissionProgrammeAdmins where c.ProgId == ProgId select c).ToList();
            var refinedApplicant = Mapper.Map<List<AdmissionProgrammeAdmin>, List<DistanceLearningDomain.Model.AdmissionProgramme>>(rawApplicant);
            return refinedApplicant;
        
        }


        public IEnumerable<DistanceLearningDomain.Model.AdmissionProgramme> GetAllAdmissioProgrammenByAdmission(int admissionId, int deptId)
        {
            var rawApplicant = (from c in Context.AdmissionProgrammeAdmins where c.AdminId == admissionId && c.ProgrammeLevel.Programme.DeptID==deptId select c).ToList();
            var refinedApplicant = Mapper.Map<List<AdmissionProgrammeAdmin>, List<DistanceLearningDomain.Model.AdmissionProgramme>>(rawApplicant);
            return refinedApplicant;
        }
        public IEnumerable<DistanceLearningDomain.Model.AdmissionProgramme> GetAllAdmissioProgrammenByAward(int admissionId, int AwardId)
        {
            var rawApplicant = (from c in Context.AdmissionProgrammeAdmins where c.AdminId == admissionId && c.ProgrammeLevel.Programme.AwardId == AwardId select c).ToList();
            var refinedApplicant = Mapper.Map<List<AdmissionProgrammeAdmin>, List<DistanceLearningDomain.Model.AdmissionProgramme>>(rawApplicant);
            return refinedApplicant;
        }
    }
}
