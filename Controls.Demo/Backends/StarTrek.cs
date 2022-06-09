namespace Controls.Demo.Backends;

internal class StarTrek : IBackend
{
    public string Name
    { get { return "Star Trek"; } }

    public string Description
    { get { return "Star Trek BackEnd"; } }

    public IEnumerable<Contact> Contacts
    {
        get
        {
            return _contacts;
        }
    }

    public void DeleteContact(string name)
    {
        if (_contacts.Where(c => c.Name == name).FirstOrDefault() is Contact contact)
        {
            _contacts.Remove(contact);
        }
        else
        {
            throw new Exception($"Contact of name '{name}' was not found");
        }
    }

    private List<Contact> _contacts = new()
    {
            new Contact
            {
                Name="Jean-Luc Picard",
                Email="jluc@uss.enterpise.com"
            },
            new Contact
            {
                Name="William Riker",
                Email="riker681@uss.enterprise.com"
            },
            new Contact
            {
                Name ="Geordi La Forge",
                Email="glaforge@engineering.uss.enterprise.com"
            }
        };
}