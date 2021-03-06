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
    
    public partial class StudentPrecision
    {
        public StudentPrecision()
        {
            this.StudentInvoices = new HashSet<StudentInvoice>();
        }
        public int Id { get; set; }
        public Nullable<int> ActivityId { get; set; }
        public Nullable<int> PayId { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public string Description { get; set; }
        public virtual Activity Activity { get; set; }
        public virtual PaymentConfiguration PaymentConfiguration { get; set; }
        public virtual ICollection<StudentInvoice> StudentInvoices { get; set; }
    }
}
