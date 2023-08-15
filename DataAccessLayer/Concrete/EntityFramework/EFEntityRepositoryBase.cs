using DataAccessLayer.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.EntityFramework
{
    public class EFEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class , new()
        where TContext : DbContext , new()
    {
        public void Add(TEntity entity)
        {
            using(TContext context = new TContext()) 
            {
                context.Add(entity);
                context.SaveChanges();
            }
        }

        public void Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                context.Update(entity);
                context.SaveChanges();
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                context.Remove(entity);
                context.SaveChanges();
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> Filter = null)
        {
            using (TContext context = new TContext())
            {
				return Filter == null ? context.Set<TEntity>().ToList() : context.Set<TEntity>().Where(Filter).ToList();
			}
        }

        public TEntity GetByID(int id)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().Find(id);
            }
        }
    }
}
