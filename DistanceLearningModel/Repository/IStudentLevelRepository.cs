using DistanceLearningDomain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DistanceLearningDomain.Repository
{
    public interface IStudentLevelRepository : IRepository<StudentLevel>
    {
        bool ConfirmStudentLevel(int LevelId,int studentID);
        bool ConfirmStudentLevel(int LevelId, string matNo);
        StudentLevel GetStudentLevel(int LevelId, int studentID);
        StudentLevel GetStudentLevel(int LevelId, string matricNo);
        StudentLevel GetStudentLevelBySession(int sessId, string matricNo);
        IEnumerable<StudentLevel> GetAllStudentLevel(int studentID);
        IEnumerable<StudentLevel> GetAllStudentLevel(string matNo);
    }
}