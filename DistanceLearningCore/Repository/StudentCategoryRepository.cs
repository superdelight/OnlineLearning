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
    public class StudentCategoryRepository : Repository<DistanceLearningDomain.Model.StudentCategory,StudentCategory>,IStudentCategoryRepository
    {
        private ElearningAdminEntities Context;
        public StudentCategoryRepository(ElearningAdminEntities Context)
            :base(Context)
        {
            Mapper.CreateMap<DistanceLearningDomain.Model.StudentCategory, StudentCategory >();
            Mapper.CreateMap<StudentCategory, DistanceLearningDomain.Model.StudentCategory>();
            this.Context = Context;   
        }

        public bool ConfirmStudentCategory(string detail)
        {
            var rawApplicant = (from c in Context.StudentCategories where c.Description.ToLower() == detail.ToLower() select c).Any();
            return rawApplicant;
        }

        public DistanceLearningDomain.Model.StudentCategory GetStudentCategory(string detail)
        {
            var rawApplicant = (from c in Context.StudentCategories where c.Description.ToLower() == detail.ToLower() select c).FirstOrDefault();
            var refinedApplicant = Mapper.Map<StudentCategory, DistanceLearningDomain.Model.StudentCategory>(rawApplicant);
            return refinedApplicant;
        }
    }
}
