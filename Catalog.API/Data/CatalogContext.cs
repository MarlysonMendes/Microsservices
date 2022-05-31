using Catalog.API.Entities;
using MongoDB.Driver;

namespace Catalog.API.Data
{
    public class CatalogContext : ICatalogContext
    {
        public CatalogContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetValue<string>
                ("DatabaseSettigns:Connectionstring"));
            var database = client.GetDatabase(configuration.GetValue<string>
                ("DatabaseSettigns:DatabaseName"));
            Products = database.GetCollection<Product>(configuration.GetValue<string>
                ("DatabaseSettigns:CollectionName"));
            
        }
        public IMongoCollection<Product> Products { get; set; }
    }
}
