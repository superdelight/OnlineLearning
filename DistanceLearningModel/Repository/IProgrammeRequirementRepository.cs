using DistanceLearningDomain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DistanceLearningDomain.Repository
{
    public interface IProgrammeRequirementRepository : IRepository<ProgrammeReq>
    {
        IEnumerable<ProgrammeReq> GetAllProgrammeRequirementByLevel(int LevId);
        IEnumerable<ProgrammeReq> GetAllProgrammeRequirementByLevel(int LevId,int semId);
        IEnumerable<ProgrammeReq> GetAllProgrammeRequirementByLevel(int LevId, int semId,bool IsElective);
        IEnumerable<ProgrammeReq> GetAllProgrammeRequirementBySem(int semId);
        IEnumerable<ProgrammeReq> GetAllProgrammeRequirementByProgramme(int progId);

        ProgrammeReq GetAllProgrammeRequirement(int LevId, int semId,bool IsElective);
        bool ConfirmProgrammeRequirement(int LevId, int semId, bool IsElective);
    }
}