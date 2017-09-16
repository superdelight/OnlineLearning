using DistanceLearningCore.Model.Payment;
using DistanceLearningCore.Repository;
using DistanceLearningDomain.Repository;
using DistanceLearningDomain.UoW;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace DistanceLearningCore.UoW
{
    public class ElearningPaymentUoW : IPaymentUoW
    {
        private readonly ElearningPayEntities _Context;
        public ElearningPaymentUoW()
        {
            _Context = new ElearningPayEntities();
            AcceptanceContext = new AcceptanceRepository(_Context);
            SchoolFeePaymentContext = new SchoolPayRepository(_Context);
            OtherPaymentContext = new OtherPaymentRepository(_Context);
            PaymentContext = new PaymentRepository(_Context);
            SessionPaymentContext = new SessionPaymentRepository(_Context);
            SessionSemPaymentContext = new SessionSemPaymentRepository(_Context);
            ApplicationPaymentContext = new ApplicantPaymentRepository(_Context);
            PayCategoryContext = new PayCategoryRepository(_Context);
            GeneralPaymentContext = new GeneraAllRepository(_Context);
            ChildPaymentContext = new ChildPayRepository(_Context);
            PaymentItemContext = new PaymentItemRepository(_Context);
            FacultyPaymentContext = new GeneralByFacultyRepository(_Context);
            InvoiceContext = new InvoiceRepository(_Context);
            InvoicePaymentContext = new InvoicePaymentRepository(_Context);
        }
        public int Complete()
        {
            return _Context.SaveChanges();
        }
        public void Dispose()
        {
            _Context.Dispose();
        }


        public IAcceptance AcceptanceContext { get; private set; }
        public ISchoolPayment SchoolFeePaymentContext { get; private set; }
        public IOtherPayment OtherPaymentContext { get; private set; }
        public IPayment PaymentContext { get; private set; }
        public ISessionPayment SessionPaymentContext { get; private set; }
        public ISessionSemPayment SessionSemPaymentContext { get; private set; }
        public IApplicantPayment ApplicationPaymentContext { get; private set; }
        public IPayCategory PayCategoryContext { get; private set; }
        public IGeneralAllRepository GeneralPaymentContext { get; private set; }
        public IChildPaymentRepository ChildPaymentContext { get; private set; }
        public IPaymentItem PaymentItemContext { get; private set; }
        public IGeneralFacultyRepository FacultyPaymentContext { get; private set; }
        public IInvoiceRepository InvoiceContext{ get; private set; }

        public IInvoicePaymentRepository InvoicePaymentContext { get; private set; }
        
    }
}
