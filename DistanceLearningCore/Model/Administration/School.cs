//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DistanceLearningCore.Model.Administration
{
    using System;
    using System.Collections.Generic;
    
    public partial class School
    {
        public School()
        {
            this.Awards = new HashSet<Award>();
            this.Faculties = new HashSet<Faculty>();
        }
    
        public int Id { get; set; }
        public string SchoolName { get; set; }
        public string Acronynms { get; set; }
        public string Address { get; set; }
        public string LogoPath { get; set; }
    
        public virtual ICollection<Award> Awards { get; set; }
        public virtual ICollection<Faculty> Faculties { get; set; }
    }
}
