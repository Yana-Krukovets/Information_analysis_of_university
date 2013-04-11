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
    public class BaseRepository<T, K> where T : ObjectContext, new() where K : EntityObject
    {
        protected T _context;
        protected IObjectSet<K> _objectSet;

        public BaseRepository()
        {
            _context = new T();
            _objectSet = _context.CreateObjectSet<K>();
        }

        public virtual void Insert(K newEntity)
        {
            _objectSet.AddObject(newEntity);
            _context.SaveChanges();
        }

        public virtual void Update(K entity)
        {
            //ObjectStateEntry entry;
            _objectSet.Detach(entity);

            _objectSet.AddObject(entity);
            _context.ObjectStateManager.ChangeObjectState(entity, EntityState.Modified);
            _context.SaveChanges();
        }

        public virtual List<K> ToList()
        {
            return _objectSet.ToList();
        }
        public virtual IEnumerable<K> Query(Expression<Func<K, bool>> query)
        {
            return _objectSet.Where(query).ToList();

        }
        public virtual K FirstOrDefault(Expression<Func<K, bool>> query)
        {
            return _objectSet.FirstOrDefault(query);
        }
        public virtual void Delete(K entity)
        {
            _objectSet.DeleteObject(entity);
            _context.SaveChanges();
        }
    }
}
