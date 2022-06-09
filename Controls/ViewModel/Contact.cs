﻿namespace Controls.ViewModel;

public class Contact : INotifyPropertyChanged
{
    public string Name
    {
        get { return _name; }
        set { _name = value; OnPropertyChanged(); }
    }

    private string _name;

    public string Email
    {
        get { return _email; }
        set { _email = value; OnPropertyChanged(); }
    }

    private string _email;

    public event PropertyChangedEventHandler? PropertyChanged;

    private void OnPropertyChanged([CallerMemberName] string? caller = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(caller));
    }
}