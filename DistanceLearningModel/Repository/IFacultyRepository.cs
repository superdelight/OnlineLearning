using DistanceLearningDomain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DistanceLearningDomain.Repository
{
    public interface IFacultyRepository : IRepository<Faculty>
    {
       Faculty GetFaculty(string facCode);
       bool ConfirmFacultyByAcronyms(string acronyms);
       bool ConfirmFacultyByDescription(string description);
       Faculty GetFacultyByMatricNo(string MatNo);
    }
}

