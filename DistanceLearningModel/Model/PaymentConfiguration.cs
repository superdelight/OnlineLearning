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
    
    public abstract partial class PaymentConfiguration
    {
        public PaymentConfiguration()
        {
            
        }
    
        public int Id { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<System.DateTime> Deadline { get; set; }
        public Nullable<float> TotalAmount { get; set; }
        public Nullable<int> catId { get; set; }
    
        
    }
}
