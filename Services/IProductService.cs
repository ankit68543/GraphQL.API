using GraphQL.API.Models;
using System.Collections.Generic;

namespace GraphQL.API.Services
{
    public interface IProductService
    {
        List<Product> GetAllProducts();

        Product GetProductById(int id);

        Product AddProduct(Product product);

        Product UpdateProduct(int id,Product product);

        void DeleteProduct(int id);
    }
}
