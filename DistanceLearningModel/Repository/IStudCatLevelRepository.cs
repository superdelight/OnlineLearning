using DistanceLearningDomain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DistanceLearningDomain.Repository
{
    public interface IStudCatLevelRepository : IRepository<StudentCatLevel>
    {
        IEnumerable<StudentCatLevel> GetAllStudentCatLevByAward(int AwardID);
        IEnumerable<StudentCatLevel> GetAllStudentCatLevel(int progLevId);
        IEnumerable<StudentCatLevel> GetAllStudentCatLevelByLevel(int LevId);
        IEnumerable<StudentCatLevel> GetAllStudentCatLevelByCategory(int CatId);
        StudentCatLevel GetStudentCatLevel(int LevId, int ProgId);
        StudentCatLevel GetFresherStudentCatLevel(int ProgId);
        bool ConfirmStudentCatLevel(int LevId, int ProgId);
    }
}

