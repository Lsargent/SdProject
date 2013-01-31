using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess {
    public class RepositoryBase<TContextClass> : IDisposable 
        where TContextClass : DbContext, new() {

        private TContextClass _context;

        public virtual TContextClass Context {
            get {
                return _context ?? (_context = new TContextClass());
            }
        }

        public virtual TClass Get<TClass>(Expression<Func<TClass, bool>> predicate) where TClass : class, new() {
            if (predicate != null) {
                    return Context.Set<TClass>().Where(predicate).SingleOrDefault();
            }
            throw new ApplicationException("a predicate value must be passed.");          
        }

        public virtual IEnumerable<TClass> GetAll<TClass>() where TClass : class, new() {
            return Context.Set<TClass>();
        }

        public virtual IEnumerable<TClass> GetAllOrderedBy<TClass, TKey>(Func<TClass, TKey> key, bool desc = false) where TClass : class, new() {
            var items = GetAll<TClass>();
            return (desc) ? items.OrderByDescending(key) : items.OrderBy(key);
        } 

        public void Dispose()
        {
            if(_context != null) { _context.Dispose(); }
        }
    }
}
