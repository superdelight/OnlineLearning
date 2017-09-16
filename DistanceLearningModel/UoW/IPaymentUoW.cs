using DistanceLearningDomain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DistanceLearningDomain.UoW
{
    public interface IPaymentUoW : IDisposable
    {
        IAcceptance AcceptanceContext { get; }
        ISchoolPayment SchoolFeePaymentContext { get; }
        IOtherPayment OtherPaymentContext { get; }
        IPayment PaymentContext { get; }
        ISessionPayment SessionPaymentContext { get; }
        ISessionSemPayment SessionSemPaymentContext { get; }
        IApplicantPayment ApplicationPaymentContext { get; }
        IPayCategory PayCategoryContext { get; }
        IGeneralAllRepository GeneralPaymentContext { get; }
        IChildPaymentRepository ChildPaymentContext { get; }
        IGeneralFacultyRepository FacultyPaymentContext { get; }
        IPaymentItem PaymentItemContext { get; }
       IInvoiceRepository InvoiceContext { get;}
       IInvoicePaymentRepository InvoicePaymentContext { get; }
        int Complete();
    }
}
