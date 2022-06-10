namespace Controls.View
{
    internal class ContactDeleteButton : Button
    {
        public ContactDeleteButton()
        {
            Content = "Delete";
        }

        protected override void OnClick()
        {
            if (Contacts is ViewModel.IContactGroup contacts)
            {
                contacts.DeleteContact(ContactName);
            }
        }
        #region string ContactName dependency property
        public string ContactName
        {
            get { return (string)GetValue(ContactNameProperty); }
            set { SetValue(ContactNameProperty, value); }
        }

        public static readonly DependencyProperty ContactNameProperty =
            DependencyProperty.Register(nameof(ContactName), typeof(string), typeof(ContactDeleteButton));

        #endregion string ContactName dependency property

        #region ViewModel.IContacts Contacts dependency property
        public ViewModel.IContactGroup? Contacts
        {
            get { return (ViewModel.IContactGroup)GetValue(ContactsProperty); }
            set { SetValue(ContactsProperty, value); }
        }

        public static readonly DependencyProperty ContactsProperty =
            DependencyProperty.Register(nameof(Contacts), typeof(ViewModel.IContactGroup), typeof(ContactDeleteButton));

        #endregion ViewModel.Contacts dependency property
    }
}
