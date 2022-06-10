namespace Controls.ViewModel;

internal class Design : ContactGroup//, IContactGroup
{
    public Design()
    {
        Name = "Design";
        Description = "A Design Backend";
        Contacts = new()
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