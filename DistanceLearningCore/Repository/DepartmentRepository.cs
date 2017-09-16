using AutoMapper;
using DistanceLearningCore.Model.Administration;
using DistanceLearningDomain.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace DistanceLearningCore.Repository
{
    public class DepartmentRepository : Repository<DistanceLearningDomain.Model.Department,Department>, IDepartmentRepository
    {
        private ElearningAdminEntities Context;
        public DepartmentRepository(ElearningAdminEntities Context)
            :base(Context)
        {
            Mapper.CreateMap<DistanceLearningDomain.Model.Department, Department>();
            Mapper.CreateMap<Department, DistanceLearningDomain.Model.Department>();
            this.Context = Context;  
        }
        public IEnumerable<DistanceLearningDomain.Model.Department> GetAllDepartment(int FacId)
        {
            var rawApplicant = Context.Departments.Where(c => c.FacId==FacId).ToList();
            var refinedApplicant = Mapper.Map<List<Department>, List<DistanceLearningDomain.Model.Department>>(rawApplicant);
            return refinedApplicant;
        }

        public DistanceLearningDomain.Model.Department GetDepartment(string deptCode)
        {
            var rawApplicant = Context.Departments.Where(c => c.DeptCode.ToLower()==deptCode.ToLower()).FirstOrDefault();
            var refinedApplicant = Mapper.Map<Department, DistanceLearningDomain.Model.Department>(rawApplicant);
            return refinedApplicant;
        }

        public DistanceLearningDomain.Model.Department GetDepartmentByAcronyms(string deptCode)
        {
            var rawApplicant = Context.Departments.Where(c => c.DeptAcronymns.ToLower() == deptCode.ToLower()).FirstOrDefault();
            var refinedApplicant = Mapper.Map<Department, DistanceLearningDomain.Model.Department>(rawApplicant);
            return refinedApplicant;
        }


        public bool ConfirmDepartmentByName(string deptDes)
        {
            var rawApplicant = Context.Departments.Where(c => c.DeptName.ToLower() == deptDes.ToLower()).Any();
            return rawApplicant;
        }

        public bool ConfirmDepartmentByCode(string code)
        {
            
            var rawApplicant = Context.Departments.Where(c => c.DeptAcronymns.ToLower() == code.ToLower()).Any();
            return rawApplicant;
        }


        public DistanceLearningDomain.Model.Department GetDepartmentByMatricNo(string MatNo)
        {
            var rawApplicant = ( from c in Context.Departments from d in c.Programmes from m in d.ProgrammeLevels from n in m.StudentCatLevels from k in n.StudentLevels  where k.Student.MatricNo.ToLower()==MatNo.ToLower() select c).FirstOrDefault();
            var refinedApplicant = Mapper.Map<Department, DistanceLearningDomain.Model.Department>(rawApplicant);
            return refinedApplicant;
        }
    }
}
