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
    
    public partial class AdmissionProgramme
    {
        public AdmissionProgramme()
        {
            this.Applications = new HashSet<Application>();
        }
    
        public int Id { get; set; }
        public string Description { get; set; }
        public Nullable<int> AdminId { get; set; }
        public Nullable<int> ProgId { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
    
        public virtual ProgrammeLevel ProgrammeLevel { get; set; }
        public virtual ICollection<Application> Applications { get; set; }
    }
}
