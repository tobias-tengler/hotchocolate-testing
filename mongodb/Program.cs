using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MongoDB.Driver;

public class Program
{
    public static async Task Main(string[] args)
    {
        var host = CreateHostBuilder(args).Build();

        var collection = host.Services.GetRequiredService<IMongoCollection<User>>();

        var users = new List<User>
        {
            new User { Id = "user1", Name = "User 1"},
            new User { Id = "user2", Name = "User 2"},
            new User { Id = "user3", Name = "User 3"},
        };

        // poor mans data seeding
        await collection.DeleteManyAsync(_ => true);

        await collection.InsertManyAsync(users);

        await host.RunAsync();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });
}
