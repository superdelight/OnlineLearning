using DistanceLearningDomain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DistanceLearningDomain.Repository
{
    public interface IStudentExamination : IRepository<StudentExamination>
    {
        bool ConfirmStudentExamination(string usr,bool isFirst);
        bool ConfirmStudentExamination(string usr, string ExamNo);
        StudentExamination GetStudentExamination(string usr, bool isFirst);
        IEnumerable<StudentExamination> GetStudentExamination(string usr);
    }
}