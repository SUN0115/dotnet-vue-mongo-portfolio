using PortfolioApi.Models;
using System.Collections.Generic;
using MongoDB.Driver;
using Microsoft.Extensions.Options;
using PortfolioApi.Configuration;

namespace PortfolioApi.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IMongoCollection<Product> _collection;

        public ProductRepository(IMongoClient client, IOptions<MongoSettings> settings)
        {
            var database = client.GetDatabase(settings.Value.DatabaseName);
            _collection = database.GetCollection<Product>(settings.Value.ProductCollectionName);
        }

        public List<Product> GetAll()
        {
            return _collection.Find(_ => true).ToList();
        }

        public Product Add(Product product)
        {
            _collection.InsertOne(product);
            return product;
        }
    }
}
