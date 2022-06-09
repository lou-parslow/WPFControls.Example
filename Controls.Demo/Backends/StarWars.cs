﻿namespace Controls.Demo.Backends
{
    internal class StarWars : IBackend
    {
        public string Name
        { get { return "Star Wars"; } }

        public string Description
        { get { return "Star Wars BackEnd"; } }

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
}