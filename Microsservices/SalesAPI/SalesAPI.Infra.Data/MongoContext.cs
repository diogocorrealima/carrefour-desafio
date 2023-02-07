using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using SalesAPI.Domain.Core.Entities;
using SalesAPI.Domain.Entities;
using static System.Net.Mime.MediaTypeNames;

namespace SalesAPI.Infra.Data
{
    public class MongoContext<T> where T : class
    {
        private IMongoDatabase _database { get; }
        public MongoContext(IConfiguration configuration)
        {
            try
            {
                MongoClientSettings settings = MongoClientSettings.FromUrl(new MongoUrl(configuration.GetSection("ConnectionStrings:MongoDb").Value));
                var mongoClient = new MongoClient(settings);
                _database = mongoClient.GetDatabase(configuration.GetSection("ConnectionStrings:MongoDb").Value.Split('/').LastOrDefault().Trim());

                #region  RegisterMappings
                SalesMapping.DefineClassMap();
                #endregion
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível se conectar com o servidor.", ex);
            }
        }
        public IMongoCollection<T> Collection
        {
            get
            {
                string collectionName = typeof(T).Name.ToLowerInvariant()[0] + typeof(T).Name.Substring(1);
                IMongoCollection<T> collection = _database.GetCollection<T>(collectionName);

                if (collection == null)
                {
                    _database.CreateCollection(collectionName);
                }
                return collection;
            }
        }
    }
}
