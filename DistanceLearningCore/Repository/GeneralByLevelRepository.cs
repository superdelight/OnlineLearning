using AutoMapper;
using DistanceLearningCore.Model.Payment;
using DistanceLearningCore.Model.StaffModel;
using DistanceLearningDomain.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace DistanceLearningCore.Repository
{
    public class GeneralByLevelRepository : Repository<DistanceLearningDomain.Model.GeneralByLevel, GeneralByLevel>, IGeneralByLevelRepository
    {
        private ElearningPayEntities Context;
        public GeneralByLevelRepository(ElearningPayEntities Context)
            :base(Context)
        {
            Mapper.CreateMap<DistanceLearningDomain.Model.GeneralByLevel, GeneralByLevel>();
            Mapper.CreateMap<GeneralByLevel, DistanceLearningDomain.Model.GeneralByLevel>();
            this.Context = Context;   
        }
       
        public IEnumerable<DistanceLearningDomain.Model.GeneralByLevel> GetGeneralByLevel()
        {
            var rawApplicant = (from c in Context.PaymentConfigurations.OfType<GeneralByLevel>() select c).ToList();
            var refinedApplicant = Mapper.Map<List<GeneralByLevel>, List<DistanceLearningDomain.Model.GeneralByLevel>>(rawApplicant);
            return refinedApplicant;
        }

        public IEnumerable<DistanceLearningDomain.Model.GeneralByLevel> GetGeneralByLevel(int levId)
        {
            var rawApplicant = (from c in Context.PaymentConfigurations.OfType<GeneralByLevel>()  where c.LevId==levId select c).ToList();
            var refinedApplicant = Mapper.Map<List<GeneralByLevel>, List<DistanceLearningDomain.Model.GeneralByLevel>>(rawApplicant);
            return refinedApplicant;
        }

        public IEnumerable<DistanceLearningDomain.Model.GeneralByLevel> GetGeneralByLevelByAward(int awardId)
        {
            var rawApplicant = (from c in Context.PaymentConfigurations.OfType<GeneralByLevel>() where c.AwardId == awardId select c).ToList();
            var refinedApplicant = Mapper.Map<List<GeneralByLevel>, List<DistanceLearningDomain.Model.GeneralByLevel>>(rawApplicant);
            return refinedApplicant;
        }


        public bool ConfirmGeneralByLevel(int levId, int awardId)
        {
            var rawApplicant = (from c in Context.PaymentConfigurations.OfType<GeneralByLevel>() where c.AwardId == awardId  && c.LevId==levId select c).Any();
                      return rawApplicant;
        }
   
        public DistanceLearningDomain.Model.GeneralByLevel GetGeneralByLevel(int levId, int awardId)
        {
            var rawApplicant = (from c in Context.PaymentConfigurations.OfType<GeneralByLevel>() where c.LevId == levId && c.AwardId==awardId select c).FirstOrDefault();
            var refinedApplicant = Mapper.Map<GeneralByLevel, DistanceLearningDomain.Model.GeneralByLevel>(rawApplicant);
            return refinedApplicant;
        }
        public bool ConfirmGeneralByLevel(int Id)
        {
            var rawApplicant = (from c in Context.PaymentConfigurations.OfType<GeneralByLevel>() where c.Id == Id select c).Any();
            //var refinedApplicant = Mapper.Map<GeneralByLevel, DistanceLearningDomain.Model.GeneralByLevel>(rawApplicant);
            return rawApplicant;
        }
        public GeneralByLevel GetGeneralByLevelById(int Id)
        {
            var rawApplicant = (from c in Context.PaymentConfigurations.OfType<GeneralByLevel>() where c.Id == Id select c).FirstOrDefault();
            var refinedApplicant = Mapper.Map<GeneralByLevel, DistanceLearningDomain.Model.GeneralByLevel>(rawApplicant);
            return rawApplicant;
        }


        DistanceLearningDomain.Model.GeneralByLevel IGeneralByLevelRepository.GetGeneralByLevelById(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
