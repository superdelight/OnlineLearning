using DistanceLearningDomain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DistanceLearningDomain.Repository
{
    public interface ILevelRepository : IRepository<Level>
    {
       
        bool ConfirmLevel(string detail);
        Level GetLevel(string detail);
        Level GetLevelFromStudentLevel(int studId);

    }
}
