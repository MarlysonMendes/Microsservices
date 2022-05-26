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
                    Id = "602d2149e773f2a3399",
                    Name = "Iphone X",
                    Description = " Celular de ultima geracao",
                    Image = "product-1.png",
                    Price = 950.0M,
                    Category = "smart phone"
                },
                new Product ()
                {
                    Id = "602d2149e7732fa30b6",
                    Name = "Samsung 10",
                    Description = " Celular de ultima geracao",
                    Image = "product-2.png",
                    Price = 700.0M,
                    Category = "smart phone"
                },
                new Product ()
                {
                    Id = "321d2149e7562da30b6",
                    Name = "Xiaomi 20",
                    Description = " Celular de ultima geracao",
                    Image = "product-3.png",
                    Price = 700.0M,
                    Category = "smart phone"
                },
                new Product ()
                {
                    Id = "4003252sdf22da30b6",
                    Name = "LG G7 ThinQ",
                    Description = " Celular de ultima geracao",
                    Image = "product-6.png",
                    Price = 240.0M,
                    Category = "Home Kitchen"
                }
            };
        }
    }
}
