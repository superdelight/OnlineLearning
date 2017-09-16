using DistanceLearningDomain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DistanceLearningDomain.Repository
{
    public interface IPersonRepository : IRepository<Person>
    {
       IEnumerable<Person> GetFavourite();
    }
}

