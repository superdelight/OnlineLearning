//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DistanceLearningDomain.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class AdmissionProcessing
    {
        public int Id { get; set; }
        public Nullable<System.DateTime> DateProcessed { get; set; }
        public Nullable<int> ApplicationId { get; set; }
        public string ProcessedBy { get; set; }
        public string Remarks { get; set; }
        public Nullable<bool> IsNotified { get; set; }
        public Nullable<bool> IsVerified { get; set; }
        public Nullable<System.DateTime> NotificationDate { get; set; }
        public Nullable<System.DateTime> VerificationDate { get; set; }
        public string VerifiedBy { get; set; }
        public Nullable<bool> IsAccepted { get; set; }
        public Nullable<System.DateTime> AcceptedOn { get; set; }
        public Nullable<bool> IsActivated { get; set; }
        public string PaymentReference { get; set; }
        public Nullable<bool> HasPaidTution { get; set; }
        public string SchoolFeeReference { get; set; }
        public string PaymentDescription { get; set; }
        public Nullable<System.DateTime> SchoolPayDate { get; set; }

    }
}
