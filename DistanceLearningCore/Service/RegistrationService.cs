using DistanceLearningDomain.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DistanceLearningCore.Service
{
    public class RegistrationService:IRegistrationService
    {
        public int RegisterCourses(int SessId, string MatricNo, List<DistanceLearningInfrastructure.CourseReg> Courses)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DistanceLearningInfrastructure.CourseReg> GetAllCourses(int studentlevId, int SemId, bool? IsElective)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DistanceLearningInfrastructure.CourseReg> GetAllRegisteredCourses(string matNo, int sessId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DistanceLearningInfrastructure.StudentDetail> GetAllStudents(string CourseCode, int sessId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DistanceLearningInfrastructure.StudentDetail> GetAllStudents(string CourseCode, int sessId, int progId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DistanceLearningInfrastructure.StudentDetail> GetAllStudentsInDepartment(string CourseCode, int sessId, int deptId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DistanceLearningInfrastructure.StudentDetail> GetAllStudentsInFaculty(string CourseCode, int sessId, int deptId)
        {
            throw new NotImplementedException();
        }
    }
}
