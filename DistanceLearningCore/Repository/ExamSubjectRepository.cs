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
    public class ExamSubjectRepository : Repository<DistanceLearningDomain.Model.ExaminationSubject, ExaminationSubject>, IExaminationSubject
    {
        private StudentElearningEntities Context;
        public ExamSubjectRepository(StudentElearningEntities Context)
            :base(Context)
        {
            Mapper.CreateMap<DistanceLearningDomain.Model.ExaminationSubject, ExaminationSubject>();
            Mapper.CreateMap<ExaminationSubject, DistanceLearningDomain.Model.ExaminationSubject>();
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

        public IEnumerable<DistanceLearningDomain.Model.ExaminationSubject> GetExamination(int examId)
        {
            var rawApplicant = Context.ExaminationSubjects.Where(c => c.ExamId == examId).ToList();
            var refinedApplicant = Mapper.Map<List<ExaminationSubject>, List<DistanceLearningDomain.Model.ExaminationSubject>>(rawApplicant);
            return refinedApplicant;
        }

        public IEnumerable<DistanceLearningDomain.Model.ExaminationSubject> GetExamination(string examNo)
        {
            var rawApplicant = Context.ExaminationSubjects.Where(c => c.StudentExamination.ExamNo.ToLower() == examNo.ToLower()).ToList();
            var refinedApplicant = Mapper.Map<List<ExaminationSubject>, List<DistanceLearningDomain.Model.ExaminationSubject>>(rawApplicant);
            return refinedApplicant;
        }

        public bool ConfirmExamSubject(int examId, int SubjectId)
        {
            return Context.ExaminationSubjects.Where(c => c.ExamId == examId && c.SubjectId == SubjectId).Any();
        }
    }
}
