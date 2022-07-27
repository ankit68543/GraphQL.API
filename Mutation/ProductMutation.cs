using GraphQL.API.Models;
using GraphQL.API.Services;
using GraphQL.API.Types;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL.API.Mutation
{
    public class ProductMutation : ObjectGraphType
    {
        public ProductMutation(IProductService productService)
        {
            Field<ProductType>("AddProduct", arguments: new QueryArguments(new QueryArgument<ProductInputType>(){ Name = "product" }),
                resolve: context =>
                {
                    var product = context.GetArgument<Product>("product");

                    return productService.AddProduct(product);
                });

            Field<ProductType>("UpdateProduct", arguments: new QueryArguments(new QueryArgument<IntGraphType>() { Name = "id" }, new QueryArgument<ProductInputType>() { Name = "product" }),
               resolve: context =>
               {
                   var product = context.GetArgument<Product>("product");

                   var id = context.GetArgument<int>("id");

                   return productService.UpdateProduct(id,product);
               });

            Field<StringGraphType>("DeleteProduct", arguments: new QueryArguments(new QueryArgument<IntGraphType>() { Name = "id" }),
              resolve: context =>
              {
                 
                  var id = context.GetArgument<int>("id");

                  productService.DeleteProduct(id);

                  return "Successfully deleted";
              });
        }

       

    }
}
