using DistanceLearningDomain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DistanceLearningDomain.Repository
{
    public interface IProgrammeLevelRepositoy : IRepository<ProgrammeLevel>
    {
        IEnumerable<ProgrammeLevel> GetAllProgrammeLevel(int LevId);
        IEnumerable<ProgrammeLevel> GetAllProgrammeLevelByProgramme(int ProgId);
        IEnumerable<ProgrammeLevel> GetAllProgrammeLevelByAward(int awardId);
        IEnumerable<ProgrammeLevel> GetAllProgrammeLevelByFaculty(int facId);
        IEnumerable<ProgrammeLevel> GetAllProgrammeLevelByFaculty(int facId,int levId);
        ProgrammeLevel GetAProgrammeLevel(int LevId, int ProgId);
      //  ProgrammeLevel GetApplicantAProgrammeLevel(string usr);
        bool ConfirmProgrammeLevel(int LevId, int ProgId);
    
    }
}

