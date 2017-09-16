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
    public class GeneralByFacultyRepository : Repository<DistanceLearningDomain.Model.GeneralByFaculty,GeneralByFaculty>, IGeneralFacultyRepository
    {
        private ElearningPayEntities Context;
        public GeneralByFacultyRepository(ElearningPayEntities Context)
            :base(Context)
        {
            Mapper.CreateMap<DistanceLearningDomain.Model.GeneralByFaculty, GeneralByFaculty>();
            Mapper.CreateMap<GeneralByFaculty, DistanceLearningDomain.Model.GeneralByFaculty>();
            this.Context = Context;   
        }
      
        public IEnumerable<DistanceLearningDomain.Model.GenralAll> GetGenralAll()
        {
            var rawApplicant = (from c in Context.PaymentConfigurations.OfType<GenralAll>() select c).ToList();
            var refinedApplicant = Mapper.Map<List<GenralAll>, List<DistanceLearningDomain.Model.GenralAll>>(rawApplicant);
            return refinedApplicant;
        }
    
        DistanceLearningDomain.Model.GeneralByFaculty GetGenralAllById(int Id)
        {
            var rawApplicant = (from c in Context.PaymentConfigurations.OfType<GeneralByFaculty>() where c.Id == Id select c).FirstOrDefault();
            var refinedApplicant = Mapper.Map<GeneralByFaculty, DistanceLearningDomain.Model.GeneralByFaculty>(rawApplicant);
            return refinedApplicant;
        }

        public IEnumerable<DistanceLearningDomain.Model.GeneralByFaculty> GetGeneralByFaculty()
        {
            var rawApplicant = (from c in Context.PaymentConfigurations.OfType<GeneralByFaculty>() select c).ToList();
            var refinedApplicant = Mapper.Map<List<GeneralByFaculty>, List<DistanceLearningDomain.Model.GeneralByFaculty>>(rawApplicant);
            return refinedApplicant;
        }

        public IEnumerable<DistanceLearningDomain.Model.GeneralByFaculty> GetAllGeneralByPayment(int payId)
        {
            var rawApplicant = (from c in Context.PaymentConfigurations.OfType<GeneralByFaculty>() where c.catId == payId select c).ToList();
            var refinedApplicant = Mapper.Map<List<GeneralByFaculty>, List<DistanceLearningDomain.Model.GeneralByFaculty>>(rawApplicant);
            return refinedApplicant;
        }

        public IEnumerable<DistanceLearningDomain.Model.GeneralByFaculty> GetAllGeneralAll(int awardId)
        {
            var rawApplicant = (from c in Context.PaymentConfigurations.OfType<GeneralByFaculty>() where c.AwardId == awardId select c).ToList();
            var refinedApplicant = Mapper.Map<List<GeneralByFaculty>, List<DistanceLearningDomain.Model.GeneralByFaculty>>(rawApplicant);
            return refinedApplicant;
        }

        public bool ConfirmGenralAll(int awardId, int PayId, int FacId)
        {
            var rawApplicant = (from c in Context.PaymentConfigurations.OfType<GeneralByFaculty>() where c.AwardId == awardId && c.catId==PayId && c.FacId==FacId select c).Any();
            //var refinedApplicant = Mapper.Map<List<GeneralByFaculty>, List<DistanceLearningDomain.Model.GeneralByFaculty>>(rawApplicant);
            return rawApplicant;
        }

        public DistanceLearningDomain.Model.GeneralByFaculty GetGeneralByFacultyUsingId(int Id)
        {
            var rawApplicant = (from c in Context.PaymentConfigurations.OfType<GeneralByFaculty>() where c.Id == Id select c).FirstOrDefault();
            var refinedApplicant = Mapper.Map<GeneralByFaculty, DistanceLearningDomain.Model.GeneralByFaculty>(rawApplicant);
            return refinedApplicant;
        }

        public DistanceLearningDomain.Model.GeneralByFaculty GetGeneralByFaculty(int awardId, int PayId, int facId)
        {
            var rawApplicant = (from c in Context.PaymentConfigurations.OfType<GeneralByFaculty>() where c.AwardId == awardId && c.catId == PayId && c.FacId == facId select c).FirstOrDefault();
            var refinedApplicant = Mapper.Map<GeneralByFaculty, DistanceLearningDomain.Model.GeneralByFaculty>(rawApplicant);
            return refinedApplicant;
        }


        public bool ConfirmGenralAll(int Id)
        {
            var rawApplicant = (from c in Context.PaymentConfigurations.OfType<GeneralByFaculty>() where c.Id ==Id select c).Any();
            //var refinedApplicant = Mapper.Map<List<GeneralByFaculty>, List<DistanceLearningDomain.Model.GeneralByFaculty>>(rawApplicant);
            return rawApplicant;
        }


        public DistanceLearningDomain.Model.GeneralByFaculty GetGeneralByFaculty(int awardId, int facId, bool? IsFull)
        {
            if (IsFull==true)
            {
                var rawApplicant = (from c in Context.PaymentConfigurations.OfType<GeneralByFaculty>() where c.AwardId == awardId && c.FacId == facId && c.PayCategory is SessionPayment select c).FirstOrDefault();
                var refinedApplicant = Mapper.Map<GeneralByFaculty, DistanceLearningDomain.Model.GeneralByFaculty>(rawApplicant);
                return refinedApplicant;
            }
            else if(IsFull==false)
            {
               
                    var rawApplicant = (from c in Context.PaymentConfigurations.OfType<GeneralByFaculty>() where c.AwardId == awardId && c.FacId == facId && c.PayCategory is SessionSemPayment select c).OrderBy(p=>p.Id).FirstOrDefault();
                    var refinedApplicant = Mapper.Map<GeneralByFaculty, DistanceLearningDomain.Model.GeneralByFaculty>(rawApplicant);
                    return refinedApplicant;
            }
            else
            {
                var rawApplicant = (from c in Context.PaymentConfigurations.OfType<GeneralByFaculty>() where c.AwardId == awardId && c.FacId == facId && c.PayCategory is SessionSemPayment select c).OrderByDescending(p => p.Id).FirstOrDefault();
                var refinedApplicant = Mapper.Map<GeneralByFaculty, DistanceLearningDomain.Model.GeneralByFaculty>(rawApplicant);
                return refinedApplicant;
            }
        }


        public DistanceLearningDomain.Model.GeneralByFaculty GetGeneralByFacultyByDescription(string paymentDescription)
        {
            var rawApplicant = (from c in Context.PaymentConfigurations.OfType<GeneralByFaculty>() where c.PayDescription.ToLower()==paymentDescription.ToLower() select c).FirstOrDefault();
            var refinedApplicant = Mapper.Map<GeneralByFaculty, DistanceLearningDomain.Model.GeneralByFaculty>(rawApplicant);
            return refinedApplicant;
        }
        public IEnumerable<DistanceLearningDomain.Model.GeneralByFaculty> GetAllGeneralAll(int awardId, int sessId)
        {
            var rawApplicant = (from c in Context.PayCategories.OfType<SessionPayment>() from d in c.PaymentConfigurations.OfType<GeneralByFaculty>() where d.AwardId == awardId && c.SessId==sessId select d).ToList();
            //var rawApplicant = (from c in Context.PaymentConfigurations.OfType<GeneralByFaculty>() where c.AwardId == awardId && c.PayCategory select c).ToList();
            var refinedApplicant = Mapper.Map<List<GeneralByFaculty>, List<DistanceLearningDomain.Model.GeneralByFaculty>>(rawApplicant);
            return refinedApplicant;
        }


        public DistanceLearningDomain.Model.GeneralByFaculty GetGeneralByFaculty(int awardId, int facId, bool? IsFull, int sessId)
        {
            if (IsFull == true)
            {
                var rawApplicant = (from c in Context.PayCategories.OfType<SessionPayment>() from d in c.PaymentConfigurations.OfType<GeneralByFaculty>() where d.AwardId == awardId && d.FacId == facId && c.SessId==sessId && c.Description.ToLower().Contains("full")  select d).FirstOrDefault();
               // var rawApplicant = (from c in Context.PaymentConfigurations.OfType<GeneralByFaculty>() where c.AwardId == awardId && c.FacId == facId && c.PayCategory is SessionPayment select c).FirstOrDefault();
                var refinedApplicant = Mapper.Map<GeneralByFaculty, DistanceLearningDomain.Model.GeneralByFaculty>(rawApplicant);
                return refinedApplicant;
            }
            else if (IsFull == false)
            {
                var rawApplicant = (from c in Context.PayCategories.OfType<SessionPayment>() from d in c.PaymentConfigurations.OfType<GeneralByFaculty>() where d.AwardId == awardId && d.FacId == facId && c.SessId == sessId && c.Description.ToLower().Contains("part")  select d).FirstOrDefault();
                //var rawApplicant = (from c in Context.PaymentConfigurations.OfType<GeneralByFaculty>() where c.AwardId == awardId && c.FacId == facId && c.PayCategory is SessionSemPayment select c).OrderBy(p => p.Id).FirstOrDefault();
                var refinedApplicant = Mapper.Map<GeneralByFaculty, DistanceLearningDomain.Model.GeneralByFaculty>(rawApplicant);
                return refinedApplicant;
            }
            else
            {
                var rawApplicant = (from c in Context.PayCategories.OfType<SessionPayment>() from d in c.PaymentConfigurations.OfType<GeneralByFaculty>() where d.AwardId == awardId && d.FacId == facId && c.SessId == sessId && c.Description.ToLower().Contains("balance") select d).FirstOrDefault();
                //var rawApplicant = (from c in Context.PaymentConfigurations.OfType<GeneralByFaculty>() where c.AwardId == awardId && c.FacId == facId && c.PayCategory is SessionSemPayment select c).OrderByDescending(p => p.Id).FirstOrDefault();
                var refinedApplicant = Mapper.Map<GeneralByFaculty, DistanceLearningDomain.Model.GeneralByFaculty>(rawApplicant);
                return refinedApplicant;
            }
        }
    }
}
