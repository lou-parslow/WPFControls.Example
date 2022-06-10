
namespace Controls.Demo.Backends;

internal class ResponderServer : IResponder
{
    public ResponderServer(IContactGroup group)
    {
        _group = group;
    }

    public string Respond(string request)
    {
        if (request == ResponderRequests.NameQuery) { return _group.Name; }
        if (request == ResponderRequests.DescriptionQuery) { return _group.Description; }
        if (request == ResponderRequests.ContactsQuery) { return JsonSerializer.Serialize(_group.Contacts); }
        if (request.Contains("deleteContact:"))
        {
            _group.DeleteContact(request.Replace("deleteContact:", "").Trim());
            return "deleted";
        }
        else
        {
            throw new Exception("Invalid request {request}");
        }
    }
    private IContactGroup _group;
}
