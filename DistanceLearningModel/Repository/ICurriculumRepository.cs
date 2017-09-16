using DistanceLearningDomain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DistanceLearningDomain.Repository
{
    public interface ICurriculumRepository : IRepository<Curriculum>
    {
        IEnumerable<Curriculum> GetAllCurriculum(int progLevId,int semID);
        IEnumerable<Curriculum> GetAllCurriculum(int progLevId, int semID,bool IsElective);
        IEnumerable<Curriculum> GetAllCurriculum(int progLevId);
        Curriculum GetACurriculum(int progLevId, int semID,int CourseId);
        Curriculum GetACurriculum(int reqId, int CourseId);
        bool ConfirmCurriculum(int progLevId, int semID, int CourseId);
        bool ConfirmCurriculum(int reqId, int CourseId);
        bool ConfirmCurriculumBrProg(int progLevId, int CourseId);
        
    }
}

