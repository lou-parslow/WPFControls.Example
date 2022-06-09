namespace Controls.ViewModel;

internal class Design : IBackend
{
    public string Name
    { get { return "Design"; } }

    public string Description
    { get { return "A simple BackEnd for use as a d:DataContext"; } }

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

    private readonly List<Contact> _contacts = new()
    {
            new Contact
            {
                Name="Luke Skywalker",
                Email="jedi42@polis.massa.org"
            },
            new Contact
            {
                Name="Leia Organa",
                Email="lorgana51@rebelalliance.com"
            },
            new Contact
            {
                Name = "Han Solo",
                Email = "han.solo@cloudcity.com"
            }
        };
}