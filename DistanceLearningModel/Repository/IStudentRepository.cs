using DistanceLearningDomain.Model;
using DistanceLearningInfrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DistanceLearningDomain.Repository
{
    public interface IStudentRepository : IRepository<Student>
    {
       IEnumerable<Student> GetAllStudents();
       Student GetApplicantByMatricNo(string MatricNo);
       Student GetStudent(string MatricNo);
       IEnumerable<Student> GetAllActiveStudents();
       IEnumerable<Student> GetAllNonActiveStudents();
       IEnumerable<Student> GetAllActiveStudents(int SessId);
       IEnumerable<Student> GetAllNonActiveStudents(int SessId);
       IEnumerable<Student> GetAllStudentFromStudentCategory(int SessId, int studentCatLevId);
       IEnumerable<Student> GetAllActiveStudents(int SessId,int StudentLevId);
       IEnumerable<Student> GetAllNonActiveStudents(int SessId, int StudentLevId);
       IEnumerable<Student> GetAllStudents(int SessId, int StudentLevId);
       IEnumerable<Student> GetAllStudentsByLevel(int SessId, int LevId);
       IEnumerable<Student> GetAllAciveStudentsByLevel(int SessId, int LevId);
       IEnumerable<Student> GetAllNonAciveStudentsByLevel(int SessId, int LevId);
       IEnumerable<Student> GetAllNonAciveStudentsByDept(int SessId, int DeptId);
       IEnumerable<Student> GetAllAciveStudentsByDept(int SessId, int DeptId);
       IEnumerable<Student> GetAllStudentsByDept(int SessId, int DeptId);
       IEnumerable<Student> GetAllStudentsByStudentCategory(int SessId, int CatId);
       IEnumerable<Student> GetAllActiveStudentsByStudentCategory(int SessId, int CatId);
       IEnumerable<Student> GetAllNonStudentsByStudentCategory(int SessId, int CatId);
       IEnumerable<Student> GetAllStudentsByCategoryDepartment(int SessId, int CatId,int deptId);
       IEnumerable<Student> GetAllActiveStudentsByCategoryDepartment(int SessId, int CatId,int deptId);
       IEnumerable<Student> GetAllNonStudentsByCategoryDepartment(int SessId, int CatId,int deptId);
       IEnumerable<Student> GetAllStudentsByProgrammeLevel(int SessId, int ProgLevId);
       IEnumerable<Student> GetAllActiveStudentsByProgrammeLevel(int SessId, int ProgLevId);
       IEnumerable<Student> GetAllNonStudentsByProgrammeLevel(int SessId, int ProgLevId);
       IEnumerable<Student> GetAllStudentsByStudentCatLevel(int SessId, int studentCatId);
       IEnumerable<Student> GetAllActiveStudentsByStudentCatLevel(int SessId, int studentCatId);
       IEnumerable<Student> GetAllNonStudentsByByStudentCatLevel(int SessId, int studentCatId);
       StudentDetail GetStudentCurrentDetail(string matNo);
       StudentDetail GetStudentProjectedDetails(int studentLevId);
    }
}