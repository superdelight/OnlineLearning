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
    public class StudentExaminationRepository : Repository<DistanceLearningDomain.Model.StudentExamination, StudentExamination>, IStudentExamination
    {
        private StudentElearningEntities Context;
        public StudentExaminationRepository(StudentElearningEntities Context)
            :base(Context)
        {
            Mapper.CreateMap<DistanceLearningDomain.Model.StudentExamination, StudentExamination>();
            Mapper.CreateMap<StudentExamination, DistanceLearningDomain.Model.StudentExamination>();
            this.Context = Context;   
        }
     
        public bool ConfirmStudentExamination(string usr, bool isFirst)
        {
            throw new NotImplementedException();
        }
        public bool ConfirmStudentExamination(string usr, string ExamNo)
        {
            var rawApplicant = Context.StudentExaminations.Where(c => c.Applicant.LoginID == usr && c.ExamNo.ToLower()==ExamNo.ToLower()).Any();
            return rawApplicant;
          
        }

        public DistanceLearningDomain.Model.StudentExamination GetStudentExamination(string usr, bool isFirst)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DistanceLearningDomain.Model.StudentExamination> GetStudentExamination(string usr)
        {
            var rawApplicant = Context.StudentExaminations.Where(c => c.Applicant.LoginID == usr).ToList();
            var refinedApplicant = Mapper.Map<List<StudentExamination>, List<DistanceLearningDomain.Model.StudentExamination>>(rawApplicant);
            return refinedApplicant;
        }
    }
}
