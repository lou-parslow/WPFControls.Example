﻿namespace Controls.Demo;

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
            //IContactGroup cg = contactGroups.Where(b => b.Name == ContactGroupName).FirstOrDefault();
            return contactGroups.Where(b => b.Name == ContactGroupName).FirstOrDefault();
        }
    }

    private string contactGroupName = "Star Wars";

    private List<IContactGroup> contactGroups = new List<IContactGroup>
    {
        // Dependency inject occurs here
        new Adapters.ContactGroup(Models.ContactGroups.StarWars),
        new Adapters.ContactGroup(Models.ContactGroups.StarTrek)
    };

    public event PropertyChangedEventHandler? PropertyChanged;

    private void OnPropertyChanged([CallerMemberName] string? caller = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(caller));
    }
}