using DistanceLearningDomain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DistanceLearningDomain.Repository
{
    public interface ISemesterRepository : IRepository<Semester>
    {
        IEnumerable<Semester> GetAllSemester();
    }
}

