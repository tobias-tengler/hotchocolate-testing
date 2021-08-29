using System.Collections.Generic;
using HotChocolate;
using HotChocolate.Data.Neo4J;
using HotChocolate.Data.Neo4J.Execution;
using HotChocolate.Types;
using Neo4j.Driver;

public class Query
{
    // todo: doesn't work
    [UseNeo4JDatabase(databaseName: "neo4j")]
    [UseOffsetPaging]
    public Neo4JExecutable<Actor> GetActors([ScopedService] IAsyncSession session)
    {
        return new(session);
    }
}

[Neo4JNode("Actor")]
public class Actor
{
    public string Name { get; set; }

    [Neo4JRelationship("ACTED_IN")]
    public List<Movie> ActedIn { get; set; }
}

[Neo4JNode("Movie")]
public class Movie
{
    public string Title { get; set; }

    [Neo4JRelationship("ACTED_IN", RelationshipDirection.Incoming)]
    public List<Actor> Generes { get; set; }
}
