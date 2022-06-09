namespace Controls.Demo.Backends;

internal class StarTrek : Backend
{
    public StarTrek()
    {
        Name = "Star Trek";
        Description = "Star Trek BackEnd";
        Contacts = new()
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
  


}