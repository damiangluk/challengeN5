using challengeN5.Data.interfaces;
using challengeN5.Data.norelational.mapping;
using challengeN5.Models;
using Nest;
using System.Reflection.Metadata;
using System.Xml.Linq;

namespace challengeN5.Data.norelational
{
    public class ElasticsearchService : IElasticsearchService
    {
        private readonly IConfiguration _configuration;
        private readonly IElasticClient _elasticClient;

        public ElasticsearchService(IConfiguration configuration)
        {
            _configuration = configuration;
            _elasticClient = CreateInstance();
            CheckIndex("permissions");
        }

        public ElasticClient CreateInstance()
        {
            string host = _configuration.GetSection("ElasticsearchServer:Host").Value;
            string port = _configuration.GetSection("ElasticsearchServer:Port").Value;
            string username = _configuration.GetSection("ElasticsearchServer:Username").Value;
            string password = _configuration.GetSection("ElasticsearchServer:Password").Value;

            var settings = new ConnectionSettings(new Uri(host + ":" + port)).EnableApiVersioningHeader().DefaultIndex("permissions");
            if(!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
            {
                settings.BasicAuthentication(username, password);
            }

            return new ElasticClient(settings);
        }

        public async Task CheckIndex(string indexName)
        {
            var any = await _elasticClient.Indices.ExistsAsync(indexName);

            if (any.Exists)
                return;

            await _elasticClient.Indices.CreateAsync(indexName, ci => ci.Index(indexName).PermissionMapping().Settings(s => s.NumberOfShards(1).NumberOfReplicas(1)));
        }

        public async Task InsertDocument<T>(string indexName, T entity) where T : class
        {
            try
            {
                var response = await _elasticClient.IndexDocumentAsync(entity);
            } catch (Exception ex)
            {
            }
        }
    }
}
