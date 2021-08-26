using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Types;
using MongoDB.Driver;

public class Query
{
    [UsePaging]
    public IExecutable<MongoUser> GetUsers([Service] IMongoCollection<MongoUser> collection)
        => collection.AsExecutable();
}

public class MongoUser
{
    public string Id { get; set; }

    public string Name { get; set; }
}
