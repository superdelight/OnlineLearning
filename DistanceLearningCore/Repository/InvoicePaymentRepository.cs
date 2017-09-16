using AutoMapper;
using DistanceLearningCore.Model.Payment;
using DistanceLearningDomain.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace DistanceLearningCore.Repository
{
    public class InvoicePaymentRepository : Repository<DistanceLearningDomain.Model.InvoicePayment, InvoicePayment>, IInvoicePaymentRepository
    {
        private ElearningPayEntities Context;
        public InvoicePaymentRepository(ElearningPayEntities Context)
            :base(Context)
        {
            Mapper.CreateMap<DistanceLearningDomain.Model.InvoicePayment, InvoicePayment>();
            Mapper.CreateMap<InvoicePayment, DistanceLearningDomain.Model.InvoicePayment>();
            this.Context = Context;   
        }


      
        public IEnumerable<DistanceLearningDomain.Model.InvoicePayment> GetAllInvoicePayment(int invoiceId)
        {
            var rawApplicant = (from c in Context.InvoicePayments where c.InvoiceId == invoiceId select c).ToList();
            var refinedApplicant = Mapper.Map<List<InvoicePayment>, List<DistanceLearningDomain.Model.InvoicePayment>>(rawApplicant);
            return refinedApplicant;
        }

        public IEnumerable<DistanceLearningDomain.Model.InvoicePayment> GetAllInvoicePaymentByPay(int PayId)
        {
            var rawApplicant = (from c in Context.InvoicePayments where c.PayId == PayId select c).ToList();
            var refinedApplicant = Mapper.Map<List<InvoicePayment>, List<DistanceLearningDomain.Model.InvoicePayment>>(rawApplicant);
            return refinedApplicant;
        }

        public IEnumerable<DistanceLearningDomain.Model.InvoicePayment> GetAllInvoicePaymentBySessionSem(int sessId)
        {
            var rawApplicant = (from c in Context.InvoicePayments where c.SessId == sessId select c).ToList();
            var refinedApplicant = Mapper.Map<List<InvoicePayment>, List<DistanceLearningDomain.Model.InvoicePayment>>(rawApplicant);
            return refinedApplicant;
        }

        public IEnumerable<DistanceLearningDomain.Model.InvoicePayment> GetAllInvoicePaymentByStudentLevel(int levelId)
        {
            var rawApplicant = (from c in Context.InvoicePayments where c.Invoice.StudLevId == levelId select c).ToList();
            var refinedApplicant = Mapper.Map<List<InvoicePayment>, List<DistanceLearningDomain.Model.InvoicePayment>>(rawApplicant);
            return refinedApplicant;
        }

        public IEnumerable<DistanceLearningDomain.Model.InvoicePayment> GetAllInvoicePaymentByStudent(string matricNo)
        {
            var rawApplicant = (from c in Context.InvoicePayments where c.Invoice.StudentLevel.Student.MatricNo.ToLower() == matricNo.ToLower() select c).ToList();
            var refinedApplicant = Mapper.Map<List<InvoicePayment>, List<DistanceLearningDomain.Model.InvoicePayment>>(rawApplicant);
            return refinedApplicant;
        }

        public DistanceLearningDomain.Model.InvoicePayment GetSingleInvoicePaymentByStudent(int studId, int PayId)
        {
            var rawApplicant = (from c in Context.InvoicePayments where c.Invoice.StudLevId==studId && c.PayId==PayId select c).FirstOrDefault();
            var refinedApplicant = Mapper.Map<InvoicePayment, DistanceLearningDomain.Model.InvoicePayment>(rawApplicant);
            return refinedApplicant;
        }

        public bool ConfirmInvoicePayment(int invoice, int PayId)
        {
            var rawApplicant = (from c in Context.InvoicePayments where c.Invoice.Id == invoice && c.PayId == PayId select c).Any();
           // var refinedApplicant = Mapper.Map<InvoicePayment, DistanceLearningDomain.Model.InvoicePayment>(rawApplicant);
            return rawApplicant;
        }
        public bool ConfirmInvoicePayment(string matNo, int PayId)
        {
            var rawApplicant = (from c in Context.InvoicePayments where c.Invoice.StudentLevel.Student.MatricNo.ToLower() == matNo.ToLower() && c.PayId == PayId select c).Any();
            // var refinedApplicant = Mapper.Map<InvoicePayment, DistanceLearningDomain.Model.InvoicePayment>(rawApplicant);
            return rawApplicant;
        }

        public IEnumerable<DistanceLearningDomain.Model.InvoicePayment> GetAllInvoicePaymentByStudent(string matricNo, int PayId)
        {
            throw new NotImplementedException();
        }
    }
}
