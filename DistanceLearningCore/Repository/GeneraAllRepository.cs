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
    public class GeneraAllRepository : Repository<DistanceLearningDomain.Model.GenralAll,GenralAll>, IGeneralAllRepository
    {
        private ElearningPayEntities Context;
        public GeneraAllRepository(ElearningPayEntities Context)
            :base(Context)
        {
            Mapper.CreateMap<DistanceLearningDomain.Model.GenralAll, GenralAll>();
            Mapper.CreateMap<GenralAll, DistanceLearningDomain.Model.GenralAll>();
            this.Context = Context;   
        }
      
        public IEnumerable<DistanceLearningDomain.Model.GenralAll> GetGenralAll()
        {
            var rawApplicant = (from c in Context.PaymentConfigurations.OfType<GenralAll>() select c).ToList();
            var refinedApplicant = Mapper.Map<List<GenralAll>, List<DistanceLearningDomain.Model.GenralAll>>(rawApplicant);
            return refinedApplicant;
        }
        public bool ConfirmGenralAll(int Id)
        {
            var rawApplicant = (from c in Context.PaymentConfigurations.OfType<GenralAll>()  where c.Id==Id select c).Any();
            return rawApplicant;
        }
        public IEnumerable<DistanceLearningDomain.Model.GenralAll> GetAllGenralAll(int awardId)
        {
            var rawApplicant = (from c in Context.PaymentConfigurations.OfType<GenralAll>() where c.AwardId == awardId select c).ToList();
            var refinedApplicant = Mapper.Map<List<GenralAll>, List<DistanceLearningDomain.Model.GenralAll>>(rawApplicant);
            return refinedApplicant;
        }

        DistanceLearningDomain.Model.GenralAll IGeneralAllRepository.GetGenralAllById(int Id)
        {
            var rawApplicant = (from c in Context.PaymentConfigurations.OfType<GenralAll>() where c.Id == Id select c).FirstOrDefault();
            var refinedApplicant = Mapper.Map<GenralAll, DistanceLearningDomain.Model.GenralAll>(rawApplicant);
            return refinedApplicant;
        }


        public IEnumerable<DistanceLearningDomain.Model.GenralAll> GetAllGenralAllByPayment(int payId)
        {
            var rawApplicant = (from c in Context.PaymentConfigurations.OfType<GenralAll>() where c.catId == payId select c).ToList();
            var refinedApplicant = Mapper.Map<List<GenralAll>, List<DistanceLearningDomain.Model.GenralAll>>(rawApplicant);
            return refinedApplicant;
        }

        public bool ConfirmGenralAll(int awardId, int PayId)
        {
            var rawApplicant = (from c in Context.PaymentConfigurations.OfType<GenralAll>() where c.catId==PayId && c.AwardId==awardId select c).Any();
            //var refinedApplicant = Mapper.Map<GenralAll, DistanceLearningDomain.Model.GenralAll>(rawApplicant);
            return rawApplicant;
        }

        public DistanceLearningDomain.Model.GenralAll GetGenralAllById(int awardId, int PayId)
        {
            var rawApplicant = (from c in Context.PaymentConfigurations.OfType<GenralAll>() where c.catId == PayId && c.AwardId == awardId select c).FirstOrDefault();
            var refinedApplicant = Mapper.Map<GenralAll, DistanceLearningDomain.Model.GenralAll>(rawApplicant);
            return refinedApplicant;
        }
    }
}
