

namespace Controls.ViewModel;

public class Backend : IBackend, INotifyPropertyChanged
{
    public string Name { get; set; } = "BackEnd";

    public string Description { get; set; } = "A Simple BackEnd";

    public virtual List<Contact> Contacts { get { return _contacts; } set { _contacts = value;OnPropertyChanged(); } }
    private List<Contact> _contacts = new List<Contact>();

    public virtual void DeleteContact(string name)
    {
        if (_contacts.Where(c => c.Name == name).FirstOrDefault() is Contact contact)
        {
            _contacts.Remove(contact);
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