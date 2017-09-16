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
    public class ProgrammeRepository : Repository<DistanceLearningDomain.Model.Programme,ProgrammeAdmin>,IProgrammeRepository
    {
        private ElearningAdminEntities Context;
        public ProgrammeRepository(ElearningAdminEntities Context)
            :base(Context)
        {
            Mapper.CreateMap<DistanceLearningDomain.Model.Programme, ProgrammeAdmin>();
            Mapper.CreateMap<ProgrammeAdmin, DistanceLearningDomain.Model.Programme>();
            this.Context = Context;   
        }
       
        public bool ConfirmAwardByAcronyms(string acronyms)
        {
            var rawApplicant = (from c in Context.Awards where c.AwardAcronymns.ToLower()==acronyms.ToLower() select c).Any();
            return rawApplicant;
        }

        public IEnumerable<DistanceLearningDomain.Model.Cours> GetAllCourseInDepartment(int deptId)
        {
            var rawApplicant = (from c in Context.Courses where c.deptId == deptId select c).ToList();
            var refinedApplicant = Mapper.Map<List<Cours>, List<DistanceLearningDomain.Model.Cours>>(rawApplicant);
            return refinedApplicant;
        }

        public IEnumerable<DistanceLearningDomain.Model.Cours> GetAllCourseInFaculty(int deptId)
        {
            var rawApplicant = (from c in Context.Courses where c.Department.FacId == deptId select c).ToList();
            var refinedApplicant = Mapper.Map<List<Cours>, List<DistanceLearningDomain.Model.Cours>>(rawApplicant);
            return refinedApplicant;
        }

        public DistanceLearningDomain.Model.Cours GetCourse(string CourseCode)
        {
            var rawApplicant = (from c in Context.Courses where c.CourseCode.ToLower()==CourseCode.ToLower() select c).FirstOrDefault();
            var refinedApplicant = Mapper.Map<Cours, DistanceLearningDomain.Model.Cours>(rawApplicant);
            return refinedApplicant;
        }

        public bool ConfirmCourseByCode(string CourseCode)
        {
            var rawApplicant = (from c in Context.Courses where c.CourseCode.ToLower() == CourseCode.ToLower() select c).Any();
            return rawApplicant;
        }

        public bool ConfirmCourseByTitle(string description)
        {
            var rawApplicant = (from c in Context.Courses where c.CourseTitle.ToLower() == description.ToLower() select c).Any();
            return rawApplicant;
        }

        public IEnumerable<DistanceLearningDomain.Model.Programme> GetAllProgrammeInDepartment(int deptId)
        {
            var rawApplicant = (from c in Context.ProgrammeAdmins where c.DeptID == deptId select c).ToList();
            var refinedApplicant = Mapper.Map<List<ProgrammeAdmin>, List<DistanceLearningDomain.Model.Programme>>(rawApplicant);
            return refinedApplicant;
        }
        public IEnumerable<DistanceLearningDomain.Model.Programme> GetAllProgrammeInFaculty(int facId)
        {
            var rawApplicant = (from c in Context.ProgrammeAdmins where c.Department.FacId == facId select c).ToList();
            var refinedApplicant = Mapper.Map<List<ProgrammeAdmin>, List<DistanceLearningDomain.Model.Programme>>(rawApplicant);
            return refinedApplicant;
        }
        public IEnumerable<DistanceLearningDomain.Model.Programme> GetAllCourseByAward(int awardId)
        {
            var rawApplicant = (from c in Context.ProgrammeAdmins where c.AwardId == awardId select c).ToList();
            var refinedApplicant = Mapper.Map<List<ProgrammeAdmin>, List<DistanceLearningDomain.Model.Programme>>(rawApplicant);
            return refinedApplicant;
        }
        public DistanceLearningDomain.Model.Programme GetProgramme(int awardId, int deptId)
        {
            var rawApplicant = (from c in Context.ProgrammeAdmins where c.AwardId == awardId && c.DeptID==deptId select c).FirstOrDefault();
            var refinedApplicant = Mapper.Map<ProgrammeAdmin, DistanceLearningDomain.Model.Programme>(rawApplicant);
            return refinedApplicant;
        }
        public bool ConfirmPogrammeByCode(string ProgrammeCode)
        {
            var rawApplicant = (from c in Context.ProgrammeAdmins where c.ProgrammeCode.ToLower() == ProgrammeCode.ToLower() select c).Any();
            return rawApplicant;
        }
        public bool ConfirmProgrammeByDescription(string description)
        {
            var rawApplicant = (from c in Context.ProgrammeAdmins where c.ProgrammeDescription.ToLower() == description.ToLower() select c).Any();
            return rawApplicant;
        }


        public DistanceLearningDomain.Model.Programme GetStudentProgramme(string matNo)
        {
            var rawApplicant = (from c in Context.Students from d in c.StudentLevels where  c.MatricNo.ToLower()==matNo.ToLower() select d.StudentCatLevel.ProgrammeLevel.Programme).FirstOrDefault();
            var refinedApplicant = Mapper.Map<ProgrammeAdmin, DistanceLearningDomain.Model.Programme>(rawApplicant);
            return refinedApplicant;
        }
    }
}
