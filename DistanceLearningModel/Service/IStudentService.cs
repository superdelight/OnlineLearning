using DistanceLearningInfrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DistanceLearningDomain.Service
{
    public interface IStudentService
    {
       StudentDetail GetStudentCurrentDetail(string matNo);
       StudentDetail GetStudentProjectedDetails(int studentLevId);
       
    }
}
