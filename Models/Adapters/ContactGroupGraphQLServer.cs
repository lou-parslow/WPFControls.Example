using GraphQL;
using GraphQL.Types;

namespace Models.Adapters;

internal class ContactGroupGraphQLServer
{
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