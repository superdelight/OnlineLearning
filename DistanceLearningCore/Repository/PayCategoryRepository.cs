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
    public class PayCategoryRepository : Repository<DistanceLearningDomain.Model.PayCategory,PayCategory>, IPayCategory
    {
        private ElearningPayEntities Context;
        public PayCategoryRepository(ElearningPayEntities Context)
            :base(Context)
        {
            Mapper.CreateMap<DistanceLearningDomain.Model.PayCategory, PayCategory>();
            Mapper.CreateMap<PayCategory, DistanceLearningDomain.Model.PayCategory>();
            this.Context = Context;   
        }
       
        public override IEnumerable<DistanceLearningDomain.Model.PayCategory> GetAll()
        {
            var rawApplicant = (from c in Context.PayCategories select c).ToList();
            var refinedApplicant = rawApplicant.Select(c => new DistanceLearningDomain.Model.PayCategory() { Id = c.Id, Description = c.Description,PayId= c.PayId }).ToList();
            return refinedApplicant;
        }
   
        public bool ConfirmPayCategory(string payDescription)
        {
            var rawApplicant = (from c in Context.PayCategories where c.Description.ToLower() == payDescription.ToLower() select c).Any();
            return rawApplicant; 
        }

        public DistanceLearningDomain.Model.PayCategory GetPayCategory(string paDescription)
        {
            var rawApplicant = (from c in Context.PayCategories where c.Description.ToLower() == paDescription.ToLower() select c).FirstOrDefault();
            var refinedApplicant = Mapper.Map<PayCategory, DistanceLearningDomain.Model.PayCategory>(rawApplicant);
            return refinedApplicant; 
        }
    }
}
