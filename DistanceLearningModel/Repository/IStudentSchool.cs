using DistanceLearningDomain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DistanceLearningDomain.Repository
{
    public interface IStudentSchool : IRepository<StudentSchool>
    {
        bool ConfirmStudentSchool(string usr,string SchoolName);  
        IEnumerable<StudentSchool> GetStudentSchool(string usr);
    }
}