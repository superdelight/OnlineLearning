using DistanceLearningDomain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DistanceLearningDomain.Repository
{
    public interface IFacultyByLevel : IRepository<FacultyByLevel>
    {
        IEnumerable<FacultyByLevel> GetAllFacultyByLevel();
        bool ConfirmFacultyByLevel(int FacultyId, int awardId, int CatId);
        FacultyByLevel GetFacultyByLevel(int FacultyId, int awardId, int CatId);
        IEnumerable<FacultyByLevel> GetAllFacultyByLevel(int CatId);
        IEnumerable<FacultyByLevel> GetAllFacultyByLevel(int CatId,int facId);
    }
}

