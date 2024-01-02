using challengeN5.Models;

namespace challengeN5.Data.interfaces
{
    public interface IElasticsearchService
    {
        Task CheckIndex(string indexName);
        Task InsertDocument<T>(string indexName, T entity) where T : class;
    }
}
