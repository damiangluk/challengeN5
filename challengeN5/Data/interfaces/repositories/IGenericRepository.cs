namespace challengeN5.Data.interfaces.repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync(CancellationToken cancellationToken);

        Task<T> GetByIdAsync(int id, CancellationToken cancellationToken);

        Task<T> InsertAsync(T entity, CancellationToken cancellationToken);

        void Update(T entity);

        void Delete(T entity);
    }
}
