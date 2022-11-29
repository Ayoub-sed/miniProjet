using Metrologie.Data.Context;
using Metrologie.Domain.Interfaces;
using Metrologie.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Metrologie.Data.Repository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private MetrologieContext _context = null;
        private DbSet<TEntity> table = null;



        public GenericRepository(MetrologieContext _context)
        {
            this._context = _context;
            table = _context.Set<TEntity>();
        }
        public IEnumerable<TEntity> GetList(Expression<Func<TEntity, bool>> condition,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includes)
        {
            try
            {
                IQueryable<TEntity> query = table;

                if (includes != null)
                {
                    query = includes(query);
                }
                if (condition != null)
                    return query.Where(condition).ToList();

                else
                    return query.ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }

        }

      /*  public IEnumerable<IGrouping<string,TEntity>> GetListBYCriteria(Func<IGrouping<string, TEntity>, IIncludableQueryable<TEntity, object>> grpby)
        {
            try
            {
                IQueryable<TEntity> query = table;
                    return query.GroupBy(x => x.Equals(grpby));
              
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }

        }*/

        public TEntity Get(Expression<Func<TEntity, bool>> condition,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includes = null)
        {
            try
            {
                IQueryable<TEntity> query = table;

                if (includes != null)
                {
                    query = includes(query);
                }
                if (condition != null)
                    return query.Where(condition).FirstOrDefault();

                else
                    return query.FirstOrDefault();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }

        }
        public TEntity Add(TEntity Entity)
        {
            table.Add(Entity);
            _context.SaveChanges();
            return Entity;
        }

        public string AddRange(IEnumerable<TEntity> entities)
        {
            string response = "";
            try
            {
                _context.Set<TEntity>().AddRange(entities);
                _context.SaveChanges();
                return response = "Added done";
            }
            catch (Exception e)
            {
                var s = e.ToString();
                return response = "Add Not done , with Exeption \n" + e;
            }
        }

        public TEntity Update(TEntity Entity)
        {
            table.Attach(Entity);
            _context.Entry(Entity).State = EntityState.Modified;
            _context.SaveChanges();
            return Entity;
        }
        public TEntity Delete(Guid Id)
        {
            TEntity existing = table.Find(Id);
            table.Remove(existing);
            _context.SaveChanges();
            return existing;

        }
        


    }
}
