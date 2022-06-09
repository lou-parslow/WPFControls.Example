namespace Controls.Demo.Backends;

internal class MockGraphQLServer
{
    public MockGraphQLServer(IBackend backend)
    {
        _backend = backend ?? throw new ArgumentNullException(nameof(backend)); ;
    }

    public string Respond(string request)
    {
        if (request == NameQuery) { return _backend.Name; }
        if (request == DescriptionQuery) { return "MockGraphQLServer->" + _backend.Description; }
        if (request == ContactsQuery) { return JsonSerializer.Serialize(_backend.Contacts); }
        throw new Exception("Invalid request {request}");
    }

    public static string NameQuery
    {
        get { return "query{name}"; }
    }

    public static string DescriptionQuery
    {
        get { return "query{description}"; }
    }

    public static string ContactsQuery
    {
        get
        {
            return "query{contacts{name,email}}";
        }
    }

    private IBackend _backend;
}