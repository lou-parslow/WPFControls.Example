namespace Controls.ViewModel;

public class ContactGroup : IContactGroup, INotifyPropertyChanged
{
    public ContactGroup()
    {
        Name = "Design";
        Description = "A Design Backend";
        Contacts = new()
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

    public string Name { get; set; } = "BackEnd";

    public string Description { get; set; } = "A Simple BackEnd";

    public virtual List<Contact> Contacts
    { get { return _contacts; } set { _contacts = value; OnPropertyChanged(); } }
    private List<Contact> _contacts = new List<Contact>();

    public virtual Contact DeleteContact(string name)
    {
        if (_contacts.Where(c => c.Name == name).FirstOrDefault() is Contact contact)
        {
            _contacts.Remove(contact);
            return contact;
        }
        else
        {
            throw new Exception($"Contact of name '{name}' was not found");
        }
        Contacts = new List<Contact>(_contacts);
        //OnPropertyChanged(nameof(Contacts));
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected void OnPropertyChanged([CallerMemberName] string? caller = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(caller));
    }
}