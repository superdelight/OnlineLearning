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
    public class ApplicantProgessRepository :Repository<DistanceLearningDomain.Model.ApplicantProgress,ApplicantProgressxx>, IApplicantProgress
    {
       private  StudentElearningEntities Context;
       public ApplicantProgessRepository(StudentElearningEntities Context)
            :base(Context)
        {
            Mapper.CreateMap<DistanceLearningDomain.Model.ApplicantProgress, ApplicantProgressxx>();
            Mapper.CreateMap<ApplicantProgressxx, DistanceLearningDomain.Model.ApplicantProgress>();
            this.Context = Context;
        }
       public DistanceLearningDomain.Model.ApplicantProgress GetApplicantProgress(int stepId, int appId)
       {
           var rawApplicant = (from p in Context.ApplicantProgressxxes where  p.AppId==appId && p.StepId==stepId select p).FirstOrDefault();
           var refinedApplicant = Mapper.Map<ApplicantProgressxx, DistanceLearningDomain.Model.ApplicantProgress>(rawApplicant);
           return refinedApplicant;
       }

       public bool ConfirmApplicantProgress(int stepId, int appId)
       {
           var rawApplicant = (from p in Context.ApplicantProgressxxes where p.AppId == appId && p.StepId == stepId select p).Any();
           return rawApplicant;
       }
    }
}
