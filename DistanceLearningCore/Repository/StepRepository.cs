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
    public class StepRepository : Repository<DistanceLearningDomain.Model.Step, Step>, IStepRepository
    {
        private ElearningAdminEntities Context;
        public StepRepository(ElearningAdminEntities Context)
            : base(Context)
        {
            Mapper.CreateMap<DistanceLearningDomain.Model.Step, Step>();
            Mapper.CreateMap<Step, DistanceLearningDomain.Model.Step>();
            this.Context = Context;
        }


        public bool ConfirmStep(string detail)
        {
            var rawApplicant = (from c in Context.Steps where c.Description.ToLower() == detail.ToLower() select c).Any();
            return rawApplicant;
        }

        public DistanceLearningDomain.Model.Step GetStep(string detail)
        {
            var rawApplicant = (from c in Context.Steps where c.Description.ToLower() == detail.ToLower() select c).FirstOrDefault();
            var refinedApplicant = Mapper.Map<Step, DistanceLearningDomain.Model.Step>(rawApplicant);
            return refinedApplicant;
        }


        public IEnumerable<DistanceLearningDomain.Model.Step> GetAllSteps(int appId)
        {
            var rawApplicant = (from c in Context.ApplicantProgresses  where c.AppId==appId select c.Step).ToList();
            var refinedApplicant = Mapper.Map<List<Step>, List<DistanceLearningDomain.Model.Step>>(rawApplicant);
            return refinedApplicant;
        }


        public DistanceLearningDomain.Model.Step GetStepByForce(string detail)
        {
            var rawApplicant = (from c in Context.Steps where c.Description.ToLower() == detail.ToLower() select c).FirstOrDefault();
            if(rawApplicant==null)
            {
                Step st=new Step();
                st.Description=detail;
                Context.Steps.Add(st);
                Context.SaveChanges();

                rawApplicant = (from c in Context.Steps where c.Description.ToLower() == detail.ToLower() select c).FirstOrDefault();
            }
            var refinedApplicant = Mapper.Map<Step, DistanceLearningDomain.Model.Step>(rawApplicant);
            return refinedApplicant;
        }
    }
}
