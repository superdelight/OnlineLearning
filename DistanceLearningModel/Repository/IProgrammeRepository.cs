using DistanceLearningDomain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DistanceLearningDomain.Repository
{
    public interface IProgrammeRepository : IRepository<Programme>
    {
        IEnumerable<Programme> GetAllProgrammeInDepartment(int deptId);
        IEnumerable<Programme> GetAllProgrammeInFaculty(int facId);
        IEnumerable<Programme> GetAllCourseByAward(int awardId);
        Programme GetProgramme(int awardId,int deptId);
        Programme GetStudentProgramme(string matNo);
        bool ConfirmPogrammeByCode(string ProgrammeCode);
        bool ConfirmProgrammeByDescription(string description);
    }
}

