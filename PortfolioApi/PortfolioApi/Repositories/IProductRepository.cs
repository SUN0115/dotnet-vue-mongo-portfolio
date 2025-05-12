using PortfolioApi.Models;
using System.Collections.Generic;

namespace PortfolioApi.Repositories
{
    public interface IProductRepository
    {
        List<Product> GetAll();
        Product Add(Product product);
    }
}
