namespace Models;

public interface IContactGroup
{
    string Name { get; }

    string Description { get; }

    List<Contact> Contacts { get; }

    Contact DeleteContact(string name);
}

public class ContactGroup : IContactGroup
{
    public string Name { get; set; } = "BackEnd";

    public string Description { get; set; } = "A Simple BackEnd";

    public virtual List<Contact> Contacts
    { get { return _contacts; } set { _contacts = value; } }

    private List<Contact> _contacts = new();

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
    }
}

public static class ContactGroups
{
    public static IContactGroup StarWars
    {
        get
        {
            ContactGroup group = new()
            {
                Name = "Star Wars",
                Description = "Star Wars ContactGroup",
                Contacts = new List<Contact>
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
            }
            };
            return group;
        }
    }

    public static IContactGroup StarTrek
    {
        get
        {
            ContactGroup group = new()
            {
                Name = "Star Trek",
                Description = "Star Trek ContactGroup",
                Contacts = new List<Contact>
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
            }
            };
            return group;
        }
    }
}