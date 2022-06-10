﻿namespace Models;

public class ContactGroup : INotifyPropertyChanged
{

    public string Name { get; set; } = "BackEnd";

    public string Description { get; set; } = "A Simple BackEnd";

    public virtual List<Contact> Contacts { get { return _contacts; } set { _contacts = value; OnPropertyChanged(); } }
    private List<Contact> _contacts = new();

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

    public static ContactGroup StarWars
    {
        get
        {
            ContactGroup group = new ContactGroup()
            {
                Name = "Star Wars",
                Description = "Star Wars ContactGroup"
            };
            group.Contacts = new List<Contact>
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
            return group;
        }
    }
    public static ContactGroup StarTrek
    {
        get
        {
            ContactGroup group = new ContactGroup()
            {
                Name = "Star Trek",
                Description = "Star Trek ContactGroup"
            };
            group.Contacts = new List<Contact>
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
            return group;
        }
    }
}
