using DistanceLearningDomain.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DistanceLearningCore.Service
{
   public class StudentService:IStudentService
    {
        public DistanceLearningInfrastructure.StudentDetail GetStudentCurrentDetail(string matNo)
        {
            throw new NotImplementedException();
        }

        public DistanceLearningInfrastructure.StudentDetail GetStudentProjectedDetails(int studentLevId)
        {
            throw new NotImplementedException();
        }
    }
}
