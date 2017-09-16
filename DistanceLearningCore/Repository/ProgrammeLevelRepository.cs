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
    public class ProgrammeLevelRepository : Repository<DistanceLearningDomain.Model.ProgrammeLevel, ProgrammeLevel>, IProgrammeLevelRepositoy
    {
       private  StudentElearningEntities Context;
       public ProgrammeLevelRepository(StudentElearningEntities Context)
            :base(Context)
        {
            Mapper.CreateMap<DistanceLearningDomain.Model.ProgrammeLevel, ProgrammeLevel>();
            Mapper.CreateMap<ProgrammeLevel, DistanceLearningDomain.Model.ProgrammeLevel>();
            this.Context = Context;
        }


       public bool ConfirmStudentLevel(int LevelId, int studentID)
       {
           var rawApplicant = (from p in Context.StudentLevels where p.StudentId==studentID && p.StudentCatLevel.ProgrammeLevel.LevId==LevelId select p).Any();
           return rawApplicant;
       }


       public IEnumerable<DistanceLearningDomain.Model.ProgrammeLevel> GetAllProgrammeLevel(int LevId)
       {
           var rawApplicant = (from p in Context.ProgrammeLevels where p.LevId == LevId select p).ToList();
           var refinedApplicant = Mapper.Map<List<ProgrammeLevel>, List<DistanceLearningDomain.Model.ProgrammeLevel>>(rawApplicant);
           return refinedApplicant;
       }

       public IEnumerable<DistanceLearningDomain.Model.ProgrammeLevel> GetAllProgrammeLevelByProgramme(int ProgId)
       {
           var rawApplicant = (from p in Context.ProgrammeLevels where p.ProgId == ProgId select p).ToList();
           var refinedApplicant = Mapper.Map<List<ProgrammeLevel>, List<DistanceLearningDomain.Model.ProgrammeLevel>>(rawApplicant);
           return refinedApplicant;
       }

       public DistanceLearningDomain.Model.ProgrammeLevel GetAProgrammeLevel(int LevId, int ProgId)
       {
           var rawApplicant = (from p in Context.ProgrammeLevels where p.ProgId == ProgId && p.LevId==LevId select p).FirstOrDefault();
           var refinedApplicant = Mapper.Map<ProgrammeLevel, DistanceLearningDomain.Model.ProgrammeLevel>(rawApplicant);
           return refinedApplicant;
       }

       public bool ConfirmProgrammeLevel(int LevId, int ProgId)
       {
           var rawApplicant = (from p in Context.ProgrammeLevels where p.ProgId == ProgId && p.LevId == LevId select p).Any();
           //var refinedApplicant = Mapper.Map<ProgrammeLevel, DistanceLearningDomain.Model.ProgrammeLevel>(rawApplicant);
           return rawApplicant;
       }


       public IEnumerable<DistanceLearningDomain.Model.ProgrammeLevel> GetAllProgrammeLevelByAward(int awardId)
       {
           var rawApplicant = (from p in Context.ProgrammeLevels where p.Programme.AwardId == awardId select p).ToList();
           var refinedApplicant = Mapper.Map<List<ProgrammeLevel>, List<DistanceLearningDomain.Model.ProgrammeLevel>>(rawApplicant);
           return refinedApplicant;
       }


       public IEnumerable<DistanceLearningDomain.Model.ProgrammeLevel> GetAllProgrammeLevelByFaculty(int facId)
       {
           var rawApplicant = (from p in Context.ProgrammeLevels where p.Programme.Department.FacId == facId select p).OrderBy(c=>c.ProgLevDescription).ToList();
           var refinedApplicant = Mapper.Map<List<ProgrammeLevel>, List<DistanceLearningDomain.Model.ProgrammeLevel>>(rawApplicant);
           return refinedApplicant;
       }

       public IEnumerable<DistanceLearningDomain.Model.ProgrammeLevel> GetAllProgrammeLevelByFaculty(int facId, int levId)
       {
           var rawApplicant = (from p in Context.ProgrammeLevels where p.Programme.Department.FacId == facId && p.LevId==levId select p).ToList();
           var refinedApplicant = Mapper.Map<List<ProgrammeLevel>, List<DistanceLearningDomain.Model.ProgrammeLevel>>(rawApplicant);
           return refinedApplicant;
       }
    }
}
