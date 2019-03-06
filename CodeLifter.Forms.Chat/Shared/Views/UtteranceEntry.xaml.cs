using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;

namespace CodeLifter.Forms.Chat.Views
{
    /// <summary>
    /// The entry field that comes with CodeLifter.Forms.Chat
    /// </summary>
    public partial class UtteranceEntry : ContentView
    {
        public static readonly BindableProperty SubmitCommandProperty =
            BindableProperty.Create(nameof(Command),
            typeof(ICommand),
            typeof(DialogView),
            null);

        public ICommand SubmitCommand
        {
            get { return (ICommand)GetValue(SubmitCommandProperty); }
            set { SetValue(SubmitCommandProperty, value); }
        }

        public static readonly BindableProperty TextProperty = BindableProperty.Create(
          "Text",
          typeof(string),
          typeof(DialogView),
          string.Empty,
          BindingMode.TwoWay);

        public string Text
        {
            get 
            { 
                return (string)GetValue(TextProperty); 
            }
            set 
            {
                chatInput.Text = value;
                SetValue(TextProperty, value); 
            }
        }

        public UtteranceEntry()
        {
            InitializeComponent();
        }

        public void Handle_Completed(object sender, EventArgs e)
        {
            chatInput.Focus();
            SubmitCommand.Execute(null);
            Text = string.Empty;
        }

        void Handle_TextChanged(object sender, Xamarin.Forms.TextChangedEventArgs e)
        {
            Text = e.NewTextValue;
        }
    }
}
