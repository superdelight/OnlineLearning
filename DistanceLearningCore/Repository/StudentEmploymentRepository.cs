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
    public class StudentEmploymentRepository : Repository<DistanceLearningDomain.Model.Employment, Employmentxx>, IStudentEmployment
    {
        private StudentElearningEntities Context;
        public StudentEmploymentRepository(StudentElearningEntities Context)
            :base(Context)
        {
            Mapper.CreateMap<DistanceLearningDomain.Model.Employment, Employmentxx>();
            Mapper.CreateMap<Employmentxx, DistanceLearningDomain.Model.Employment>();
            this.Context = Context;   
        }
     

        public IEnumerable<DistanceLearningDomain.Model.Employment> GetEmployment(string usr)
        {
            var rawApplicant = Context.Employmentxxes.Where(c => c.Applicant.LoginID == usr).ToList();
            var refinedApplicant = Mapper.Map<List<Employmentxx>, List<DistanceLearningDomain.Model.Employment>>(rawApplicant);
            return refinedApplicant;
        }
    }
}
