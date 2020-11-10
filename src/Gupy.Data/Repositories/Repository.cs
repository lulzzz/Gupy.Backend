using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Gupy.Core.Common;
using Gupy.Core.Interfaces.Data.Repositories;
using Gupy.Core.Interfaces.Data.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace Gupy.Data.Repositories
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly ApplicationDbContext Context;

        protected Repository(ApplicationDbContext context)
        {
            Context = context;
        }

        public TEntity Get(int id)
        {
            return Context.Set<TEntity>().Find(id);
        }

        public ValueTask<TEntity> GetAsync(int id)
        {
            return Context.Set<TEntity>().FindAsync(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return Context.Set<TEntity>().ToList();
        }

        public Task<List<TEntity>> GetAllAsync()
        {
            return Context.Set<TEntity>().ToListAsync();
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().Where(predicate).ToList();
        }

        public Task<List<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().Where(predicate).ToListAsync();
        }

        public TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().SingleOrDefault(predicate);
        }

        public Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().SingleOrDefaultAsync(predicate);
        }

        public void Add(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);
        }

        public async Task AddAsync(TEntity entity)
        {
            await Context.Set<TEntity>().AddAsync(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            Context.Set<TEntity>().AddRange(entities);
        }

        public void Remove(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            Context.Set<TEntity>().RemoveRange(entities);
        }

        public IUnitOfWork UnitOfWork => Context;

        public Task<List<TEntity>> ListAsync(bool asNoTracking = true, params Specification<TEntity>[] specifications)
        {
            var entities = Context.Set<TEntity>().AsQueryable();
            if (asNoTracking)
            {
                entities = entities.AsNoTracking();
            }

            entities = IncludeChildren(entities);

            foreach (var specification in specifications)
            {
                entities = entities.Where(specification.ToExpression());
            }

            return entities.ToListAsync();
        }

        /// <summary>
        /// Does nothing. Override this method to include children references in your repository
        /// </summary>
        /// <param name="entities"></param>
        protected virtual IQueryable<TEntity> IncludeChildren(IQueryable<TEntity> entities)
        {
            return entities;
        }
    }
}