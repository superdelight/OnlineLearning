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
    
    public abstract partial class Requirement
    {
        public Requirement()
        {
          
        }
    
        public int Id { get; set; }
        public Nullable<int> MaxUnit { get; set; }
        public Nullable<int> SemId { get; set; }
        public string Description { get; set; }
        public Nullable<bool> IsElective { get; set; }
        public Nullable<System.DateTime> DateTimeStamp { get; set; }
    
       
    }
}