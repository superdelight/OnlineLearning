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
    public class ProgrammeReqRepository : Repository<DistanceLearningDomain.Model.ProgrammeReq, ProgrammeReq>, IProgrammeRequirementRepository
    {
        private StudentElearningEntities Context;
        public ProgrammeReqRepository(StudentElearningEntities Context)
            :base(Context)
        {
            Mapper.CreateMap<DistanceLearningDomain.Model.ProgrammeReq, ProgrammeReq>();
            Mapper.CreateMap<ProgrammeReq, DistanceLearningDomain.Model.ProgrammeReq>();
            this.Context = Context;   
        }
       
     

        public IEnumerable<DistanceLearningDomain.Model.ProgrammeReq> GetAllProgrammeRequirementByLevel(int LevId)
        {
            var rawApplicant = (from c in Context.Requirements.OfType<ProgrammeReq>() where c.ProgId== LevId select c).ToList();
            var refinedApplicant = Mapper.Map<List<ProgrammeReq>, List<DistanceLearningDomain.Model.ProgrammeReq>>(rawApplicant);
            return refinedApplicant;
        }

        public IEnumerable<DistanceLearningDomain.Model.ProgrammeReq> GetAllProgrammeRequirementByLevel(int LevId, int semId)
        {
            var rawApplicant = (from c in Context.Requirements.OfType<ProgrammeReq>() where c.ProgId == LevId && c.SemId==semId select c).ToList();
            var refinedApplicant = Mapper.Map<List<ProgrammeReq>, List<DistanceLearningDomain.Model.ProgrammeReq>>(rawApplicant);
            return refinedApplicant;
        }

        public IEnumerable<DistanceLearningDomain.Model.ProgrammeReq> GetAllProgrammeRequirementByLevel(int LevId, int semId, bool IsElective)
        {
            var rawApplicant = (from c in Context.Requirements.OfType<ProgrammeReq>() where c.ProgId == LevId && c.SemId == semId && c.IsElective==IsElective select c).ToList();
            var refinedApplicant = Mapper.Map<List<ProgrammeReq>, List<DistanceLearningDomain.Model.ProgrammeReq>>(rawApplicant);
            return refinedApplicant;
        }

        public IEnumerable<DistanceLearningDomain.Model.ProgrammeReq> GetAllProgrammeRequirementBySem(int semId)
        {
            var rawApplicant = (from c in Context.Requirements.OfType<ProgrammeReq>() where c.SemId == semId select c).ToList();
            var refinedApplicant = Mapper.Map<List<ProgrammeReq>, List<DistanceLearningDomain.Model.ProgrammeReq>>(rawApplicant);
            return refinedApplicant;
        }

        public DistanceLearningDomain.Model.ProgrammeReq GetAllProgrammeRequirement(int LevId, int semId, bool IsElective)
        {
            var rawApplicant = (from c in Context.Requirements.OfType<ProgrammeReq>() where c.ProgId == LevId && c.SemId == semId && c.IsElective == IsElective select c).FirstOrDefault();
            var refinedApplicant = Mapper.Map<ProgrammeReq, DistanceLearningDomain.Model.ProgrammeReq>(rawApplicant);
            return refinedApplicant;
        }

        public bool ConfirmProgrammeRequirement(int LevId, int semId, bool IsElective)
        {
            var rawApplicant = (from c in Context.Requirements.OfType<ProgrammeReq>() where c.ProgId==LevId && c.SemId == semId && c.IsElective==IsElective select c).Any();
            return rawApplicant;
        }


        public IEnumerable<DistanceLearningDomain.Model.ProgrammeReq> GetAllProgrammeRequirementByProgramme(int progId)
        {
            var rawApplicant = (from c in Context.Requirements.OfType<ProgrammeReq>() where c.ProgrammeLevel.ProgId == progId select c).ToList();
            var refinedApplicant = Mapper.Map<List<ProgrammeReq>, List<DistanceLearningDomain.Model.ProgrammeReq>>(rawApplicant);
            return refinedApplicant;
        }
    }
}
