using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MongoDB.Driver;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
        var client = new MongoClient("mongodb://localhost:27017");
        var database = client.GetDatabase("test");
        var collection = database.GetCollection<MongoUser>("users");

        services.AddSingleton(collection);

        services
            .AddGraphQLServer()
            .InitializeOnStartup()
            .AddMongoDbPagingProviders()
            .AddQueryType<Query>();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseRouting();

        app.UseEndpoints(endpoints =>
        {
            // By default the GraphQL server is mapped to /graphql
            // This route also provides you with our GraphQL IDE. 
            // In order to configure the GraphQL IDE use endpoints.MapGraphQL().WithToolOptions(...).
            endpoints.MapGraphQL();
        });
    }
}