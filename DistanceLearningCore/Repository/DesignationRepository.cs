using DistanceLearningCore.Model.StaffModel;
using DistanceLearningDomain.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace DistanceLearningCore.Repository
{
    public class DesignationRepository : Repository<DistanceLearningDomain.Model.Designation,Designation>, IDesignation
    {
        public DesignationRepository(DbContext Context)
            :base(Context)
        {
            
        }
        public IEnumerable<DistanceLearningDomain.Model.Designation> GetFavourite()
        {
            throw new NotImplementedException();
        }
    }
}
