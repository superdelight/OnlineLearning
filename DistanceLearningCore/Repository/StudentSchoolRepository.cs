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
    public class StudentSchoolRepository : Repository<DistanceLearningDomain.Model.StudentSchool, StudentSchoolxx>, IStudentSchool
    {
        private StudentElearningEntities Context;
        public StudentSchoolRepository(StudentElearningEntities Context)
            :base(Context)
        {
            Mapper.CreateMap<DistanceLearningDomain.Model.StudentSchool, StudentSchoolxx>();
            Mapper.CreateMap<StudentSchoolxx, DistanceLearningDomain.Model.StudentSchool>();
            this.Context = Context;   
        }
     
        public bool ConfirmStudentSchool(string usr, string SchoolName)
        {
           return Context.StudentSchoolxxes.Where(c => c.Applicant.LoginID == usr).Any();
        }

        public IEnumerable<DistanceLearningDomain.Model.StudentSchool> GetStudentSchool(string usr)
        {
            var rawApplicant = Context.StudentSchoolxxes.Where(c => c.Applicant.LoginID == usr).ToList();
            var refinedApplicant = Mapper.Map<List<StudentSchoolxx>, List<DistanceLearningDomain.Model.StudentSchool>>(rawApplicant);
            return refinedApplicant;
        }
    }
}
