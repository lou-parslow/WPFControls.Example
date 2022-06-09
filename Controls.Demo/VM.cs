namespace Controls.Demo;

public class VM : INotifyPropertyChanged
{
    public IEnumerable<string> BackendNames
    {
        get { return backends.Select(b => b.Name); }
    }

    public string BackendName
    {
        get
        {
            return backendName;
        }
        set
        {
            if (BackendNames.Contains(value))
            {
                backendName = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(Backend));
            }
            else
            {
                throw new Exception("invalid BackEnd name");
            }
        }
    }

    public IBackend? Backend
    {
        get
        {
            return backends.Where(b => b.Name == BackendName).FirstOrDefault();
        }
    }

    private string backendName = "Star Wars";

    private List<IBackend> backends = new List<IBackend>
    {
        new Backends.StarWars(),
        new Backends.ResponderClient(new Backends.ResponderServer(new Backends.StarTrek()))
        {
            Name = "Star Trek Responder Client",
            Description = "Star Trek Reponder Server Backend"
        }
        //new Backends.MockGraphQLClient(new Backends.MockGraphQLServer(new Backends.StarTrek()))
};

    public event PropertyChangedEventHandler? PropertyChanged;

    private void OnPropertyChanged([CallerMemberName] string? caller = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(caller));
    }
}