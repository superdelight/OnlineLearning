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
    public class FacultyRepository : Repository<DistanceLearningDomain.Model.Faculty,Faculty>,IFacultyRepository
    {
        private ElearningAdminEntities Context;
        public FacultyRepository(ElearningAdminEntities Context)
            :base(Context)
        {
            Mapper.CreateMap<DistanceLearningDomain.Model.Faculty, Faculty>();
            Mapper.CreateMap<Faculty, DistanceLearningDomain.Model.Faculty>();
            this.Context = Context;   
        }
        public DistanceLearningDomain.Model.Faculty GetFaculty(string facCode)
        {
            var rawApplicant = Context.Faculties.Where(c=>c.FacultyAcronymns.Trim().ToLower()==facCode.Trim().ToLower()).FirstOrDefault();
            var refinedApplicant = Mapper.Map<Faculty, DistanceLearningDomain.Model.Faculty>(rawApplicant);
            return refinedApplicant;
        }
        public bool ConfirmFacultyByAcronyms(string acronyms)
        {
            var rawApplicant = Context.Faculties.Where(c => c.FacultyAcronymns.Trim().ToLower() == acronyms.Trim().ToLower()).Any();
            return rawApplicant;
        }

        public bool ConfirmFacultyByDescription(string description)
        {
            var rawApplicant = Context.Faculties.Where(c => c.FacultyName.Trim().ToLower() == description.Trim().ToLower()).Any();
            return rawApplicant;
        }


        public DistanceLearningDomain.Model.Faculty GetFacultyByMatricNo(string MatNo)
        {
      
            //var rawApplicant = ( from t in Context.Faculties 
            //                     from c in t.Departments from d in c.Programmes 
            //                     from m in d.ProgrammeLevels from n in m.StudentCatLevels 
            //                     from k in n.StudentLevels  where k.Student.MatricNo.ToLower()==MatNo.ToLower() select t).FirstOrDefault();
            var rawApplicant = (from c in Context.Students from d in c.StudentLevels where c.MatricNo.ToLower() == MatNo.ToLower() select d.StudentCatLevel.ProgrammeLevel.Programme.Department.Faculty).FirstOrDefault();
            var refinedApplicant = Mapper.Map<Faculty, DistanceLearningDomain.Model.Faculty>(rawApplicant);
            return refinedApplicant;
        
        }
    }
}
