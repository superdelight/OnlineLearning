using DistanceLearningInfrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DistanceLearningDomain.Service
{
   public interface IRegistrationService
    {
       int RegisterCourses(int SessId, string MatricNo, List<CourseReg> Courses);
       IEnumerable<CourseReg> GetAllCourses(int studentlevId, int SemId,bool? IsElective);
       IEnumerable<CourseReg> GetAllRegisteredCourses(string matNo, int sessId);
       IEnumerable<StudentDetail> GetAllStudents(string CourseCode, int sessId);
       IEnumerable<StudentDetail> GetAllStudents(string CourseCode, int sessId, int progId);
       IEnumerable<StudentDetail> GetAllStudentsInDepartment(string CourseCode, int sessId, int deptId);
       IEnumerable<StudentDetail> GetAllStudentsInFaculty(string CourseCode, int sessId, int deptId);
    }
}
