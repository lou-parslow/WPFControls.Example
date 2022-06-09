
namespace Controls.Demo.Backends;

internal class ResponderClient : Backend
{
    public ResponderClient(ResponderServer server)
    {
        _server = server;
        Name = "Responder Client";
        Description = "Responder Client BackEnd";
    }

    public override List<Contact> Contacts
    {
        get
        {
            return JsonSerializer.Deserialize<List<Contact>>(_server.Respond(ResponderRequests.ContactsQuery))!;
        }
    }

    public override void DeleteContact(string name)
    {
        _server.Respond(ResponderRequests.GetDeleteContactMutation(name));
        OnPropertyChanged(nameof(Contacts));
    }

    private ResponderServer _server;
}
