using System.Linq;
using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Types;

public class Query
{
    [UseDbContext(typeof(DatabaseContext))]
    [UsePaging]
    public IQueryable<User> GetUsers([ScopedService] DatabaseContext dbContext)
        => dbContext.Users;
}

public class User
{
    public int Id { get; set; }

    public string Name { get; set; }
}
