using GraphiQl;
using GraphQL.API.Mutation;
using GraphQL.API.Queries;
using GraphQL.API.Schema;
using GraphQL.API.Services;
using GraphQL.API.Types;
using GraphQL.Server;
using GraphQL.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace GraphQL.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddTransient<IProductService, ProductService>();
            services.AddSingleton<ProductType>();
            services.AddSingleton<ProductQuery>();
            services.AddSingleton<ProductMutation>();
            services.AddSingleton<ISchema,ProductSchema>();
            services.AddGraphQL(options => {
                options.EnableMetrics = false;
            }).AddSystemTextJson();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseGraphiQl("/graphql");
            app.UseGraphQL<ISchema>();


        }
    }
}
