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
    
    public partial class Faculty
    {
        public Faculty()
        {
            this.FacultyPayments = new HashSet<FacultyPayment>();
            this.GeneralByFaculties = new HashSet<GeneralByFaculty>();
        }
    
        public int Id { get; set; }
        public string FacultyName { get; set; }
        public string FacultyAcronymns { get; set; }
        public Nullable<int> SchId { get; set; }
    
        public virtual ICollection<FacultyPayment> FacultyPayments { get; set; }
        public virtual ICollection<GeneralByFaculty> GeneralByFaculties { get; set; }
    }
}
