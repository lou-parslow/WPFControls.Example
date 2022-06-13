using GraphQL;
using GraphQL.Types;
using System.Text.Json;

namespace Models.Adapters;

internal class ContactGroupGraphQLServer
{
    private IContactGroup _model;
    public ContactGroupGraphQLServer(IContactGroup model)
    {
        _model = model;
    }

    public string Respond(string request)
    {
        var options = new ExecutionOptions
        {
            Schema = Schema,
            Query = request,
            Root = _model
        };
        Task<ExecutionResult> executeTask = new DocumentExecuter().ExecuteAsync(options);
        executeTask.Wait();

        MemoryStream memory = new();
        Utf8JsonWriter writer = new Utf8JsonWriter(memory);
        new GraphQL.SystemTextJson.ExecutionResultJsonConverter().Write(writer, executeTask.Result,
            new JsonSerializerOptions { WriteIndented = true });

        writer.Flush();
        writer.Dispose();
        memory.Seek(0, SeekOrigin.Begin);
        return new StreamReader(memory).ReadToEnd();
    }
    private static ISchema Schema
    {
        get
        {
            return new Schema
            {
                Query = new GQLContactGroup(),
                Mutation = new GQLContactGroup(),
            };
        }
    }
}

internal class GQLContact : ObjectGraphType<Contact>
{
    public GQLContact()
    {
        Name = "Contact";
        Field<StringGraphType>("name");
        Field<StringGraphType>("email");
    }
}

internal class GQLContactGroup : ObjectGraphType<ContactGroup>
{
    public GQLContactGroup()
    {
        Name = "ContactGroup";
        Field<StringGraphType>("name", resolve: context => context.Source.Name);
        Field<StringGraphType>("description", resolve: context => context.Source.Description);
        Field<ListGraphType<GQLContact>>("contacts", resolve: context => context.Source.Contacts);
        Field<GQLContact>("deleteContact",
            arguments: new QueryArguments(
                new QueryArgument<StringGraphType>
                {
                    Name = "name",
                    Description = "The name of the contact to delete"
                }),
            resolve: context => context.Source.DeleteContact(context.GetArgument<string>("name")));
    }
}