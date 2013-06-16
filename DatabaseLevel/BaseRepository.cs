using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Objects.DataClasses;

namespace DatabaseLevel
{
    //базовый класс доступа к данным
    public class BaseRepository<T, TK>
        where T : ObjectContext, new()
        where TK : EntityObject
    {
        //объект доступа к данным базы
        protected T _context;
        //объект сущности базы данных
        protected IObjectSet<TK> _objectSet;

        public BaseRepository()
        {
            _context = new T();
            _objectSet = _context.CreateObjectSet<TK>();
        }

        //преобразование данных в список
        public virtual List<TK> ToList()
        {
            return _objectSet.ToList();
        }

        //достает данные по запросу query
        public virtual IEnumerable<TK> Query(Expression<Func<TK, bool>> query)
        {
            return _objectSet.Where(query).ToList();
        }

        //выбирает перый элемент из коллекции данных по запросу query
        public virtual TK FirstOrDefault(Expression<Func<TK, bool>> query)
        {
            return _objectSet.FirstOrDefault(query);
        }

        //подсчитывет количество выбранных данных по запросу query
        public virtual int Count(Expression<Func<TK, bool>> query)
        {
            return _objectSet.Count(query);
        }
    }
}
