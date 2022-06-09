namespace Controls.Demo.Backends;

internal class StarTrek : IBackend
{
    public string Name
    { get { return "Star Trek"; } }

    public string Description
    { get { return "Star Trek BackEnd"; } }

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
}