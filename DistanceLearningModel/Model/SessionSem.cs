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
    
    public partial class SessionSem
    {
        public SessionSem()
        {
            
        }
    
        public int Id { get; set; }
        public string Description { get; set; }
        public Nullable<int> SemId { get; set; }
        public Nullable<int> SessId { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
        public Nullable<bool> IsOpen { get; set; }
        public Nullable<System.DateTime> DateClosed { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public Nullable<int> ExtensionDays { get; set; }
        public string ClosingRemarks { get; set; }
        public Nullable<int> WeekCount { get; set; }
    
    }
}
