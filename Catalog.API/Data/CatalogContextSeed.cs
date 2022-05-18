using Catalog.API.Entities;
using MongoDB.Driver;

namespace Catalog.API.Data
{
    public class CatalogContextSeed
    {
        public static void SeendData(IMongoCollection<Product> productCollection)
        {
            bool existProduct = productCollection.Find(p=>true).Any();

            if(!existProduct)
            {
                productCollection.InsertManyAsync(GetPMyroducts());
            }
        }
        private static IEnumerable<Product> GetPMyroducts()
        {
            return new List<Product>()
            {
                new Product ()
                {
                    Id = 1,
                    Name = "Iphone X",
                    Description = " Celular de ultima geracao",
                    Image = "product-1.png",
                    Price = 950.0M,
                    Category = "smart phone"
                }
            };
        }
    }
}
