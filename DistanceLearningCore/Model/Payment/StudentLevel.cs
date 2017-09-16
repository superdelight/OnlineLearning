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
    
    public partial class StudentLevel
    {
        public StudentLevel()
        {
            this.StudentPayments = new HashSet<StudentPayment>();
            this.Invoices = new HashSet<Invoice>();
        }
    
        public int Id { get; set; }
        public int SessId { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
        public Nullable<int> StudentId { get; set; }
        public Nullable<int> StudLevelId { get; set; }
    
        public virtual Session Session { get; set; }
        public virtual ICollection<StudentPayment> StudentPayments { get; set; }
        public virtual ICollection<Invoice> Invoices { get; set; }
        public virtual Studentss Student { get; set; }
    }
}
