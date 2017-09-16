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
    
    public abstract partial class PaymentConfiguration
    {
        public PaymentConfiguration()
        {
            this.PaymentItems = new HashSet<PaymentItem>();
            this.Invoices = new HashSet<Invoice>();
            this.InvoicePayments = new HashSet<InvoicePayment>();
        }
    
        public int Id { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<System.DateTime> Deadline { get; set; }
        public Nullable<float> TotalAmount { get; set; }
        public Nullable<int> catId { get; set; }
    
        public virtual PayCategory PayCategory { get; set; }
        public virtual ICollection<PaymentItem> PaymentItems { get; set; }
        public virtual ICollection<Invoice> Invoices { get; set; }
        public virtual ICollection<InvoicePayment> InvoicePayments { get; set; }
    }
}