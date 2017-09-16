//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DistanceLearningCore.Model.Payment
{
    using System;
    using System.Collections.Generic;
    
    public partial class Invoice
    {
        public Invoice()
        {
            this.InvoicePayments = new HashSet<InvoicePayment>();
        }
    
        public int Id { get; set; }
        public string InvoiceNo { get; set; }
        public Nullable<float> TotalAmount { get; set; }
        public Nullable<System.DateTime> DateGenerated { get; set; }
        public Nullable<int> SessId { get; set; }
        public Nullable<int> PayId { get; set; }
        public Nullable<int> StudLevId { get; set; }
        public string PaymentDescription { get; set; }
    
        public virtual PaymentConfiguration PaymentConfiguration { get; set; }
        public virtual SessionSem SessionSem { get; set; }
        public virtual StudentLevel StudentLevel { get; set; }
        public virtual ICollection<InvoicePayment> InvoicePayments { get; set; }
    }
}