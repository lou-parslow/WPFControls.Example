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
            if(Backend is ViewModel.IBackend backend)
            {
                backend.DeleteContact(ContactName);
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

        #region IBackend Backend dependency property
        public ViewModel.IBackend? Backend
        {
            get { return (ViewModel.IBackend)GetValue(BackendProperty); }
            set { SetValue(BackendProperty, value); }
        }

        public static readonly DependencyProperty BackendProperty =
            DependencyProperty.Register(nameof(Backend), typeof(ViewModel.IBackend), typeof(ContactDeleteButton));

        #endregion ViewModel.IBackend dependency property
    }
}
