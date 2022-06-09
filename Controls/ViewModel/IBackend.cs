namespace Controls.ViewModel;

public interface IBackend: INotifyPropertyChanged
{
    string Name { get; }
    string Description { get; }
    List<Contact> Contacts { get; }

    void DeleteContact(string name);
}