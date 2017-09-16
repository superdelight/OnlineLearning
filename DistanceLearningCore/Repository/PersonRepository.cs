using DistanceLearningCore.Model.StaffModel;
using DistanceLearningDomain.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace DistanceLearningCore.Repository
{
    public class PersonRepository :Repository<DistanceLearningDomain.Model.Person,Person>, IPersonRepository
    {
        public PersonRepository(DbContext Context)
            :base(Context)
        {
            
        }
        public IEnumerable<DistanceLearningDomain.Model.Person> GetFavourite()
        {
            throw new NotImplementedException();
        }
    }
}
