namespace Controls.Demo.Adapters;

/// <summary>
/// Adapts a Models.ContactGroup to a ViewModel.IContactGroup
/// </summary>
internal class ContactGroup : ViewModel.IContactGroup, INotifyPropertyChanged
{
    public ContactGroup(Models.IContactGroup model)
    { _model = model; }

    private readonly Models.IContactGroup _model;

    public string Name
    {
        get => _model.Name;
    }

    public string Description
    {
        get { return _model.Description; }
    }

    public List<Contact> Contacts
    {
        get
        {
            return new List<Contact>(_model.Contacts.Select(c => new Contact { Name = c.Name, Email = c.Email }));
        }
    }

    public Contact DeleteContact(string name)
    {
        Models.Contact mc = _model.DeleteContact(name);
        OnPropertyChanged(nameof(Contacts));
        return new Contact { Name = mc.Name, Email = mc.Email };
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    private void OnPropertyChanged([CallerMemberName] string? caller = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(caller));
    }
}