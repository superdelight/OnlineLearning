using DistanceLearningDomain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DistanceLearningDomain.Repository
{
    public interface ICourseRepository : IRepository<Cours>
    {
        IEnumerable<Cours> GetAllCourseInDepartment(int deptId);
        IEnumerable<Cours> GetAllCourseInFaculty(int deptId);
        IEnumerable<Cours> GetAllCourseInRequirement(int progLevId,int SemId,bool IsElective);
        IEnumerable<Cours> GetAllCourseInRequirement(int progLevId, int SemId);
        Cours GetCourse(string CourseCode);
        Cours GetCourse(int CurrId);
        bool ConfirmCourseByCode(string CourseCode);
        bool ConfirmCourseByTitle(string description);
    }
}

