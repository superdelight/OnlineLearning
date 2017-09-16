using DistanceLearningDomain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DistanceLearningDomain.Repository
{
    public interface IDepartmentRepository : IRepository<Department>
    {
       IEnumerable<Department> GetAllDepartment(int FacId);
       Department GetDepartment(string deptCode);
       Department GetDepartmentByAcronyms(string deptCode);
       Department GetDepartmentByMatricNo(string MatNo);
       bool ConfirmDepartmentByName(string deptDes);
       bool ConfirmDepartmentByCode(string code);
    }
}

