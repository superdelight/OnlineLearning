using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistanceLearningInfrastructure
{
    public class ExamGrade
    {
       public int Id { get; set; }
       public int SN { get; set; }
       public string Subject { get; set; }
       public string Grade { get; set; }
       //public int Value
       //{
       //    get
       //    {
       //        return Value;
       //    }
       //}
    }
    public class EduRec
    {
        public int Id { get; set; }
        public int SN { get; set; }
        public string SchoolName { get; set; }
        public string Grade { get; set; }
        public string Course { get; set; }
        public string Certificate { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        
    }
}
