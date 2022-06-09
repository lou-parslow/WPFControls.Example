namespace Controls.Demo.Backends;

internal class MockGraphQLClient : IBackend
{
    private MockGraphQLServer _server;

    public MockGraphQLClient(MockGraphQLServer server)
    {
        _server = server;
    }

    public string Name
    {
        get
        {
            return _server.Respond(MockGraphQLServer.NameQuery);
        }
    }

    public string Description
    { get { return "MockGraphQLClient->" + _server.Respond(MockGraphQLServer.DescriptionQuery); } }

    public IEnumerable<Contact> Contacts
    {
        get
        {
            return JsonSerializer.Deserialize<IEnumerable<Contact>>(_server.Respond(MockGraphQLServer.ContactsQuery))!;
        }
    }

    public void DeleteContact(string name)
    {
    }
}