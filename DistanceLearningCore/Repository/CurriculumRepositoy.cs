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
    public class CurriculumRepositoy : Repository<DistanceLearningDomain.Model.Curriculum, Curriculum>, ICurriculumRepository
    {
        private StudentElearningEntities Context;
        public CurriculumRepositoy(StudentElearningEntities Context)
            :base(Context)
        {
            Mapper.CreateMap<DistanceLearningDomain.Model.Curriculum, Curriculum>();
            Mapper.CreateMap<Curriculum, DistanceLearningDomain.Model.Curriculum>();
            this.Context = Context;   
        }
       
        public IEnumerable<DistanceLearningDomain.Model.Curriculum> GetAllCurriculum(int progLevId, int semID)
        {
            var rawApplicant = (from c in Context.Curricula from d in Context.Requirements.OfType<ProgrammeReq>() where d.Id== c.ReqId 
                                    && d.ProgId==progLevId && c.Requirement.SemId==semID select c).ToList();
            var refinedApplicant = Mapper.Map<List<Curriculum>, List<DistanceLearningDomain.Model.Curriculum>>(rawApplicant);
            return refinedApplicant;
        }

        public IEnumerable<DistanceLearningDomain.Model.Curriculum> GetAllCurriculum(int progLevId)
        {
            var rawApplicant = (from c in Context.Curricula
                                from d in Context.Requirements.OfType<ProgrammeReq>()
                                where d.Id == c.ReqId
                                    && d.ProgId == progLevId 
                                select c).ToList();
            var refinedApplicant = Mapper.Map<List<Curriculum>, List<DistanceLearningDomain.Model.Curriculum>>(rawApplicant);
            return refinedApplicant;
        }

        public DistanceLearningDomain.Model.Curriculum GetACurriculum(int progLevId, int semID, int CourseId)
        {
            var rawApplicant = (from c in Context.Curricula
                                from d in Context.Requirements.OfType<ProgrammeReq>()
                                where d.Id == c.ReqId
                                    && d.ProgId == progLevId && c.Requirement.SemId==semID && c.CourseId==CourseId
                                select c).FirstOrDefault();
            var refinedApplicant = Mapper.Map<Curriculum, DistanceLearningDomain.Model.Curriculum>(rawApplicant);
            return refinedApplicant;
        }

        public bool ConfirmCurriculum(int progLevId, int semID, int CourseId)
        {
            var rawApplicant = (from c in Context.Curricula
                                from d in Context.Requirements.OfType<ProgrammeReq>()
                                where d.Id == c.ReqId
                                    && d.ProgId == progLevId && c.Requirement.SemId == semID && c.CourseId == CourseId
                                select c).Any();
            
            return rawApplicant;
        }


        public IEnumerable<DistanceLearningDomain.Model.Curriculum> GetAllCurriculum(int progLevId, int semID, bool IsElective)
        {
            var rawApplicant = (from c in Context.Curricula
                                from d in Context.Requirements.OfType<ProgrammeReq>()
                                where d.Id == c.ReqId
                                    && d.ProgId == progLevId && c.Requirement.SemId == semID && d.IsElective==IsElective
                                select c).ToList();
            var refinedApplicant = Mapper.Map<List<Curriculum>, List<DistanceLearningDomain.Model.Curriculum>>(rawApplicant);
            return refinedApplicant;
        }


        public DistanceLearningDomain.Model.Curriculum GetACurriculum(int reqId, int CourseId)
        {
            var rawApplicant = (from c in Context.Curricula
                                where c.ReqId == reqId
                                    && c.CourseId == CourseId
                                select c).FirstOrDefault();
            var refinedApplicant = Mapper.Map<Curriculum, DistanceLearningDomain.Model.Curriculum>(rawApplicant);
            return refinedApplicant;
        }

        public bool ConfirmCurriculum(int reqId, int CourseId)
        {
            var rawApplicant = (from c in Context.Curricula
                                where c.ReqId == reqId
                                    && c.CourseId == CourseId
                                select c).Any();
            return rawApplicant;
        }


        public bool ConfirmCurriculumBrProg(int progLevId, int CourseId)
        {
            var rawApplicant = (from c in Context.Curricula
                                from d in Context.Requirements.OfType<ProgrammeReq>()
                                where d.Id == c.ReqId
                                    && d.ProgrammeLevel.ProgId == progLevId && c.CourseId==CourseId
                                select c).Any();
            return rawApplicant;
        }
    }
}
