using DistanceLearningDomain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DistanceLearningDomain.Repository
{
    public interface IStudentEmployment : IRepository<Employment>
    { 
        IEnumerable<Employment> GetEmployment(string usr);
    }
}