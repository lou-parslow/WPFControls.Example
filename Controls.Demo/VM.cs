namespace Controls.Demo;

public class VM : INotifyPropertyChanged
{
    public IEnumerable<string> ContactGroupNames
    {
        get { return contactGroups.Select(b => b.Name); }
    }

    public string ContactGroupName
    {
        get
        {
            return contactGroupName;
        }
        set
        {
            if (ContactGroupNames.Contains(value))
            {
                contactGroupName = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(ContactGroup));
            }
            else
            {
                throw new Exception("invalid ContactGroup name");
            }
        }
    }

    public IContactGroup? ContactGroup
    {
        get
        {
            return contactGroups.Where(b => b.Name == ContactGroupName).FirstOrDefault();
        }
    }

    private string contactGroupName = "Star Wars";

    private List<IContactGroup> contactGroups = new List<IContactGroup>
    {
        new Backends.StarWars(),
        new Backends.ResponderClient(new Backends.ResponderServer(new Backends.StarTrek()))
        {
            Name = "Star Trek Responder Client",
            Description = "Star Trek Reponder Server Backend"
        }
    };


    public event PropertyChangedEventHandler? PropertyChanged;

    private void OnPropertyChanged([CallerMemberName] string? caller = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(caller));
    }
}
