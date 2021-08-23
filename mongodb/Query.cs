using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Types;
using MongoDB.Driver;

public class Query
{
    [UsePaging]
    public IExecutable<User> GetUsers([Service] IMongoCollection<User> collection)
        => collection.AsExecutable();
}

public class User
{
    public string Id { get; set; }

    public string Name { get; set; }
}
