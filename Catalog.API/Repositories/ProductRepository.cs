using Catalog.API.Data;
using Catalog.API.Entities;
using MongoDB.Driver;

namespace Catalog.API.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ICatalogContext _ctx;
        public ProductRepository(ICatalogContext ctx)
        {
            _ctx = ctx;
        }
        public async Task CreateProduct(Product product)
        {
            await _ctx.Products.InsertOneAsync(product);
        }

        public async Task<bool> DeleteProductAsync(string id)
        {
            FilterDefinition<Product> filter = Builders<Product>.Filter.Eq(p => p.Id,id);
            DeleteResult deleteResult = await _ctx.Products.DeleteOneAsync(filter);
            return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
        }

        public async Task<Product> GeByIdProductsAsync(string id)
        {
            return await _ctx.Products.Find(p => p.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await _ctx.Products.Find(p => true).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetByCategoryProductsAsync(string categoryName)
        {
            FilterDefinition<Product> filter = Builders<Product>.Filter
                .Eq(p=>p.Category,categoryName);
            return await _ctx.Products.Find(filter).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetByNameProductsAsync(string name)
        {
            FilterDefinition<Product> filter = Builders<Product>.Filter
                .Eq(p => p.Name, name);
            return await _ctx.Products.Find(filter).ToListAsync();
        }

        public async Task<bool> UpdateProductAsync(Product product)
        {
            var updateResult = await _ctx.Products.ReplaceOneAsync(
                filter: g=>g.Id == product.Id, replacement: product);
            return updateResult.IsAcknowledged && 
                updateResult.ModifiedCount > 0;
        }
    }
}
