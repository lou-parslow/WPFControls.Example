
namespace Controls.Demo.Backends;

internal class ResponderServer : IResponder
{
    public ResponderServer(IBackend backend)
    {
        _backend = backend;
    }

    public string Respond(string request)
    {
        if (request == ResponderRequests.NameQuery) { return _backend.Name; }
        if (request == ResponderRequests.DescriptionQuery) { return _backend.Description; }
        if (request == ResponderRequests.ContactsQuery) { return JsonSerializer.Serialize(_backend.Contacts); }
        if (request.Contains("deleteContact:"))
        {
            _backend.DeleteContact(request.Replace("deleteContact:", "").Trim());
            return "deleted";
        }
        else
        {
            throw new Exception("Invalid request {request}");
        }
    }
    private IBackend _backend;
}
