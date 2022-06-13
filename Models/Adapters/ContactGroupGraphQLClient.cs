using System.Text.Json;

namespace Models.Adapters;

public class ContactGroupGraphQLClient : IContactGroup
{
    public ContactGroupGraphQLClient(IContactGroup model)
    {
        server = new ContactGroupGraphQLServer(model);
    }
    public string Name { 
        get {
            return JsonSerializer.Deserialize<JsonElement>(server.Respond("query{name}"))!.GetProperty("data")!.GetProperty("name")!.GetString()!;
        } 
    }

    public string Description { get { return JsonSerializer.Deserialize<JsonElement>(server.Respond("query{description}"))!.GetProperty("data")!.GetProperty("description")!.GetString()!; } }

    public List<Contact> Contacts { get {
            var contacts = new List<Contact>();
            var response = server.Respond("query{contacts{name,email}}");
            var data = JsonSerializer.Deserialize<JsonElement>(response)!.GetProperty("data")!;
            var jcontacts = data.GetProperty("contacts")!;
            foreach(var jcontact in jcontacts.EnumerateArray())
            {
                string name = jcontact.GetProperty("name").GetString()!;
                string email = jcontact.GetProperty("email").GetString()!;
                contacts.Add(new Contact { Name = name, Email = email });
            }
            
            return contacts;
        } }

    public Contact DeleteContact(string name) {
        string mutation = "mutation{deleteContact(name:NAME){name,email}}";
        var response = server.Respond(mutation.Replace("NAME",$"\"{name}\""));
        var data = JsonSerializer.Deserialize<JsonElement>(response)!.GetProperty("data")!;
        var contact = data.GetProperty("deleteContact")!;
        string cname = contact.GetProperty("name").GetString()!;
        string cemail = contact.GetProperty("email").GetString()!;
        return new Contact { Name = cname, Email = cemail };
    }

    private ContactGroupGraphQLServer server;
}
