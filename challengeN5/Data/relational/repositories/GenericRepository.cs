using challengeN5.Data.interfaces.repositories;
using challengeN5.Data.relational.common;
using Microsoft.EntityFrameworkCore;

namespace challengeN5.Data.relational.repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected ApplicationContext context;
        internal DbSet<T> set { get; set; }

        public GenericRepository(ApplicationContext Context)
        {
            context = Context;
            set = context.Set<T>();
        }

        public virtual async Task<List<T>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await set.ToListAsync(cancellationToken);
        }

        public virtual async Task<T> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await set.FindAsync(id, cancellationToken);
        }

        public virtual async Task<T> InsertAsync(T entity, CancellationToken cancellationToken)
        {
            await set.AddAsync(entity, cancellationToken);

            return entity;
        }

        public virtual void Update(T entity)
        {
            set.Update(entity);
        }

        public virtual void Delete(T entity)
        {
            set.Remove(entity);
        }
    }
}
