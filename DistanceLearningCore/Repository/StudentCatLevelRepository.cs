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
    public class StudentCatLevelRepository : Repository<DistanceLearningDomain.Model.StudentCatLevel, StudentCatLevel>, IStudCatLevelRepository
    {
       private  StudentElearningEntities Context;
       public StudentCatLevelRepository(StudentElearningEntities Context)
            :base(Context)
        {
            Mapper.CreateMap<DistanceLearningDomain.Model.StudentCatLevel, StudentCatLevel>();
            Mapper.CreateMap<StudentCatLevel, DistanceLearningDomain.Model.StudentCatLevel>();
            this.Context = Context;
        }



       public IEnumerable<DistanceLearningDomain.Model.StudentCatLevel> GetAllStudentCatLevel(int progLevId)
       {
           var rawApplicant = (from p in Context.StudentCatLevels where p.ProgLevId == progLevId select p).ToList();
           var refinedApplicant = Mapper.Map<List<StudentCatLevel>, List<DistanceLearningDomain.Model.StudentCatLevel>>(rawApplicant);
           return refinedApplicant;
       }

       public IEnumerable<DistanceLearningDomain.Model.StudentCatLevel> GetAllStudentCatLevelByLevel(int LevId)
       {
           var rawApplicant = (from p in Context.StudentCatLevels where p.ProgrammeLevel.LevId == LevId select p).ToList();
           var refinedApplicant = Mapper.Map<List<StudentCatLevel>, List<DistanceLearningDomain.Model.StudentCatLevel>>(rawApplicant);
           return refinedApplicant;
       }

       public IEnumerable<DistanceLearningDomain.Model.StudentCatLevel> GetAllStudentCatLevelByCategory(int CatId)
       {
           var rawApplicant = (from p in Context.StudentCatLevels where p.StudCatId == CatId select p).ToList();
           var refinedApplicant = Mapper.Map<List<StudentCatLevel>, List<DistanceLearningDomain.Model.StudentCatLevel>>(rawApplicant);
           return refinedApplicant;
       }

       public DistanceLearningDomain.Model.StudentCatLevel GetStudentCatLevel(int LevId, int ProgId)
       {
           var rawApplicant = (from p in Context.StudentCatLevels where p.ProgrammeLevel.LevId == LevId && p.ProgLevId==ProgId select p).FirstOrDefault();
           var refinedApplicant = Mapper.Map<StudentCatLevel, DistanceLearningDomain.Model.StudentCatLevel>(rawApplicant);
           return refinedApplicant;
       }

       public bool ConfirmStudentCatLevel(int LevId, int ProgId)
       {
           var rawApplicant = (from p in Context.StudentCatLevels where p.ProgrammeLevel.LevId == LevId && p.ProgLevId == ProgId select p).Any();
           //var refinedApplicant = Mapper.Map<StudentCatLevel, DistanceLearningDomain.Model.StudentCatLevel>(rawApplicant);
           return rawApplicant;
       }


       public DistanceLearningDomain.Model.StudentCatLevel GetFresherStudentCatLevel(int ProgId)
       {
           var catValue=Context.StudentCategoryxxxes.Where(c=>c.Description.ToLower().Contains("fresher")).FirstOrDefault();
           var rawApplicant = (from p in Context.StudentCatLevels where p.ProgrammeLevel.Programme.Id == ProgId && p.StudCatId == catValue.Id select p).FirstOrDefault();
           var refinedApplicant = Mapper.Map<StudentCatLevel, DistanceLearningDomain.Model.StudentCatLevel>(rawApplicant);
           return refinedApplicant;
       }

       public IEnumerable<DistanceLearningDomain.Model.StudentCatLevel> GetAllStudentCatLevByAward(int AwardID)
       {
           var rawApplicant = (from p in Context.StudentCatLevels where p.ProgrammeLevel.Programme.AwardId == AwardID select p).ToList();
           var refinedApplicant = Mapper.Map<List<StudentCatLevel>, List<DistanceLearningDomain.Model.StudentCatLevel>>(rawApplicant);
           return refinedApplicant;
       }
    }
}
