using GraphQL.API.Services;
using GraphQL.API.Types;
using GraphQL.Types;

namespace GraphQL.API.Queries
{
    public class ProductQuery : ObjectGraphType
    {
        public ProductQuery(IProductService productService)
        {
            Field<ListGraphType<ProductType>>("products", resolve: context => { return productService.GetAllProducts(); }) ;
            Field<ProductType>("product",arguments: new QueryArguments(new QueryArgument<IntGraphType> {Name="id" }), 
                resolve: context => { return productService.GetProductById(context.GetArgument<int>("id")); });
        }
    }
}
