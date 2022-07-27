using GraphQL.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL.API.Services
{
    public class ProductService : IProductService
    {
        private static List<Product> products = new()
        {
            new Product
            {
                Id = 1,
                Name = "Mobile",
                Price = 1000
            },
            new Product
            {
                Id = 2,
                Name = "TV",
                Price = 2500
            },
            new Product
            {
                Id = 3,
                Name = "Fan",
                Price = 200
            }

        };

        public Product AddProduct(Product product)
        {
            products.Add(product);
            return product;
        }

        public void DeleteProduct(int id)
        {
            var itemToRemove = products.FirstOrDefault(r => r.Id == id);
            products.Remove(itemToRemove);
        }

        public List<Product> GetAllProducts()
        {
            return products;
        }

        public Product GetProductById(int id)
        {
            return products.FirstOrDefault(x => x.Id == id);    
        }

        public Product UpdateProduct(int id, Product product)
        {
            var itemToUpdate = products.FirstOrDefault(r => r.Id == id);

            itemToUpdate.Name = product.Name;
            itemToUpdate.Price = product.Price;
            return itemToUpdate;
        }
    }
}
