namespace Controls.Demo.Backends;

public class StarWars : Backend
{
    public StarWars()
    {
        Name = "Star Wars";
        Description = "Star Wars BackEnd";
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
        };
    }
    

}