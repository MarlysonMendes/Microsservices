using Catalog.API.Entities;

namespace Catalog.API.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<Product> GetByIdProductsAsync(string id);
        Task<IEnumerable<Product>> GetByNameProductsAsync(string name);
        Task<IEnumerable<Product>> GetByCategoryProductsAsync(string categoryName);

        Task CreateProduct(Product product);
        Task<bool> UpdateProductAsync(Product product);
        Task<bool> DeleteProductAsync (string id);
    }
}
