using DistanceLearningDomain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DistanceLearningDomain.Repository
{
    public interface IInvoicePaymentRepository : IRepository<InvoicePayment>
    {
        IEnumerable<InvoicePayment> GetAllInvoicePayment(int invoiceId);
        IEnumerable<InvoicePayment> GetAllInvoicePaymentByPay(int PayId);
        IEnumerable<InvoicePayment> GetAllInvoicePaymentBySessionSem(int sessId);
        IEnumerable<InvoicePayment> GetAllInvoicePaymentByStudentLevel(int levelId);
        IEnumerable<InvoicePayment> GetAllInvoicePaymentByStudent(string matricNo);
        InvoicePayment GetSingleInvoicePaymentByStudent(int studId, int PayId);
        bool ConfirmInvoicePayment(int invoice, int PayId);
        bool ConfirmInvoicePayment(string matNo, int PayId);
        IEnumerable<InvoicePayment> GetAllInvoicePaymentByStudent(string matricNo,int PayId);
       
      
    }
}

