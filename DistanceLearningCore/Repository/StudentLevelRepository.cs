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
    public class StudentLevelRepository : Repository<DistanceLearningDomain.Model.StudentLevel, StudentLevel>, IStudentLevelRepository
    {
       private  StudentElearningEntities Context;
       public StudentLevelRepository(StudentElearningEntities Context)
            :base(Context)
        {
            Mapper.CreateMap<DistanceLearningDomain.Model.StudentLevel, StudentLevel>();
            Mapper.CreateMap<StudentLevel, DistanceLearningDomain.Model.StudentLevel>();
            this.Context = Context;
        }


       public bool ConfirmStudentLevel(int LevelId, int studentID)
       {
           var rawApplicant = (from p in Context.StudentLevels where p.StudentId==studentID && p.StudentCatLevel.ProgrammeLevel.LevId==LevelId select p).Any();
           return rawApplicant;
       }

       public bool ConfirmStudentLevel(int LevelId, string matNo)
       {
           var rawApplicant = (from p in Context.StudentLevels where p.Student.MatricNo.ToLower() == matNo.ToLower() && p.StudentCatLevel.ProgrammeLevel.LevId == LevelId select p).Any();
           return rawApplicant;
       }

       public DistanceLearningDomain.Model.StudentLevel GetStudentLevel(int LevelId, int studentID)
       {
           var rawApplicant = (from p in Context.StudentLevels where p.StudentId == studentID && p.StudentCatLevel.ProgrammeLevel.LevId == LevelId select p).FirstOrDefault();
           var refinedApplicant = Mapper.Map<StudentLevel, DistanceLearningDomain.Model.StudentLevel>(rawApplicant);
           return refinedApplicant;
       }

       public DistanceLearningDomain.Model.StudentLevel GetStudentLevel(int LevelId, string matricNo)
       {
           var rawApplicant = (from p in Context.StudentLevels where p.Student.MatricNo.ToLower() == matricNo.ToLower() && p.StudentCatLevel.ProgrammeLevel.LevId == LevelId select p).FirstOrDefault();
           var refinedApplicant = Mapper.Map<StudentLevel, DistanceLearningDomain.Model.StudentLevel>(rawApplicant);
           return refinedApplicant;
       }

       public DistanceLearningDomain.Model.StudentLevel GetStudentLevelBySession(int sessId, string matricNo)
       {
           var rawApplicant = (from p in Context.StudentLevels where p.Student.MatricNo.ToLower() == matricNo.ToLower() && p.SessId==sessId select p).FirstOrDefault();
           var refinedApplicant = Mapper.Map<StudentLevel, DistanceLearningDomain.Model.StudentLevel>(rawApplicant);
           return refinedApplicant;
       }

       public IEnumerable<DistanceLearningDomain.Model.StudentLevel> GetAllStudentLevel(int studentID)
       {
           var rawApplicant = (from p in Context.StudentLevels where p.StudentId==studentID select p).ToList();
           var refinedApplicant = Mapper.Map<List<StudentLevel>, List<DistanceLearningDomain.Model.StudentLevel>>(rawApplicant);
           return refinedApplicant;
       }

       public IEnumerable<DistanceLearningDomain.Model.StudentLevel> GetAllStudentLevel(string matNo)
       {
           var rawApplicant = (from p in Context.StudentLevels where p.Student.MatricNo.ToLower() == matNo.ToLower() select p).ToList();
           var refinedApplicant = Mapper.Map<List<StudentLevel>, List<DistanceLearningDomain.Model.StudentLevel>>(rawApplicant);
           return refinedApplicant;
       }
    }
}
