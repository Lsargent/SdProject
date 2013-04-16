using System;
using System.Data;
using System.Data.Entity;
using System.Data.Objects;
using System.Linq;
using System.Linq.Expressions;
using Logic;
using Logic.Helpers;

namespace DataAccess.Repositories {
    public class RepositoryBase<TContextClass> : IDisposable 
        where TContextClass : DbContext, new() {

        private TContextClass _context;

        public virtual TContextClass Context {
            get {
                return _context ?? (_context = new TContextClass());
            }
        }

        public virtual TClass Get<TClass>(Expression<Func<TClass, bool>> predicate, params Expression<Func<TClass, object>>[] includes) where TClass : class, new() {
            var query = Context.Set<TClass>().Where(predicate);
            return includes.Aggregate(query, (current, include) => current.Include(include)).FirstOrDefault();
        }

        public virtual IQueryable<TClass> GetAll<TClass>() where TClass : class, new() {
            return Context.Set<TClass>();
        }

        public virtual IQueryable<TClass> GetAllWithIncludes<TClass>(params Expression<Func<TClass, object>>[] includes) where TClass : class, new() {
            IQueryable<TClass> query = Context.Set<TClass>();
            return includes.Aggregate(query, (current, include) => current.Include(include));
        }

        public virtual IQueryable<TClass> GetAllWithIncludes<TClass>(Expression<Func<TClass, bool>> predicate, params Expression<Func<TClass, object>>[] includes) where TClass : class, new()
        {
            var query = Context.Set<TClass>().Where(predicate);
            return includes.Aggregate(query, (current, include) => current.Include(include));
        }

        public virtual IQueryable<TClass> GetAllOrderedBy<TClass, TKey>(Expression<Func<TClass, TKey>> key, bool desc = false) where TClass : class, new() {
            var items = GetAll<TClass>();
            return (desc) ? items.OrderByDescending(key): items.OrderBy(key);
        }

        public virtual OperationStatus<TClass> Add<TClass>(TClass itemToAdd) where TClass : class, IObjectState, new() {
            var opStatus = new OperationStatus<TClass> { WasSuccessful = true };
            try {
                opStatus.EffectedItems.Add(Context.Set<TClass>().Add(itemToAdd));
                opStatus.WasSuccessful = SaveChanges() > 0;
            }
            catch (Exception e) {
                opStatus.WasSuccessful = false;
                opStatus.Exception = e;
            }
            return opStatus;
        }

        public virtual OperationStatus<TClass> InsertOrUpdate<TClass>(TClass item) where TClass : class, IObjectState, new() {
            var opStatus = new OperationStatus<TClass> { WasSuccessful = true };
            try {
                opStatus.AddEffectedItem(Context.Set<TClass>().Add(item));
                Context.ApplyStateChanges();

                SaveChanges();  

                opStatus.WasSuccessful = true;
            }
            catch (Exception e) {
                opStatus.WasSuccessful = false;
                opStatus.Exception = e;
            }
            return opStatus;
        }

        public virtual int SaveChanges() {
                return Context.SaveChanges();     
        }

        public void Dispose()
        {
            if(_context != null) { _context.Dispose(); }
        }
    }
}
