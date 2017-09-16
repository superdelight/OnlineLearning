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
    public class CourseRoleRepository : Repository<DistanceLearningDomain.Model.CourseRole,CourseRole>,ICourseRoleRepository
    {
        private ElearningAdminEntities Context;
        public CourseRoleRepository(ElearningAdminEntities Context)
            :base(Context)
        {
            Mapper.CreateMap<DistanceLearningDomain.Model.CourseRole, CourseRole>();
            Mapper.CreateMap<CourseRole, DistanceLearningDomain.Model.CourseRole>();
            this.Context = Context;   
        }
        public bool ConfirmCourseRole(string detail)
        {
            var rawApplicant = (from c in Context.CourseRoles where c.Description.ToLower() == detail.ToLower() select c).Any();
            return rawApplicant;
        }
        public DistanceLearningDomain.Model.CourseRole GetCourseRole(string detail)
        {
            var rawApplicant = Context.CourseRoles.Where(c => c.Description.Trim().ToLower().Equals(detail.Trim().ToLower())).FirstOrDefault();
            var refinedApplicant = Mapper.Map<CourseRole, DistanceLearningDomain.Model.CourseRole>(rawApplicant);
            return refinedApplicant;
        }
    }
}
