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
    
    public partial class Employment
    {
        public int Id { get; set; }
        public string Employer { get; set; }
        public string Position { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public Nullable<int> AppId { get; set; }
        public Nullable<System.DateTime> DateStamp { get; set; }
    
        public virtual Applicant Applicant { get; set; }
    }
}
