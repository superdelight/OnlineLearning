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
    public class StudentRegistrationRepository : Repository<DistanceLearningDomain.Model.StudentRegistration, StudentRegistrationxx>, IStudentRegistrationRepository
    {
        private StudentElearningEntities Context;
        public StudentRegistrationRepository(StudentElearningEntities Context)
            :base(Context)
        {
            Mapper.CreateMap<DistanceLearningDomain.Model.StudentRegistration, StudentRegistrationxx>();
            Mapper.CreateMap<StudentRegistrationxx, DistanceLearningDomain.Model.StudentRegistration>();
            this.Context = Context;   
        }
     
        public bool ConfirmRegistration(int curriculumId, int studentID, int sessId)
        {
            return Context.StudentRegistrationxxes.Where(c => c.CourseId == curriculumId && c.SessId == sessId && c.StdId == studentID).Any();
        }

        public IEnumerable<DistanceLearningDomain.Model.StudentRegistration> GetStudentAllRegistration(int studentID, int sessId)
        {
            var rawApplicant = Context.StudentRegistrationxxes.Where(c => c.StdId == studentID && c.SessId==sessId).ToList();
            var refinedApplicant = Mapper.Map<List<StudentRegistrationxx>, List<DistanceLearningDomain.Model.StudentRegistration>>(rawApplicant);
            return refinedApplicant;
        }

        public IEnumerable<DistanceLearningDomain.Model.StudentRegistration> GetStudentAllRegistrationinCurriculum(int curriculumId, int sessId)
        {
            var rawApplicant = Context.StudentRegistrationxxes.Where(c => c.CourseId == curriculumId && c.SessId == sessId).ToList();
            var refinedApplicant = Mapper.Map<List<StudentRegistrationxx>, List<DistanceLearningDomain.Model.StudentRegistration>>(rawApplicant);
            return refinedApplicant;
        }
    }
}
