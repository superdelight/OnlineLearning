using DistanceLearningDomain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DistanceLearningDomain.Repository
{
    public interface IStudentRegistrationRepository : IRepository<StudentRegistration>
    {
        bool ConfirmRegistration(int curriculumId,int studentID,int sessId);
        IEnumerable<StudentRegistration> GetStudentAllRegistration(int studentID,int sessId);
        IEnumerable<StudentRegistration> GetStudentAllRegistrationinCurriculum(int curriculumId, int sessId);
       
    }
}