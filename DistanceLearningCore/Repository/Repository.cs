using AutoMapper;
using DistanceLearningDomain.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DistanceLearningCore.Repository
{
   public class Repository<T, B>:IRepository<T> where T: class where B : class
    {
       protected readonly DbContext Context;
       public Repository(DbContext Context)
       {
           
           Mapper.CreateMap<T, B>();
           Mapper.CreateMap<B, T>();
           this.Context = Context;
           
       }
        public T GetItem(int Id)
        {
            var instance = Context.Set<B>().Find(Id);
            var inst = Mapper.Map<B, T>(instance);
            return inst;
            
        }
        public virtual IEnumerable<T> GetAll()
        {
            var instance = Context.Set<B>().ToList();
            var inst = Mapper.Map<IEnumerable<B>,IEnumerable<T>>(instance);
            return inst;
        }
        public  IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            var instance = Context.Set<T>().Where(predicate).ToList();
            return instance;
        }
        public virtual bool Add(T Item)
        {
            try
            {
                var inst = Mapper.Map<T, B>(Item);
                Context.Set<B>().Add(inst);
                return true;
            }
            catch
            {
                return false; 
            }
        }

        public virtual int AddRange(IEnumerable<T> Items)
        {
            try
            {
                var inst = Mapper.Map<IEnumerable<T>, IEnumerable<B>>(Items);
                Context.Set<B>().AddRange(inst);
                return 1;
            }
           catch
            {
                return 0;
            }
        }
        public virtual bool Remove(T Item,int Id)
        {
         
            B ent = Context.Set<B>().Find(Id);
            Context.Set<B>().Remove(ent);
            return true;
        }

        public virtual int RemoveRange(IEnumerable<T> Items)
        {
            Context.Set<T>().RemoveRange(Items);
            return 8;
        }
      
        public bool Edit(T Item,int Id)
        {
            try
            {
                var inst = Mapper.Map<T, B>(Item);
                B ent = Context.Set<B>().Find(Id);

                Context.Entry(ent).State = System.Data.Entity.EntityState.Detached;
                ent = inst;

                Context.Entry(ent).State = System.Data.Entity.EntityState.Modified;
               
                return true;

            }
            catch
            {
                return false;
            }
        }
    }
}