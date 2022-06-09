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
            MessageBox.Show($"TODO: delete Contact {ContactName}");
            base.OnClick();
        }
        #region string ContactName dependency property
        public string ContactName
        {
            get { return (string)GetValue(ContactNameProperty); }
            set { SetValue(ContactNameProperty, value); }
        }

        public static readonly DependencyProperty ContactNameProperty =
            DependencyProperty.Register(nameof(ContactName), typeof(string), typeof(ContactDeleteButton), new PropertyMetadata(OnContactNameChanged));

        private static void OnContactNameChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
        }
        #endregion string ContactName dependency property
    }
}
