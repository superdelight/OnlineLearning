using DistanceLearningDomain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DistanceLearningDomain.Repository
{
    public interface ICourseRoleRepository : IRepository<CourseRole>
    {
       
        bool ConfirmCourseRole(string detail);
        CourseRole GetCourseRole(string detail);

    }
}

