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
    
    public partial class StudentCategoryxxx
    {
        public StudentCategoryxxx()
        {
            this.StudentCatLevels = new HashSet<StudentCatLevel>();
        }
    
        public int Id { get; set; }
        public string Description { get; set; }
    
        public virtual ICollection<StudentCatLevel> StudentCatLevels { get; set; }
    }
}
