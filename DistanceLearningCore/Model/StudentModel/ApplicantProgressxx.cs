//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DistanceLearningCore.Model.StudentModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class ApplicantProgressxx
    {
        public int Id { get; set; }
        public Nullable<int> StepId { get; set; }
        public Nullable<int> AppId { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
    
        public virtual Applicant Applicant { get; set; }
        public virtual Stepxx Step { get; set; }
    }
}
