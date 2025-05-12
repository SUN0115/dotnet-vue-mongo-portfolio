using PortfolioApi.Models;
using PortfolioApi.Repositories;
using System.Collections.Generic;

namespace PortfolioApi.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public List<Product> GetAllProducts()
        {
            return _productRepository.GetAll();
        }

        public Product CreateProduct(Product product)
        {
            return _productRepository.Add(product);
        }
    }
}
