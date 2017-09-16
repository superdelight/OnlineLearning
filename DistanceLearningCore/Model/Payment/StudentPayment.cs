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
    
    public partial class StudentPayment
    {
        public int Id { get; set; }
        public Nullable<System.DateTime> PaymentDate { get; set; }
        public Nullable<float> AmountPaid { get; set; }
        public string PaymentReference { get; set; }
        public Nullable<int> StudId { get; set; }
        public Nullable<int> PayId { get; set; }
        public string BankReference { get; set; }
        public Nullable<bool> IsInterswitch { get; set; }
        public Nullable<bool> IsVerified { get; set; }
        public string PayMode { get; set; }
    
        public virtual StudentLevel StudentLevel { get; set; }
    }
}