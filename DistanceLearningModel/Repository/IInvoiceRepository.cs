using DistanceLearningDomain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DistanceLearningDomain.Repository
{
    public interface IInvoiceRepository : IRepository<Invoice>
    {
        IEnumerable<Invoice> GetAllInvoice(int PayId);
        IEnumerable<Invoice> GetAllPaidInvoice(int PayId);
        IEnumerable<Invoice> GetAllUnPaidInvoice(int PayId);
        IEnumerable<Invoice> GetAllPersonalPaidInvoice(int studId);
        IEnumerable<Invoice> GetAllPersonalUnPaidInvoice(int studId);
        IEnumerable<Invoice> GetAllPersonalInvoice(string MatricNo);
        IEnumerable<Invoice> GetAllPersonalPaidInvoice(string MatricNo);
        IEnumerable<Invoice> GetAllPersonalUnPaidInvoice(string MatricNo);
        IEnumerable<Invoice> GetAllPersonalInvoice(int studId,int sessId);
        IEnumerable<Invoice> GetAllPersonalPaidInvoice(int studId, int sessId);
        IEnumerable<Invoice> GetAllPersonalUnPaidInvoice(int studId, int sessId);
        IEnumerable<Invoice> GetAllPersonalInvoice(string matNo, int sessId);
        IEnumerable<Invoice> GetAllPersonalPaidInvoice(string matNo, int sessId);
        IEnumerable<Invoice> GetAllPersonalUnPaidInvoice(string matNo, int sessId);
        Invoice GetAllPersonalInvoice(string matNo, int payId, int sessId);
        Invoice GetAllPersonalInvoice(int StudLevId,int payId, int sessId);
        Invoice GetAllPersonalInvoiceSingle(string matNo, int sessId);
        bool ConfirmInvoice(int StudLevId, int payId, int sessId);
        bool ConfirmInvoiceTotalPayment(int StudLevId, int payId, int sessId);
      
    }
}

