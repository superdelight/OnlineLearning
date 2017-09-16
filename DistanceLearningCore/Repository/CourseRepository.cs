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
    public class CourseRepository : Repository<DistanceLearningDomain.Model.Cours,Coursexx>,ICourseRepository
    {
        private StudentElearningEntities Context;
        public CourseRepository(StudentElearningEntities Context)
            :base(Context)
        {
            Mapper.CreateMap<DistanceLearningDomain.Model.Cours, Coursexx>();
            Mapper.CreateMap<Coursexx, DistanceLearningDomain.Model.Cours>();
            this.Context = Context;   
        }
       
        public bool ConfirmAwardByAcronyms(string acronyms)
        {
            var rawApplicant = (from c in Context.Awardxxes where c.AwardAcronymns.ToLower()==acronyms.ToLower() select c).Any();
            return rawApplicant;
        }

        public IEnumerable<DistanceLearningDomain.Model.Cours> GetAllCourseInDepartment(int deptId)
        {
            var rawApplicant = (from c in Context.Coursexxes where c.deptId == deptId select c).ToList();
            var refinedApplicant = Mapper.Map<List<Coursexx>, List<DistanceLearningDomain.Model.Cours>>(rawApplicant);
            return refinedApplicant;
        }

        public IEnumerable<DistanceLearningDomain.Model.Cours> GetAllCourseInFaculty(int deptId)
        {
            var rawApplicant = (from c in Context.Coursexxes where c.Department.FacId == deptId select c).ToList();
            var refinedApplicant = Mapper.Map<List<Coursexx>, List<DistanceLearningDomain.Model.Cours>>(rawApplicant);
            return refinedApplicant;
        }

        public DistanceLearningDomain.Model.Cours GetCourse(string CourseCode)
        {
            var rawApplicant = (from c in Context.Coursexxes where c.CourseCode.ToLower()==CourseCode.ToLower() select c).FirstOrDefault();
            var refinedApplicant = Mapper.Map<Coursexx, DistanceLearningDomain.Model.Cours>(rawApplicant);
            return refinedApplicant;
        }

        public bool ConfirmCourseByCode(string CourseCode)
        {
            var rawApplicant = (from c in Context.Coursexxes where c.CourseCode.ToLower() == CourseCode.ToLower() select c).Any();
            return rawApplicant;
        }

        public bool ConfirmCourseByTitle(string description)
        {
            var rawApplicant = (from c in Context.Coursexxes where c.CourseTitle.ToLower() == description.ToLower() select c).Any();
            return rawApplicant;
        }


        public IEnumerable<DistanceLearningDomain.Model.Cours> GetAllCourseInRequirement(int progLevId, int SemId, bool IsElective)
        {
            var rawApplicant = (from c in Context.Coursexxes
                                from d in Context.Requirements.OfType<ProgrammeReq>()
                                from m in c.Curricula
                                where m.ReqId == d.Id && d.ProgId == progLevId && d.SemId == SemId && d.IsElective == IsElective
                                select c).ToList();
            var refinedApplicant = Mapper.Map<List<Coursexx>, List<DistanceLearningDomain.Model.Cours>>(rawApplicant);
            return refinedApplicant;
        }

        public IEnumerable<DistanceLearningDomain.Model.Cours> GetAllCourseInRequirement(int progLevId, int SemId)
        {
            var rawApplicant = (from c in Context.Coursexxes
                                from d in Context.Requirements.OfType<ProgrammeReq>()
                                from m in c.Curricula
                                where m.ReqId == d.Id && d.ProgId == progLevId && d.SemId == SemId 
                                select c).ToList();
            var refinedApplicant = Mapper.Map<List<Coursexx>, List<DistanceLearningDomain.Model.Cours>>(rawApplicant);
            return refinedApplicant;
        }


        public DistanceLearningDomain.Model.Cours GetCourse(int CurrId)
        {
            var rawApplicant = (from c in Context.Curricula where c.Id==CurrId select c.Cours).FirstOrDefault();
            var refinedApplicant = Mapper.Map<Coursexx, DistanceLearningDomain.Model.Cours>(rawApplicant);
            return refinedApplicant;
        }
    }
}
