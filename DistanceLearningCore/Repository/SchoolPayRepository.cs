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
    public class SchoolPayRepository : Repository<DistanceLearningDomain.Model.SchoolPayment,SchoolPayment>, ISchoolPayment
    {
        private ElearningPayEntities Context;
        public SchoolPayRepository(ElearningPayEntities Context)
            :base(Context)
        {
            Mapper.CreateMap<DistanceLearningDomain.Model.SchoolPayment, SchoolPayment>();
            Mapper.CreateMap<SchoolPayment, DistanceLearningDomain.Model.SchoolPayment>();
            this.Context = Context;   
        }

        public IEnumerable<DistanceLearningDomain.Model.SchoolPayment> GetAllSchoolFee()
        {
            var rawApplicant = (from c in Context.Payments.OfType<SchoolPayment>() select c).ToList();
            var refinedApplicant = Mapper.Map<List<SchoolPayment>, List<DistanceLearningDomain.Model.SchoolPayment>>(rawApplicant);
            return refinedApplicant;
        }

        public bool ConfirmSchoolFee(string payDescription)
        {
            var rawApplicant = (from c in Context.Payments where c.PaymentDescription.ToLower() == payDescription.ToLower() && c is SchoolPayment select c).Any();
            return rawApplicant;
        }

        public bool ConfirmSchoolFee(int Id)
        {
            var rawApplicant = (from c in Context.Payments where c.Id == Id && c is SchoolPayment select c).Any();
            return rawApplicant;
        }

        public DistanceLearningDomain.Model.SchoolPayment GetSchoolFee(string paDescription)
        {
            var rawApplicant = (from c in Context.Payments.OfType<SchoolPayment>() where c.SchDescription.ToLower() == paDescription.ToLower() select c).FirstOrDefault();
            var refinedApplicant = Mapper.Map<SchoolPayment, DistanceLearningDomain.Model.SchoolPayment>(rawApplicant);
            return refinedApplicant;
        }
        public DistanceLearningDomain.Model.SchoolPayment GetSchoolFee(int Id)
        {
            var rawApplicant = (from c in Context.Payments.OfType<SchoolPayment>() where c.Id == Id select c).FirstOrDefault();
            var refinedApplicant = Mapper.Map<SchoolPayment, DistanceLearningDomain.Model.SchoolPayment>(rawApplicant);
            return refinedApplicant;
        }
    }
}
