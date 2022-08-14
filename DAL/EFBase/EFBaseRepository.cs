using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DAL.EFBase
{
    public class EFBaseRepository<T, TBContext> : IEFBaseRepository<T> where T : class
        where TBContext : DbContext
    {
        protected readonly TBContext Context;
        public EFBaseRepository(TBContext context)
        {
            Context = context;
        }
        public T Add(T entity)
        {
            return Context.Add(entity).Entity;
        }

        public void Delete(T entity)
        {
            Context.Remove(entity);
        }

        public T Get(Expression<Func<T, bool>> expression)
        {
            //Peformans açısından kötü bir yaklaşımdır.
            //Context.Set<T>().Where(expression).FirstOrDefault();


            return Context.Set<T>().FirstOrDefault(expression);
        }

        /// <summary>
        /// null ise bütün dataları dönecek, değil ise koşulu sağlayan dataları dönecek
        /// </summary>
        public IEnumerable<T> GetAll(Expression<Func<T, bool>> expression = null)
        {
            if (expression == null)
                return Context.Set<T>().ToList();
            else
            {
                return Context.Set<T>().Where(expression);
            }
        }

        public void SaveChanges()
        {
            Context.SaveChanges();

        }

        public T Update(T entity)
        {
            Context.Update(entity);
            return entity;
        }
    }
}
