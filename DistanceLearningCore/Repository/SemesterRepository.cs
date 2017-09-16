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
    public class SemesterRepository : Repository<DistanceLearningDomain.Model.Semester,Semester>,ISemesterRepository
    {
        private ElearningAdminEntities Context;
        public SemesterRepository(ElearningAdminEntities Context)
            :base(Context)
        {
            Mapper.CreateMap<DistanceLearningDomain.Model.Semester, Semester>();
            Mapper.CreateMap<Semester, DistanceLearningDomain.Model.Semester>();
            this.Context = Context;   
        }
    
        public IEnumerable<DistanceLearningDomain.Model.Semester> GetAllSemester()
        {
            var semester = Context.Semesters.ToList();
            if (semester.Count <= 0)
            {
                semester = new List<Semester>();
                semester.Add(new Semester() { Description = "Harmattan" });
                semester.Add(new Semester() { Description = "Rain" });
                Context.Semesters.AddRange(semester);
                Context.SaveChanges();
                semester = Context.Semesters.ToList();
            }

           
            var refinedApplicant = Mapper.Map<List<Semester>, List<DistanceLearningDomain.Model.Semester>>(semester);
            return refinedApplicant;
        }
    }
}
