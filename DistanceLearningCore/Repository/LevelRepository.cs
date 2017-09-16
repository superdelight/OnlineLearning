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
    public class LevelRepository : Repository<DistanceLearningDomain.Model.Level,Level>,ILevelRepository
    {
        private ElearningAdminEntities Context;
        public LevelRepository(ElearningAdminEntities Context)
            :base(Context)
        {
            Mapper.CreateMap<DistanceLearningDomain.Model.Level, Level >();
            Mapper.CreateMap<Level, DistanceLearningDomain.Model.Level>();
            this.Context = Context;   
        }
       
        public bool ConfirmLevel(string detail)
        {
            var rawApplicant = (from c in Context.Levels where c.LevelDescription.ToLower() == detail.ToLower() select c).Any();
            return rawApplicant;
        }

        public DistanceLearningDomain.Model.Level GetLevel(string detail)
        {
            var rawApplicant = (from c in Context.Levels where c.LevelDescription.ToLower() == detail.ToLower() select c).FirstOrDefault();
            var refinedApplicant = Mapper.Map<Level, DistanceLearningDomain.Model.Level>(rawApplicant);
            return refinedApplicant;
        }


        public DistanceLearningDomain.Model.Level GetLevelFromStudentLevel(int studId)
        {
            var rawApplicant = (from c in Context.Levels from d in c.ProgrammeLevels  from m in d.StudentCatLevels  from k in m.StudentLevels where k.Id==studId select c).FirstOrDefault();
            var refinedApplicant = Mapper.Map<Level, DistanceLearningDomain.Model.Level>(rawApplicant);
            return refinedApplicant;
        }
    }
}
