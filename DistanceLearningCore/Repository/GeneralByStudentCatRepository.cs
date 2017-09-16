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
    public class GeneralByStudentCatRepository : Repository<DistanceLearningDomain.Model.GeneralByStudCat, GeneralByStudCat>, IGeneralByStudCatRepository

    {
        private ElearningPayEntities Context;
        public GeneralByStudentCatRepository(ElearningPayEntities Context)
            :base(Context)
        {
            Mapper.CreateMap<DistanceLearningDomain.Model.GeneralByStudCat, GeneralByStudCat>();
            Mapper.CreateMap<GeneralByStudCat, DistanceLearningDomain.Model.GeneralByStudCat>();
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


          public IEnumerable<DistanceLearningDomain.Model.GeneralByStudCat> GetGeneralByStudCat()
        {
            var rawApplicant = (from c in Context.PaymentConfigurations.OfType<GeneralByStudCat>() select c).ToList();
            var refinedApplicant = Mapper.Map<List<GeneralByStudCat>, List<DistanceLearningDomain.Model.GeneralByStudCat>>(rawApplicant);
            return refinedApplicant;
        }

        public IEnumerable<DistanceLearningDomain.Model.GeneralByStudCat> GetGeneralByStudCat(int studCatId)
        {
            var rawApplicant = (from c in Context.PaymentConfigurations.OfType<GeneralByStudCat>() where c.catId==studCatId select c).ToList();
            var refinedApplicant = Mapper.Map<List<GeneralByStudCat>, List<DistanceLearningDomain.Model.GeneralByStudCat>>(rawApplicant);
            return refinedApplicant;
        }

        public IEnumerable<DistanceLearningDomain.Model.GeneralByStudCat> GetGeneralGeneralByStudCatByAward(int awardId)
        {
            var rawApplicant = (from c in Context.PaymentConfigurations.OfType<GeneralByStudCat>() where c.AwardId == awardId select c).ToList();
            var refinedApplicant = Mapper.Map<List<GeneralByStudCat>, List<DistanceLearningDomain.Model.GeneralByStudCat>>(rawApplicant);
            return refinedApplicant;
        }

        public bool ConfirmGeneralByStudCat(int catId, int awardId)
        {
            var rawApplicant = (from c in Context.PaymentConfigurations.OfType<GeneralByStudCat>() where c.AwardId == awardId && c.catId==catId select c).Any();
           // var refinedApplicant = Mapper.Map<List<GeneralByStudCat>, List<DistanceLearningDomain.Model.GeneralByStudCat>>(rawApplicant);
            return rawApplicant;
        }

        public DistanceLearningDomain.Model.GeneralByStudCat GetGeneralByStudCatById(int Id)
        {
            var rawApplicant = (from c in Context.PaymentConfigurations.OfType<GeneralByStudCat>() where c.Id==Id select c).FirstOrDefault();
            var refinedApplicant = Mapper.Map<GeneralByStudCat, DistanceLearningDomain.Model.GeneralByStudCat>(rawApplicant);
            return refinedApplicant;
        }

        public DistanceLearningDomain.Model.GeneralByStudCat GetGeneralByStudCat(int catId, int awardId)
        {
            var rawApplicant = (from c in Context.PaymentConfigurations.OfType<GeneralByStudCat>() where c.catId == catId && c.AwardId==awardId select c).FirstOrDefault();
            var refinedApplicant = Mapper.Map<GeneralByStudCat, DistanceLearningDomain.Model.GeneralByStudCat>(rawApplicant);
            return refinedApplicant;
        }
    }
}
