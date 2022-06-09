﻿namespace Controls.ViewModel;

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

    private List<Contact> _contacts = new List<Contact>
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