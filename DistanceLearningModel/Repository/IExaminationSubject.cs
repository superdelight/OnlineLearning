using DistanceLearningDomain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DistanceLearningDomain.Repository
{
    public interface IExaminationSubject : IRepository<ExaminationSubject>
    {
        bool ConfirmExamSubject(int examId, int SubjectId);
        IEnumerable<ExaminationSubject> GetExamination(int examId);
        IEnumerable<ExaminationSubject> GetExamination(string examNo);
    }
}