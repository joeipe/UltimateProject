using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using Server_MVC4.Core.Interfaces;

namespace Server_MVC4.Infrastructure.Data
{
    public class SqlRepository<T> : IRepository<T> where T : class
    {
        protected DbContext DataContext;
        protected DbSet<T> DataTable;

        public SqlRepository(DbContext dataContext)
        {
            if (dataContext == null)
            {
                throw new ArgumentNullException("dataContext");
            }
            DataContext = dataContext;
            DataTable = DataContext.Set<T>();
        }

        public virtual IQueryable<T> GetAll()
        {
            return DataTable;
        }

        public virtual IQueryable<T> SearchFor(Expression<Func<T, bool>> predicate)
        {
            return DataTable.Where(predicate);
        }

        public virtual T GetById(int id)
        {
            return DataTable.Find(id);
        }

        public virtual void Add(T entity)
        {
            DataTable.Add(entity);
        }

        public virtual void Delete(int id)
        {
            var entity = DataTable.Find(id);
            DataTable.Remove(entity);
        }
    }
}