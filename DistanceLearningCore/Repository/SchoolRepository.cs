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
    public class SchoolRepository : Repository<DistanceLearningDomain.Model.School,School>,ISchoolRepository
    {
        private ElearningAdminEntities Context;
        public SchoolRepository(ElearningAdminEntities Context)
            :base(Context)
        {
            Mapper.CreateMap<DistanceLearningDomain.Model.School, School>();
            Mapper.CreateMap<School, DistanceLearningDomain.Model.School>();
            this.Context = Context;   
        }
         public DistanceLearningDomain.Model.School GetHostSchool()
        {
            var rawApplicant = (from c in Context.Schools select c).FirstOrDefault();
            var refinedApplicant = Mapper.Map<School, DistanceLearningDomain.Model.School>(rawApplicant);
            return refinedApplicant;
        }
    }
}
