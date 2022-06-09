namespace Controls.ViewModel;

public interface IBackend
{
    string Name { get; }
    string Description { get; }
    IEnumerable<Contact> Contacts { get; }
}