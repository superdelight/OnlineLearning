using DistanceLearningDomain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DistanceLearningDomain.Repository
{
    public interface IStudentCategoryRepository : IRepository<StudentCategory>
    {
        bool ConfirmStudentCategory(string detail);
        StudentCategory GetStudentCategory(string detail);
    }
}