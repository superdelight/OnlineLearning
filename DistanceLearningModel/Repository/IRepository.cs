using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DistanceLearningDomain.Repository
{
   public interface IRepository<T> where T: class
    {
       T GetItem(int Id);
       IEnumerable<T> GetAll();
       IEnumerable<T> Find(Expression<Func<T,bool>> predicate);

        bool Add(T Item);
        int AddRange(IEnumerable<T> Items);
        bool Edit(T Item, int Id);
        bool Remove(T Item,int Id);
        int RemoveRange(IEnumerable<T> Items);
    }
}