using AutoMapper;
using DistanceLearningCore.Model.StudentModel;
using DistanceLearningDomain.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace DistanceLearningCore.Repository
{
    public class StudentRepository :Repository<DistanceLearningDomain.Model.Student,Studentxx>, IStudentRepository
    {
       private  StudentElearningEntities Context;
       public StudentRepository(StudentElearningEntities Context)
            :base(Context)
        {
            Mapper.CreateMap<DistanceLearningDomain.Model.Student, Studentxx>();
            Mapper.CreateMap<Studentxx, DistanceLearningDomain.Model.Student>();
            this.Context = Context;
        }
       public IEnumerable<DistanceLearningDomain.Model.Student> GetAllStudents()
       {
           var rawApplicant = Context.People.OfType<Studentxx>().Where(c => c.MatricNo != string.Empty).ToList();
           var refinedApplicant = Mapper.Map<List<Studentxx>, List<DistanceLearningDomain.Model.Student>>(rawApplicant);
           return refinedApplicant;
       }

       public DistanceLearningDomain.Model.Student GetApplicantByMatricNo(string MatricNo)
       {
           var rawApplicant = Context.People.OfType<Studentxx>().Where(c => c.MatricNo.Trim().ToLower().Equals(MatricNo.Trim().ToLower())).FirstOrDefault();
           var refinedApplicant = Mapper.Map<Studentxx, DistanceLearningDomain.Model.Student>(rawApplicant);
           return refinedApplicant;
          
       }
       public IEnumerable<DistanceLearningDomain.Model.Student> GetAllActiveStudents()
       {
           var rawApplicant = Context.People.OfType<Studentxx>().Where(c => c.MatricNo != string.Empty && c.IsActive == true).ToList();
           var refinedApplicant = Mapper.Map<List<Studentxx>, List<DistanceLearningDomain.Model.Student>>(rawApplicant);
           return refinedApplicant;
       }
       public IEnumerable<DistanceLearningDomain.Model.Student> GetAllNonActiveStudents()
       {
           var rawApplicant = Context.People.OfType<Studentxx>().Where(c => c.MatricNo != string.Empty && c.IsActive == false).ToList();
           var refinedApplicant = Mapper.Map<List<Studentxx>, List<DistanceLearningDomain.Model.Student>>(rawApplicant);
           return refinedApplicant;
       }

       public IEnumerable<DistanceLearningDomain.Model.Student> GetAllActiveStudents(int SessId)
       {
           var rawApplicant =( from p in Context.People.OfType<Studentxx>() from m in p.StudentLevels where p.MatricNo !=string.Empty && p.IsActive==true  &&  m.SessId==SessId select p).ToList();
           var refinedApplicant = Mapper.Map<List<Studentxx>, List<DistanceLearningDomain.Model.Student>>(rawApplicant);
           return refinedApplicant;
       }

       public IEnumerable<DistanceLearningDomain.Model.Student> GetAllNonActiveStudents(int SessId)
       {
          var rawApplicant =( from p in Context.People.OfType<Studentxx>()  from m in p.StudentLevels where p.MatricNo !=string.Empty && p.IsActive==false  && m.SessId==SessId select p).ToList();
           var refinedApplicant = Mapper.Map<List<Studentxx>, List<DistanceLearningDomain.Model.Student>>(rawApplicant);
           return refinedApplicant;
       }

       public IEnumerable<DistanceLearningDomain.Model.Student> GetAllActiveStudents(int SessId, int StudentLevId)
       {
          var rawApplicant =( from p in Context.People.OfType<Studentxx>() from m in p.StudentLevels where p.MatricNo !=string.Empty && p.IsActive==true  &&  m.SessId==SessId && m.Id==StudentLevId select p).ToList();
           var refinedApplicant = Mapper.Map<List<Studentxx>, List<DistanceLearningDomain.Model.Student>>(rawApplicant);
           return refinedApplicant;
       }

       public IEnumerable<DistanceLearningDomain.Model.Student> GetAllNonActiveStudents(int SessId, int StudentLevId)
       {
           var rawApplicant = (from p in Context.People.OfType<Studentxx>() from m in p.StudentLevels where p.MatricNo != string.Empty && p.IsActive == false && m.SessId == SessId && m.Id == StudentLevId select p).ToList();
           var refinedApplicant = Mapper.Map<List<Studentxx>, List<DistanceLearningDomain.Model.Student>>(rawApplicant);
           return refinedApplicant;
       }

       public IEnumerable<DistanceLearningDomain.Model.Student> GetAllStudents(int SessId, int StudentLevId)
       {
           var rawApplicant = (from p in Context.People.OfType<Studentxx>() from m in p.StudentLevels where p.MatricNo != string.Empty && m.SessId == SessId && m.Id == StudentLevId select p).ToList();
           var refinedApplicant = Mapper.Map<List<Studentxx>, List<DistanceLearningDomain.Model.Student>>(rawApplicant);
           return refinedApplicant;
       }


       public IEnumerable<DistanceLearningDomain.Model.Student> GetAllStudentsByLevel(int SessId, int LevId)
       {
           var rawApplicant = (from p in Context.People.OfType<Studentxx>() from m in p.StudentLevels where p.MatricNo != string.Empty && m.SessId == SessId && m.StudentCatLevel.ProgrammeLevel.LevId== LevId select p).ToList();
           var refinedApplicant = Mapper.Map<List<Studentxx>, List<DistanceLearningDomain.Model.Student>>(rawApplicant);
           return refinedApplicant;
       }

       public IEnumerable<DistanceLearningDomain.Model.Student> GetAllAciveStudentsByLevel(int SessId, int LevId)
       {
           var rawApplicant = (from p in Context.People.OfType<Studentxx>() from m in p.StudentLevels where p.MatricNo != string.Empty && p.IsActive==true && m.SessId == SessId && m.StudentCatLevel.ProgrammeLevel.LevId == LevId select p).ToList();
           var refinedApplicant = Mapper.Map<List<Studentxx>, List<DistanceLearningDomain.Model.Student>>(rawApplicant);
           return refinedApplicant;
       }

       public IEnumerable<DistanceLearningDomain.Model.Student> GetAllNonAciveStudentsByLevel(int SessId, int LevId)
       {
           var rawApplicant = (from p in Context.People.OfType<Studentxx>() from m in p.StudentLevels where p.MatricNo != string.Empty && p.IsActive == false && m.SessId == SessId && m.StudentCatLevel.ProgrammeLevel.LevId == LevId select p).ToList();
           var refinedApplicant = Mapper.Map<List<Studentxx>, List<DistanceLearningDomain.Model.Student>>(rawApplicant);
           return refinedApplicant;
       }

       public IEnumerable<DistanceLearningDomain.Model.Student> GetAllNonAciveStudentsByDept(int SessId, int DeptId)
       {
           var rawApplicant = (from p in Context.People.OfType<Studentxx>() from m in p.StudentLevels where p.MatricNo != string.Empty && p.IsActive == false && m.SessId == SessId && m.StudentCatLevel.ProgrammeLevel.Programme.DeptID == DeptId select p).ToList();
           var refinedApplicant = Mapper.Map<List<Studentxx>, List<DistanceLearningDomain.Model.Student>>(rawApplicant);
           return refinedApplicant;
           
       }

       public IEnumerable<DistanceLearningDomain.Model.Student> GetAllAciveStudentsByDept(int SessId, int DeptId)
       {
           var rawApplicant = (from p in Context.People.OfType<Studentxx>() from m in p.StudentLevels where p.MatricNo != string.Empty && p.IsActive == true && m.SessId == SessId && m.StudentCatLevel.ProgrammeLevel.Programme.DeptID == DeptId select p).ToList();
           var refinedApplicant = Mapper.Map<List<Studentxx>, List<DistanceLearningDomain.Model.Student>>(rawApplicant);
           return refinedApplicant;
       }

       public IEnumerable<DistanceLearningDomain.Model.Student> GetAllStudentsByDept(int SessId, int DeptId)
       {
           var rawApplicant = (from p in Context.People.OfType<Studentxx>() from m in p.StudentLevels where p.MatricNo != string.Empty &&  m.SessId == SessId && m.StudentCatLevel.ProgrammeLevel.Programme.DeptID == DeptId select p).ToList();
           var refinedApplicant = Mapper.Map<List<Studentxx>, List<DistanceLearningDomain.Model.Student>>(rawApplicant);
           return refinedApplicant;
       }


       public IEnumerable<DistanceLearningDomain.Model.Student> GetAllStudentsByStudentCategory(int SessId, int CatId)
       {
           var rawApplicant = (from p in Context.People.OfType<Studentxx>() from m in p.StudentLevels where  m.SessId == SessId && m.StudentCatLevel.StudCatId==CatId select p).ToList();
           var refinedApplicant = Mapper.Map<List<Studentxx>, List<DistanceLearningDomain.Model.Student>>(rawApplicant);
           return refinedApplicant;
       }

       public IEnumerable<DistanceLearningDomain.Model.Student> GetAllActiveStudentsByStudentCategory(int SessId, int CatId)
       {
           var rawApplicant = (from p in Context.People.OfType<Studentxx>() from m in p.StudentLevels where m.SessId == SessId && p.IsActive==true && m.StudentCatLevel.StudCatId==CatId select p).ToList();
           var refinedApplicant = Mapper.Map<List<Studentxx>, List<DistanceLearningDomain.Model.Student>>(rawApplicant);
           return refinedApplicant; 
       }

       public IEnumerable<DistanceLearningDomain.Model.Student> GetAllNonStudentsByStudentCategory(int SessId, int CatId)
       {
           var rawApplicant = (from p in Context.People.OfType<Studentxx>() from m in p.StudentLevels where m.SessId == SessId && p.IsActive == false && m.StudentCatLevel.StudCatId==CatId select p).ToList();
           var refinedApplicant = Mapper.Map<List<Studentxx>, List<DistanceLearningDomain.Model.Student>>(rawApplicant);
           return refinedApplicant; 
       }

       public IEnumerable<DistanceLearningDomain.Model.Student> GetAllStudentsByCategoryDepartment(int SessId, int CatId, int deptId)
       {
           var rawApplicant = (from p in Context.People.OfType<Studentxx>() from m in p.StudentLevels where m.SessId == SessId  && m.StudentCatLevel.ProgrammeLevel.Programme.DeptID==deptId select p).ToList();
           var refinedApplicant = Mapper.Map<List<Studentxx>, List<DistanceLearningDomain.Model.Student>>(rawApplicant);
           return refinedApplicant; 
       }

       public IEnumerable<DistanceLearningDomain.Model.Student> GetAllActiveStudentsByCategoryDepartment(int SessId, int CatId, int deptId)
       {
           var rawApplicant = (from p in Context.People.OfType<Studentxx>() from m in p.StudentLevels where p.IsActive==true && m.SessId == SessId && m.StudentCatLevel.ProgrammeLevel.Programme.DeptID == deptId select p).ToList();
           var refinedApplicant = Mapper.Map<List<Studentxx>, List<DistanceLearningDomain.Model.Student>>(rawApplicant);
           return refinedApplicant; 
       }

       public IEnumerable<DistanceLearningDomain.Model.Student> GetAllNonStudentsByCategoryDepartment(int SessId, int CatId, int deptId)
       {
           var rawApplicant = (from p in Context.People.OfType<Studentxx>() from m in p.StudentLevels where p.IsActive == false && m.SessId == SessId && m.StudentCatLevel.ProgrammeLevel.Programme.DeptID == deptId select p).ToList();
           var refinedApplicant = Mapper.Map<List<Studentxx>, List<DistanceLearningDomain.Model.Student>>(rawApplicant);
           return refinedApplicant;
       }

       public IEnumerable<DistanceLearningDomain.Model.Student> GetAllStudentsByProgrammeLevel(int SessId, int ProgLevId)
       {
           var rawApplicant = (from p in Context.People.OfType<Studentxx>() from m in p.StudentLevels where m.SessId == SessId && m.StudentCatLevel.ProgLevId == ProgLevId select p).ToList();
           var refinedApplicant = Mapper.Map<List<Studentxx>, List<DistanceLearningDomain.Model.Student>>(rawApplicant);
           return refinedApplicant;
       }

       public IEnumerable<DistanceLearningDomain.Model.Student> GetAllActiveStudentsByProgrammeLevel(int SessId, int ProgLevId)
       {
           var rawApplicant = (from p in Context.People.OfType<Studentxx>() from m in p.StudentLevels where p.IsActive==true &&  m.SessId == SessId && m.StudentCatLevel.ProgLevId == ProgLevId select p).ToList();
           var refinedApplicant = Mapper.Map<List<Studentxx>, List<DistanceLearningDomain.Model.Student>>(rawApplicant);
           return refinedApplicant;
       }

       public IEnumerable<DistanceLearningDomain.Model.Student> GetAllNonStudentsByProgrammeLevel(int SessId, int ProgLevId)
       {
           var rawApplicant = (from p in Context.People.OfType<Studentxx>() from m in p.StudentLevels where p.IsActive==false && m.SessId == SessId && m.StudentCatLevel.ProgLevId == ProgLevId select p).ToList();
           var refinedApplicant = Mapper.Map<List<Studentxx>, List<DistanceLearningDomain.Model.Student>>(rawApplicant);
           return refinedApplicant;
       }

       public IEnumerable<DistanceLearningDomain.Model.Student> GetAllStudentsByStudentCatLevel(int SessId, int studentCatId)
       {
           var rawApplicant = (from p in Context.People.OfType<Studentxx>() from m in p.StudentLevels where  m.SessId == SessId && m.StudLevelId == studentCatId select p).ToList();
           var refinedApplicant = Mapper.Map<List<Studentxx>, List<DistanceLearningDomain.Model.Student>>(rawApplicant);
           return refinedApplicant;
       }

       public IEnumerable<DistanceLearningDomain.Model.Student> GetAllActiveStudentsByStudentCatLevel(int SessId, int studentCatId)
       {
           var rawApplicant = (from p in Context.People.OfType<Studentxx>() from m in p.StudentLevels where p.IsActive == true && m.SessId == SessId && m.StudLevelId == studentCatId select p).ToList();
           var refinedApplicant = Mapper.Map<List<Studentxx>, List<DistanceLearningDomain.Model.Student>>(rawApplicant);
           return refinedApplicant;
       }

       public IEnumerable<DistanceLearningDomain.Model.Student> GetAllNonStudentsByByStudentCatLevel(int SessId, int studentCatId)
       {
           var rawApplicant = (from p in Context.People.OfType<Studentxx>() from m in p.StudentLevels where p.IsActive == false && m.SessId == SessId && m.StudLevelId == studentCatId select p).ToList();
           var refinedApplicant = Mapper.Map<List<Studentxx>, List<DistanceLearningDomain.Model.Student>>(rawApplicant);
           return refinedApplicant;
       }


       public DistanceLearningDomain.Model.Student GetStudent(string MatricNo)
       {
           var rawApplicant = Context.People.OfType<Studentxx>().Where(c => c.MatricNo.Trim().ToLower().Equals(MatricNo.Trim().ToLower())).FirstOrDefault();
           var refinedApplicant = Mapper.Map<Studentxx, DistanceLearningDomain.Model.Student>(rawApplicant);
           return refinedApplicant;
       }

       public DistanceLearningInfrastructure.StudentDetail GetStudentCurrentDetail(string matNo)
       {
           var student = (from c in Context.StudentLevels.OrderByDescending(m => m.SessId) where c.Student.MatricNo==matNo
                          select new DistanceLearningInfrastructure.StudentDetail
                          {
                              Id = c.Id,
                              Surname = c.Student.Surname,
                              Othername = c.Student.Othername,
                              Department = c.StudentCatLevel.ProgrammeLevel.Programme.Department.DeptName,
                              Faculty = c.StudentCatLevel.ProgrammeLevel.Programme.Department.FacId.ToString()
                          }).FirstOrDefault();
           return student;
       }

       public DistanceLearningInfrastructure.StudentDetail GetStudentProjectedDetails(int studentLevId)
       {
           var student = (from c in Context.StudentLevels
                          where c.Id == studentLevId
                          select new DistanceLearningInfrastructure.StudentDetail
                          {
                              Id = c.Id,
                              Surname = c.Student.Surname,
                              Othername = c.Student.Othername,
                              Department = c.StudentCatLevel.ProgrammeLevel.Programme.Department.DeptName,
                              Faculty = c.StudentCatLevel.ProgrammeLevel.Programme.Department.FacId.ToString()
                          }).FirstOrDefault();
           return student;
       }
       public IEnumerable<DistanceLearningDomain.Model.Student> GetAllStudentFromStudentCategory(int SessId, int studentCatLevId)
       {
           var student = (from c in Context.StudentLevels
                          where c.StudentCatLevel.Id == studentCatLevId && c.SessId==SessId
                          select c.Student).ToList();
           return Mapper.Map<List<Studentxx>,List<DistanceLearningDomain.Model.Student>>(student);
       }
    }
}
