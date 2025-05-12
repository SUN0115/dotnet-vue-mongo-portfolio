using PortfolioApi.Models;
using System.Collections.Generic;

namespace PortfolioApi.Services
{
    public interface IProductService
    {
        List<Product> GetAllProducts();
        Product CreateProduct(Product product);
    }
}