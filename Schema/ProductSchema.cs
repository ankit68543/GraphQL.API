using GraphQL.API.Mutation;
using GraphQL.API.Queries;

namespace GraphQL.API.Schema
{
    public class ProductSchema : GraphQL.Types.Schema
    {
        public ProductSchema(ProductQuery query,ProductMutation productMutation)
        {
            Query = query;
            Mutation = productMutation;
        }
    }
}
