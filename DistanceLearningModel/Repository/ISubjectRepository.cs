using DistanceLearningDomain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DistanceLearningDomain.Repository
{
    public interface ISubjectRepository : IRepository<Subject>
    {
       
        bool ConfirmSubject(string detail);
        Subject GetSubject(string detail);

    }
}

