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
    public class InvoiceRepository : Repository<DistanceLearningDomain.Model.Invoice,Invoice>,IInvoiceRepository
    {
        private ElearningPayEntities Context;
        public InvoiceRepository(ElearningPayEntities Context)
            :base(Context)
        {
            Mapper.CreateMap<DistanceLearningDomain.Model.Invoice, Invoice>();
            Mapper.CreateMap<Invoice, DistanceLearningDomain.Model.Invoice>();
            this.Context = Context;   
        }


        public IEnumerable<DistanceLearningDomain.Model.Invoice> GetAllInvoice(int PayId)
        {
            var rawApplicant = (from c in Context.Invoices where c.PayId==PayId select c).ToList();
            var refinedApplicant = Mapper.Map<List<Invoice>, List<DistanceLearningDomain.Model.Invoice>>(rawApplicant);
            return refinedApplicant;
        }

        public IEnumerable<DistanceLearningDomain.Model.Invoice> GetAllPaidInvoice(int PayId)
        {
            var rawApplicant = (from c in Context.Invoices  where c.PayId == PayId  && c.InvoicePayments.Select(p=>p.AmountPaid).Sum()>=c.TotalAmount select c).ToList();
            var refinedApplicant = Mapper.Map<List<Invoice>, List<DistanceLearningDomain.Model.Invoice>>(rawApplicant);
            return refinedApplicant;
        }

        public IEnumerable<DistanceLearningDomain.Model.Invoice> GetAllUnPaidInvoice(int PayId)
        {
            var rawApplicant = (from c in Context.Invoices where c.PayId == PayId && c.InvoicePayments.Select(p => p.AmountPaid).Sum() <= 0 select c).ToList();
            var refinedApplicant = Mapper.Map<List<Invoice>, List<DistanceLearningDomain.Model.Invoice>>(rawApplicant);
            return refinedApplicant;
        }

        public IEnumerable<DistanceLearningDomain.Model.Invoice> GetAllPersonalPaidInvoice(int studId)
        {
            var rawApplicant = (from c in Context.Invoices where c.StudLevId == studId && c.InvoicePayments.Select(p => p.AmountPaid).Sum() >= c.TotalAmount select c).ToList();
            var refinedApplicant = Mapper.Map<List<Invoice>, List<DistanceLearningDomain.Model.Invoice>>(rawApplicant);
            return refinedApplicant;
        }

        public IEnumerable<DistanceLearningDomain.Model.Invoice> GetAllPersonalUnPaidInvoice(int studId)
        {
            var rawApplicant = (from c in Context.Invoices where c.StudLevId == studId && c.InvoicePayments.Select(p => p.AmountPaid).Sum() <=0 select c).ToList();
            var refinedApplicant = Mapper.Map<List<Invoice>, List<DistanceLearningDomain.Model.Invoice>>(rawApplicant);
            return refinedApplicant;
        }

        public IEnumerable<DistanceLearningDomain.Model.Invoice> GetAllPersonalInvoice(string MatricNo)
        {
            var rawApplicant = (from c in Context.Invoices where c.StudentLevel.Student.MatricNo.ToLower() == MatricNo.ToLower() select c).ToList();
            var refinedApplicant = Mapper.Map<List<Invoice>, List<DistanceLearningDomain.Model.Invoice>>(rawApplicant);
            return refinedApplicant;
        }

        public IEnumerable<DistanceLearningDomain.Model.Invoice> GetAllPersonalPaidInvoice(string MatricNo)
        {
            var rawApplicant = (from c in Context.Invoices where c.StudentLevel.Student.MatricNo.ToLower() == MatricNo.ToLower() && c.InvoicePayments.Select(p => p.AmountPaid).Sum() >= c.TotalAmount select c).ToList();
            var refinedApplicant = Mapper.Map<List<Invoice>, List<DistanceLearningDomain.Model.Invoice>>(rawApplicant);
            return refinedApplicant;
           
        }

        public IEnumerable<DistanceLearningDomain.Model.Invoice> GetAllPersonalUnPaidInvoice(string MatricNo)
        {
            var rawApplicant = (from c in Context.Invoices where c.StudentLevel.Student.MatricNo.ToLower() == MatricNo.ToLower() && c.InvoicePayments.Select(p => p.AmountPaid).Sum() <=0 select c).ToList();
            var refinedApplicant = Mapper.Map<List<Invoice>, List<DistanceLearningDomain.Model.Invoice>>(rawApplicant);
            return refinedApplicant;
        }

        public IEnumerable<DistanceLearningDomain.Model.Invoice> GetAllPersonalInvoice(int studId, int sessId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DistanceLearningDomain.Model.Invoice> GetAllPersonalPaidInvoice(int studId, int sessId)
        {
            var rawApplicant = (from c in Context.Invoices where c.StudentLevel.StudentId == studId && c.SessionSem.SessId==sessId && c.InvoicePayments.Select(p => p.AmountPaid).Sum() >= c.TotalAmount select c).ToList();
            var refinedApplicant = Mapper.Map<List<Invoice>, List<DistanceLearningDomain.Model.Invoice>>(rawApplicant);
            return refinedApplicant;
        }

        public IEnumerable<DistanceLearningDomain.Model.Invoice> GetAllPersonalUnPaidInvoice(int studId, int sessId)
        {
            var rawApplicant = (from c in Context.Invoices where c.StudentLevel.StudentId == studId && c.SessionSem.SessId == sessId && c.InvoicePayments.Select(p => p.AmountPaid).Sum() >= c.TotalAmount select c).ToList();
            var refinedApplicant = Mapper.Map<List<Invoice>, List<DistanceLearningDomain.Model.Invoice>>(rawApplicant);
            return refinedApplicant;
        }

        public IEnumerable<DistanceLearningDomain.Model.Invoice> GetAllPersonalInvoice(string matNo, int sessId)
        {
            var rawApplicant = (from c in Context.Invoices where c.StudentLevel.Student.MatricNo.ToLower() == matNo.ToLower() && c.SessionSem.SessId == sessId  select c).ToList();
            var refinedApplicant = Mapper.Map<List<Invoice>, List<DistanceLearningDomain.Model.Invoice>>(rawApplicant);
            return refinedApplicant;
        }

        public IEnumerable<DistanceLearningDomain.Model.Invoice> GetAllPersonalPaidInvoice(string matNo, int sessId)
        {
            var rawApplicant = (from c in Context.Invoices where c.StudentLevel.Student.MatricNo.ToLower() == matNo.ToLower() && c.SessionSem.SessId == sessId && c.InvoicePayments.Select(p => p.AmountPaid).Sum() >= c.TotalAmount select c).ToList();
            var refinedApplicant = Mapper.Map<List<Invoice>, List<DistanceLearningDomain.Model.Invoice>>(rawApplicant);
            return refinedApplicant;
        }

        public IEnumerable<DistanceLearningDomain.Model.Invoice> GetAllPersonalUnPaidInvoice(string matNo, int sessId)
        {
            var rawApplicant = (from c in Context.Invoices where c.StudentLevel.Student.MatricNo.ToLower() == matNo.ToLower() && c.SessionSem.SessId == sessId && c.InvoicePayments.Select(p => p.AmountPaid).Sum() >= c.TotalAmount select c).ToList();
            var refinedApplicant = Mapper.Map<List<Invoice>, List<DistanceLearningDomain.Model.Invoice>>(rawApplicant);
            return refinedApplicant;
        }
        public DistanceLearningDomain.Model.Invoice GetAllPersonalInvoice(int StudLevId, int payId, int sessId)
        {
            var rawApplicant = (from c in Context.Invoices where c.StudentLevel.StudentId == StudLevId && c.PayId== payId && c.SessId==sessId select c).FirstOrDefault();
            var refinedApplicant = Mapper.Map<Invoice, DistanceLearningDomain.Model.Invoice>(rawApplicant);
            return refinedApplicant;
        }

        public bool ConfirmInvoice(int StudLevId, int payId, int sessId)
        {
            var rawApplicant = (from c in Context.Invoices where c.StudentLevel.StudentId == StudLevId && c.PayId == payId && c.SessId == sessId select c).Any();
            //var refinedApplicant = Mapper.Map<Invoice, DistanceLearningDomain.Model.Invoice>(rawApplicant);
            return rawApplicant;
        }

        public bool ConfirmInvoiceTotalPayment(int StudLevId, int payId, int sessId)
        {
            var rawApplicant = (from c in Context.Invoices where c.StudentLevel.StudentId == StudLevId && c.PayId == payId && c.SessId == sessId && c.InvoicePayments.Select(p => p.AmountPaid).Sum() >= c.TotalAmount select c).Any();
           // var refinedApplicant = Mapper.Map<Invoice, DistanceLearningDomain.Model.Invoice>(rawApplicant);
            return rawApplicant;
        }


        public DistanceLearningDomain.Model.Invoice GetAllPersonalInvoice(string matNo, int payId, int sessId)
        {
            var rawApplicant = (from c in Context.Invoices where c.StudentLevel.Student.MatricNo.ToLower() == matNo && c.PayId == payId && c.SessId == sessId select c).FirstOrDefault();
            var refinedApplicant = Mapper.Map<Invoice, DistanceLearningDomain.Model.Invoice>(rawApplicant);
            return refinedApplicant;
        }
        public DistanceLearningDomain.Model.Invoice GetAllPersonalInvoiceSingle(string matNo, int sessId)
        {
            var rawApplicant = (from c in Context.Invoices where c.StudentLevel.Student.MatricNo.ToLower() == matNo  && c.SessId == sessId select c).FirstOrDefault();
            var refinedApplicant = Mapper.Map<Invoice, DistanceLearningDomain.Model.Invoice>(rawApplicant);
            return refinedApplicant;
        }
    }
}
