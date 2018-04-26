using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Data;
using System.Text;
using DAL.Interface;
using DAL.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Threading.Tasks;
using System.Reflection;
using Serilog;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL
{
    public class GenericDataRepository<T> : IDisposable,IGenericDataRepository<T> where T : Base, IEntity
    {
        private PersonelContext _context;
        private ILogger Logger;

        public GenericDataRepository(PersonelContext context, ILogger logger)
        {
            _context = context;
            this.Logger = logger;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async virtual Task<IList<T>> GetAllAsync(params Expression<Func<T, object>>[] navigationProperties)
        {
            IList<T> list;
            IQueryable<T> dbQuery = _context.Set<T>();

            //Apply eager loading
            foreach (Expression<Func<T, object>> navigationProperty in navigationProperties)
                dbQuery = dbQuery.Include<T, object>(navigationProperty);

            list = await dbQuery
                .ToListAsync<T>();
            return list;
        }

        public virtual IList<T> GetAll(params Expression<Func<T, object>>[] navigationProperties)
        {
            IList<T> list;
            IQueryable<T> dbQuery = _context.Set<T>();

            //Apply eager loading
            foreach (Expression<Func<T, object>> navigationProperty in navigationProperties)
                dbQuery = dbQuery.Include<T, object>(navigationProperty);

           list = dbQuery
                .ToList();
            return list;
        }

        public async virtual Task<IList<T>> GetListAsync(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] navigationProperties)
        {
            IList<T> list;

            IQueryable<T> dbQuery = _context.Set<T>();

            //Apply eager loading
            foreach (Expression<Func<T, object>> navigationProperty in navigationProperties)
                dbQuery = dbQuery.Include<T, object>(navigationProperty);

            list = await dbQuery
                .Where(where)
                .ToListAsync<T>();

            return list;
        }

        public virtual IList<T> GetList(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] navigationProperties)
        {
            IList<T> list;

            IQueryable<T> dbQuery = _context.Set<T>();

            //Apply eager loading
            foreach (Expression<Func<T, object>> navigationProperty in navigationProperties)
                dbQuery = dbQuery.Include<T, object>(navigationProperty);

            list = dbQuery
                .Where(where)
                .ToList();

            return list;
        }

        public virtual IList<T> GetPagedList(Expression<Func<T, bool>> where, Func<T, string> orderBy, int currentPage, int pageSize, params Expression<Func<T, object>>[] navigationProperties)
        {
            IList<T> list;

            IQueryable<T> dbQuery = _context.Set<T>();

            //calculate item skip
            int skip = (currentPage - 1) * pageSize;

            //Apply eager loading
            foreach (Expression<Func<T, object>> navigationProperty in navigationProperties)
            {
                if (navigationProperty != null)
                    dbQuery = dbQuery.Include<T, object>(navigationProperty);
            }

            list = dbQuery
                .Where(where).OrderBy(orderBy).Skip(skip).Take(pageSize)
                .ToList();

            return list;
        }

        public virtual int GetCount(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] navigationProperties)
        {
            IQueryable<T> dbQuery = _context.Set<T>();

            if (navigationProperties != null)
            {
                //Apply eager loading
                foreach (Expression<Func<T, object>> navigationProperty in navigationProperties)
                {
                    if (navigationProperty != null)
                        dbQuery = dbQuery.Include<T, object>(navigationProperty);
                }
            }
            
            int count = dbQuery
                .Where(where)
                .Count();

            return count;
        }

        public async virtual Task<T> GetSingleAsync(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] navigationProperties)
        {
            T item = null;

            IQueryable<T> dbQuery = _context.Set<T>();

            //Apply eager loading
            foreach (Expression<Func<T, object>> navigationProperty in navigationProperties)
                dbQuery = dbQuery.Include<T, object>(navigationProperty);

            item =  await dbQuery
                .FirstOrDefaultAsync(predicate:where); //Apply where clause
            return item;
        }

        public virtual T GetSingle(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] navigationProperties)
        {
            T item = null;

            IQueryable<T> dbQuery = _context.Set<T>();

            //Apply eager loading
            foreach (Expression<Func<T, object>> navigationProperty in navigationProperties)
                dbQuery = dbQuery.Include<T, object>(navigationProperty);

            item = dbQuery.FirstOrDefault(predicate: where); //Apply where clause
            return item;
        }

        public virtual void DeleteWhere(Expression<Func<T, bool>> predicate)
        {
            IEnumerable<T> entities = _context.Set<T>().Where(predicate);

            foreach (var entity in entities)
            {
                _context.Entry<T>(entity).State = GetEntityState(DAL.Interface.EntityState.Deleted);
            }

            _context.SaveChanges();
        }

        public virtual void Add(params T[] items)
        {
            foreach (var item in items)
            {
                item.entity_state = Interface.EntityState.Added;
            }
            updateRepository(items);

            foreach(var item in items)
                logNewObject(item);
        }

        public virtual void Delete(params T[] items)
        {
            foreach (var item in items)
            {
                item.entity_state = Interface.EntityState.Deleted;
            }
            updateRepository(items);
        }

        public virtual void Update(params T[] items)
        {
            foreach (var item in items)
            {
                item.entity_state = Interface.EntityState.Modified;
                logObjectDiff(item);
            }
            updateRepository(items);


        }

        private void updateRepository(params T[] items)
        {
            foreach (T item in items)
            {
                EntityEntry dbEntityEntry = _context.Entry<T>(item);

                if (item.entity_state == Interface.EntityState.Added)
                {
                    _context.Set<T>().Add(item);
                }

                dbEntityEntry.State = GetEntityState(item.entity_state);
            }

            _context.SaveChanges();
        }

        protected static Microsoft.EntityFrameworkCore.EntityState GetEntityState(DAL.Interface.EntityState entityState)
        {
            switch (entityState)
            {
                case DAL.Interface.EntityState.Unchanged:
                    return Microsoft.EntityFrameworkCore.EntityState.Unchanged;
                case DAL.Interface.EntityState.Added:
                    return Microsoft.EntityFrameworkCore.EntityState.Added;
                case DAL.Interface.EntityState.Modified:
                    return Microsoft.EntityFrameworkCore.EntityState.Modified;
                case DAL.Interface.EntityState.Deleted:
                    return Microsoft.EntityFrameworkCore.EntityState.Deleted;
                default:
                    return Microsoft.EntityFrameworkCore.EntityState.Detached;
            }
        }

        private void logObjectDiff(Object item)
        {
            Type logItem = item.GetType();
            int changeCount = 0;

            IList<PropertyInfo> oldObjProperties = new List<PropertyInfo>(logItem.GetProperties());

            var diff = new StringBuilder();

            diff.Append("[UPDATE] " + logItem.Name + ": " + _context.Entry(item).CurrentValues["id"] + " ");

            foreach (PropertyInfo oldObjProperty in oldObjProperties)
            {
                if (oldObjProperty.Name == "DateModified")
                    continue;

                //we want to exclude any property that points to another table
                bool isNavigationProperty = oldObjProperty.PropertyType.ToString().Contains("DAL.Model");
                if (isNavigationProperty)
                    continue;

                //we want to exclude any entities that are not mapped
                bool isNotMapped = oldObjProperty.GetCustomAttributes(typeof(NotMappedAttribute), true).FirstOrDefault() != null;
                if (isNotMapped)
                    continue; 

                var currentProperty = _context.Entry(item).CurrentValues[oldObjProperty.Name];
                var originalProperty = _context.Entry(item).OriginalValues[oldObjProperty.Name];

                string currentValue = currentProperty == null ? "" : currentProperty.ToString();
                string originalValue = originalProperty == null ? "" : originalProperty.ToString();

                if (currentValue != originalValue)
                {
                    diff.Append(oldObjProperty.Name + ": " + originalValue + " => " + currentValue + ", ");
                    changeCount++;
                }
            }

            string difference = diff.ToString();
            difference = difference.Remove(difference.Length - 2, 2);

            if(changeCount > 0)
                Logger.Information(difference);
        }

        private void logNewObject(Object item)
        {
            Type logItem = item.GetType();

            IList<PropertyInfo> objProperties = new List<PropertyInfo>(logItem.GetProperties());
            var log = new StringBuilder();

            log.Append("[CREATE] " + logItem.Name + ": " + _context.Entry(item).CurrentValues["id"] + " ");

            foreach (var objProperty in objProperties)
            {
                //we want to exclude any property that points to another table
                bool isNavigationProperty = objProperty.PropertyType.ToString().Contains("DAL.Model");
                if (isNavigationProperty)
                    continue;

                //we want to exclude any entities that are not mapped
                bool isNotMapped = objProperty.GetCustomAttributes(typeof(NotMappedAttribute), true).FirstOrDefault() != null;
                if (isNotMapped)
                    continue;

                var property = _context.Entry(item).CurrentValues[objProperty.Name];
                string value = property == null ? "" : property.ToString();

                log.Append(objProperty.Name + ": " + value + ", ");
            }

            string str = log.ToString();
            str = str.Remove(str.Length - 2, 2);

            Logger.Information(str);
        }

    }
}
