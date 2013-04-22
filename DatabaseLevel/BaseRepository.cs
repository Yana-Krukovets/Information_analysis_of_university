using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Objects;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Data.Objects.DataClasses;

namespace DatabaseLevel
{
    public class BaseRepository<T, TK>
        where T : ObjectContext, new()
        where TK : EntityObject
    {
        protected T _context;
        protected IObjectSet<TK> _objectSet;

        public BaseRepository()
        {
            _context = new T();
            _objectSet = _context.CreateObjectSet<TK>();
        }

        //public virtual void Insert(K newEntity)
        //{
        //    _objectSet.AddObject(newEntity);
        //    _context.SaveChanges();
        //}

        //public virtual void Update(K entity)
        //{
        //    //ObjectStateEntry entry;
        //    _objectSet.Detach(entity);

        //    _objectSet.AddObject(entity);
        //    _context.ObjectStateManager.ChangeObjectState(entity, EntityState.Modified);
        //    _context.SaveChanges();
        //}

        public virtual List<TK> ToList()
        {
            return _objectSet.ToList();
        }

        public virtual IEnumerable<TK> Query(Expression<Func<TK, bool>> query)
        {
            return _objectSet.Where(query).ToList();
        }

        public virtual TK FirstOrDefault(Expression<Func<TK, bool>> query)
        {
            return _objectSet.FirstOrDefault(query);
        }

        public virtual int Count(Expression<Func<TK, bool>> query)
        {
            return _objectSet.Count(query);
        }



        //public virtual void Delete(K entity)
        //{
        //    _objectSet.DeleteObject(entity);
        //    _context.SaveChanges();
        //}
    }
}
